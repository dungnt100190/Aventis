PRINT ('
************************************************************
  START OF COMBINED SCRIPTS!
************************************************************
  Settings:
    settingsFile: [-]
    defaultFileEnding: [.sql]
    releaseFile: [_Releases\Release 4939\1. Dispatcher\ZH\Dispatcher.sql]
    searchFolder: [.]
    namespace extension: [RESTORE;ZH;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH]
    databaseName: [KiSS_ZH_DEV_R4939]
    databaseName document: [KiSS_ZH_DEV_R4939_DOC]
    databaseRootDirectory: [I:\Database\mssql2012]
    sql username: [kiss3]
    TFS check in: [True]
    TFS url: [http://DTVS0034:8080/tfs/KiSS-Projects]
    TFS user name: []
    TFS directory: []
    TFS workspace name: []
    VIS server name: [SZHM24946\SOZ_KISS_D]
    VIS database name: [KiSS_ZH_VIS_Test]
    Release number: [4939]
    Custom parameters: [Language=de]
  Information:
    machine: [DTVS0033]
    user: [sa-kiss-tfs-agent]
    time: [03.08.2017 08:25:26]
    version: [2.1.6403.23558]
************************************************************
');
PRINT ('  Info: Start of script: [' + CONVERT(VARCHAR, GETDATE(), 113) + ']');
PRINT ('
************************************************************
');

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_PreReleaseDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Disable_CDC_OnDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Disable_CDC_OnDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to disable CDC on current and document database to prevent errors 
           for capture job. This script can run on any database, even if there is no CDC available.

  WARNING: Running this script will drop all CDC history data!
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- use master database
-------------------------------------------------------------------------------
USE [master];
GO

-------------------------------------------------------------------------------
-- check if server is ready for CDC 
-- (requires SQLServer 2008 or newer and Developer or Enterprise edition)
-------------------------------------------------------------------------------
-- init vars
DECLARE @CanEnableCDC BIT;
DECLARE @ServerVersion VARCHAR(255);
DECLARE @ServerEdition VARCHAR(255);
--
DECLARE @SQLStatement NVARCHAR(MAX);

SET @CanEnableCDC = 0;
SET @ServerVersion = CONVERT(VARCHAR(255), SERVERPROPERTY('productversion'));
SET @ServerEdition = CONVERT(VARCHAR(255), SERVERPROPERTY ('edition'));

-- set vars
IF (@ServerVersion LIKE '10.%' AND (@ServerEdition LIKE 'Enterprise Edition%' OR @ServerEdition LIKE 'Developer Edition%'))
BEGIN
  SET @CanEnableCDC = 1;
END;

-- handling not available
IF (@CanEnableCDC = 0)
BEGIN
  PRINT ('Info: CDC is not available for this server (Version="' + ISNULL(@ServerVersion, '???') + '", Edition="' + ISNULL(@ServerEdition, '???') + '")');
  RETURN;
END;

PRINT ('Info: CDC is available for this server and will be disabled for main- (and optionally document-) database (Version="' + ISNULL(@ServerVersion, '???') + '", Edition="' + ISNULL(@ServerEdition, '???') + '")');

-------------------------------------------------------------------------------
-- disabling CDC in any case for main- and document-database
-------------------------------------------------------------------------------
-- main database
IF (EXISTS (SELECT TOP 1 1
            FROM sys.databases
            WHERE name = 'KiSS_ZH_DEV_R4939'
              AND state_desc = 'ONLINE'))
BEGIN
  SET @SQLStatement = 'USE [KiSS_ZH_DEV_R4939];
                       EXEC sys.sp_cdc_disable_db;';
  
  EXEC sys.sp_executesql @SQLStatement;
  PRINT ('Info: Disabled CDC for current database "KiSS_ZH_DEV_R4939" if it was enabled');
END;

-- document database
IF ((N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;SepDocDB;%' OR
     N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$SepDocDB;%') 
    AND EXISTS (SELECT TOP 1 1
                FROM sys.databases
                WHERE name = 'KiSS_ZH_DEV_R4939_DOC'
                  AND state_desc = 'ONLINE'))
BEGIN
  SET @SQLStatement = 'USE [KiSS_ZH_DEV_R4939_DOC];
                       EXEC sys.sp_cdc_disable_db;';
  
  EXEC sys.sp_executesql @SQLStatement;
  PRINT ('Info: Disabled CDC for current database "KiSS_ZH_DEV_R4939_DOC" if it was enabled');
END;
GO

-------------------------------------------------------------------------------
-- use master database
-------------------------------------------------------------------------------
USE [master];
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Disable_CDC_OnDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Disable_CDC_OnDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 21 $
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
            WHERE name = N'KiSS_ZH_DEV_R4939'
              AND state_desc = N'RESTORING')) 
BEGIN
  PRINT ('Info: Database "KiSS_ZH_DEV_R4939" is currently in RESTORE state and will be droped now to prevent error on ALTER statements.');
  DROP DATABASE [KiSS_ZH_DEV_R4939];
END;
GO

-- set single user mode to close all open connections
IF (EXISTS (SELECT TOP 1 1 
            FROM sys.databases WITH (READUNCOMMITTED) 
            WHERE name = N'KiSS_ZH_DEV_R4939')) 
BEGIN
  PRINT ('set singleuser: ' + CONVERT(VARCHAR, GETDATE(), 113));
  ALTER DATABASE [KiSS_ZH_DEV_R4939] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
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
                 WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;ZH;%') OR
                      (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$ZH;%') THEN 1                               -- ZH
                 ELSE 0
               END,
       --
       @IsZH_OIZSERVER = CASE 
                          WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;OIZSERVER;%') OR
                               (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$OIZSERVER;%') THEN 1                -- OIZSERVER
                          ELSE 0
                        END,
       --
       @IsZH_SCHINTI = CASE 
                          WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;SCHINTI;%') OR
                               (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$SCHINTI;%') THEN 1                 -- SCHINTI
                          ELSE 0
                        END,
       --
       @IsZH_TakeBakProdVortag = CASE 
                                   WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;SRCPRODBAK;%') OR
                                        (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$SRCPRODBAK;%') THEN 1     -- SRCPRODBAK
                                   ELSE 0
                                 END;

-------------------------------------------------------------------------------
--- settings
-------------------------------------------------------------------------------
SET @DBName     = N'KiSS_ZH_DEV_R4939';

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
       @DBPath     = N'I:\Database\mssql2012\',
       @DataFolder  = CASE 
                       WHEN @IsZH_OIZSERVER = 1 THEN @DBName
                       ELSE N'DATA\'
                     END,
       @LogFolder  = CASE 
                       WHEN @IsZH_OIZSERVER = 1 THEN @DBName
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
USE [KiSS_ZH_DEV_R4939];
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
ALTER DATABASE [KiSS_ZH_DEV_R4939] SET MULTI_USER WITH NO_WAIT;
GO

-- use current database
PRINT ('Info: Switch to database [KiSS_ZH_DEV_R4939] now: ' + CONVERT(VARCHAR, GETDATE(), 113));
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_DocDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 20 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to restore and setup database. This script is called by TeamCity
           to autmatically create new release databases.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 20 $ ----');
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
            WHERE name = N'KiSS_ZH_DEV_R4939_DOC'
              AND state_desc = N'RESTORING')) 
BEGIN
  PRINT ('Info: Database "KiSS_ZH_DEV_R4939_DOC" is currently in RESTORE state and will be droped now to prevent error on ALTER statements.');
  DROP DATABASE [KiSS_ZH_DEV_R4939_DOC];
END;
GO

-- set single user mode to close all open connections
IF (EXISTS (SELECT TOP 1 1 
            FROM sys.databases WITH (READUNCOMMITTED) 
            WHERE name = N'KiSS_ZH_DEV_R4939_DOC')) 
BEGIN
  PRINT ('set singleuser: ' + CONVERT(VARCHAR, GETDATE(), 113));
  ALTER DATABASE [KiSS_ZH_DEV_R4939_DOC] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END;
GO

-- init settings vars
DECLARE @DBName NVARCHAR(100);
DECLARE @BackupFile NVARCHAR(500);
DECLARE @IsDoc BIT;
DECLARE @DBPath NVARCHAR(500);
DECLARE @IsZH BIT;
DECLARE @IsZH_OIZSERVER BIT;
DECLARE @IsZH_SCHINTI BIT;
DECLARE @IsZH_TakeBakProdVortag BIT;

-- ZH specific NSE handling
SELECT @IsZH = CASE 
                 WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;ZH;%') OR
                      (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$ZH;%') THEN 1                               -- ZH
                 ELSE 0
               END,
       --
       @IsZH_OIZSERVER = CASE 
                          WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;OIZSERVER;%') OR
                               (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$OIZSERVER;%') THEN 1                -- OIZSERVER
                          ELSE 0
                        END,
       --
       @IsZH_SCHINTI = CASE 
                          WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;SCHINTI;%') OR
                               (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$SCHINTI;%') THEN 1                 -- SCHINTI
                          ELSE 0
                        END,
       --
       @IsZH_TakeBakProdVortag = CASE 
                                   WHEN (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;SRCPRODBAK;%') OR
                                        (N';' + N'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + N';' LIKE N'%;$SRCPRODBAK;%') THEN 1     -- SRCPRODBAK
                                   ELSE 0
                                 END;

-------------------------------------------------------------------------------
--- settings
-------------------------------------------------------------------------------
SET @DBName     = N'KiSS_ZH_DEV_R4939_DOC';

SELECT @BackupFile = CASE 
                       WHEN @IsZH = 1 THEN 
                         CASE 
                           WHEN @IsZH_OIZSERVER = 1 THEN
                             CASE
                               WHEN @IsZH_TakeBakProdVortag = 1 THEN N'I:\BakTrc\mssql2012\Backup\KISS_PROD\kiss4_zh_DOC.bak'
                               ELSE N'I:\BakTrc\mssql2012\Backup\KissBuildDBs\' + @DBName + '.bak'
                             END
                           WHEN @IsZH_SCHINTI = 1 THEN N'E:\kiss_backups\BuildDBs\' + @DBName + '.bak'
                           ELSE N'X:\InvalidSettings\PleaseSetCorrectNSE_DOC.bak'
                         END
                       -- internal
                       ELSE N'D:\KiSSDBPool\' + @DBName + '.bak'
                     END,
       @IsDoc      = 1, -- DocDB
       @DBPath     = N'I:\Database\mssql2012\' + @DBName;

-- info
PRINT ('Info: Current settings are: @DBName="' + @DBName + '"; @IsDoc="' + CONVERT(VARCHAR(10), @IsDoc) + '"; @BackupFile="' + @BackupFile + '"; @DBPath="' + @DBPath + '"');

-------------------------------------------------------------------------------
-- restore preparations
-------------------------------------------------------------------------------
-- start with nocount
SET NOCOUNT ON;

-- init vars
DECLARE @sql NVARCHAR(4000);
DECLARE @PrefFileName NVARCHAR(500);
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
SET @PrefFileName = @DBPath + @DBName + '_';

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
  SELECT N' MOVE ''' + [LogicalName] + N''' TO ''' + @PrefFileName +
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
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten1'', FILENAME = N''' + @PrefFileName + N'Daten1.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN1]';
  END;
  
  -- DATEN2
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN2')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN2]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten2'', FILENAME = N''' + @PrefFileName + N'Daten2.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN2]';
  END;
  
  -- DATEN3
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN3')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN3]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten3'', FILENAME = N''' + @PrefFileName + N'Daten3.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN3]';
  END;
  
  -- SYSTEM
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'SYSTEM')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [SYSTEM]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_System'', FILENAME = N''' + @PrefFileName + N'System.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [SYSTEM]';
  END;
  
  -- ARCHIV (only ZH)
  IF (@IsZH = 1)
  BEGIN
    IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'ARCHIV')) 
    BEGIN
      SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [ARCHIV]' + @NL +
        'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Archiv'', FILENAME = N''' + @PrefFileName + N'Archiv.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [ARCHIV]';
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
USE [KiSS_ZH_DEV_R4939_DOC];
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
ALTER DATABASE [KiSS_ZH_DEV_R4939_DOC] SET MULTI_USER WITH NO_WAIT;
GO

-- use current database
PRINT ('Info: Switch to database [KiSS_ZH_DEV_R4939_DOC] now: ' + CONVERT(VARCHAR, GETDATE(), 113));
USE [KiSS_ZH_DEV_R4939_DOC];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_DocDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Restore_ZH_DeleteProdInfos.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Restore_ZH_DeleteProdInfos.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to prod infos for ZH restore DBs. Steps copied from restore job.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Schnittstellen-Config-Werte ungültig setzen
-------------------------------------------------------------------------------
UPDATE dbo.XConfig
  SET DatumVon = CONVERT(DATETIME, '30000101')
WHERE KeyPath IN ('System\Schnittstellen\PSCD\PSCDNotificationWebServiceURL',
                  'System\Schnittstellen\PSCD\PSCDWebServiceURL',
                  'System\Schnittstellen\BackgroundWorkerService\BackgroundWorkerWebServiceURL',
                  'System\Allgemein\Benutzername_TechnischerBenutzer',
                  'System\Allgemein\Passwort_TechnischerBenutzer');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Restore_ZH_DeleteProdInfos.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Restore_ZH_DeleteProdInfos.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_XUserRemovePasswords.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_XUserRemovePasswords.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to remove all passwords on table XUser. This script is only allowed 
           to run with BIAG internal RESTORE tag.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 4 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- check history version
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'Hist_XUser'))
BEGIN
  -- create new history entry if table is historised
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
END;

-------------------------------------------------------------------------------
-- update entries in XUser if table is existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'XUser'))
BEGIN
  -- update entries and remove passwords
  UPDATE USR
  SET USR.PasswordHash = '4P/dakfPi6MQqGVn7Tdelw=='
  FROM dbo.XUser USR;
  
  -- info
  PRINT ('WARNING: Removed all passwords from table XUser!');
END;

-------------------------------------------------------------------------------
-- update entries in SysLogin if table is existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'SysLogin'))
BEGIN
  -- update entries and remove passwords
  UPDATE LGI
  SET LGI.PasswordHash = '4P/dakfPi6MQqGVn7Tdelw=='
  FROM dbo.SysLogin LGI
  WHERE AuthenticationModeEnum = 2; -- KiSS
  
  -- info
  PRINT ('WARNING: Removed all passwords from table SysLogin!');
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_XUserRemovePasswords.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_XUserRemovePasswords.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_EnableBiagAdmin.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_EnableBiagAdmin.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to set diag_admin as BIAGAdmin.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check history version
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'Hist_XUser'))
BEGIN
  -- create new history entry if table is historised
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
END;


-------------------------------------------------------------------------------
-- set diag_admin as BIAGAdmin
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'XUser'))
BEGIN
  -- set diag_admin as BIAGAdmin
  UPDATE USR 
    SET IsLocked = 0, IsUserAdmin = 1, IsUserBIAGAdmin = 1
  FROM XUser USR
  WHERE LogonName = 'diag_admin'
  
  -- info
  PRINT ('WARNING: Removed all passwords from table XUser!');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_EnableBiagAdmin.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_EnableBiagAdmin.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\RestoreDatabase\Rxxxx_Restore_PreReleaseDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to automatically check all prerequisites for release script. If there
           is any error, the whole release script will be canceled and a server-log entry will
           be created!
           
           You need to be member of "SysAdmin" on sqlserver instance to run this script!
=================================================================================================*/

-------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

SET NOCOUNT ON;
GO

-- Collation-Check: wird als Print-Warning ausgegeben

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to verify that the DB has the same collation as the server.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Check collation
-------------------------------------------------------------------------------
DECLARE @ServerCollation VARCHAR(50);
DECLARE @DBCollation VARCHAR(50);

SELECT
  @ServerCollation = CONVERT(VARCHAR(50), SERVERPROPERTY('Collation')),
  @DBCollation = CONVERT(VARCHAR(50), DATABASEPROPERTYEX(DB_NAME(), 'Collation'));

IF (@ServerCollation != @DBCollation)
BEGIN
  PRINT ('Warning: Different Server/Database collation! Server: ' + @ServerCollation + ', Database: ' + @DBCollation);
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Collation.sql' -------- */


--=============================================================================
-- 1. check if database has exactly version of the one-and-only 
--    previous release
--=============================================================================
-- info
PRINT ('Info: ---- 1. Prerequiste - checking previous database version ----');

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @ErrorMessage VARCHAR(MAX);
DECLARE @ReleaseFile VARCHAR(2000);
--
DECLARE @ReleaseNumber VARCHAR(4);
DECLARE @ReleaseNumberMajor VARCHAR(1);
DECLARE @ReleaseNumberMinor VARCHAR(1);
DECLARE @ReleaseNumberRevision VARCHAR(2);
--
DECLARE @PreviousReleaseNumber VARCHAR(4);
DECLARE @CurrentDatabaseVersionNumber VARCHAR(10);

-------------------------------------------------------------------------------
-- set vars
-------------------------------------------------------------------------------
SET @ReleaseFile = '_Releases\Release 4939\1. Dispatcher\ZH\Dispatcher.sql';
SET @ReleaseFile = ISNULL(@ReleaseFile, '????');

-------------------------------------------------------------------------------
-- check release-file-content
-------------------------------------------------------------------------------
IF (@ReleaseFile NOT LIKE '%\Release ____\%')
BEGIN
  SET @ErrorMessage = 'Error: Invalid @ReleaseFile value ("' + @ReleaseFile + '"), cannot parse current release number.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: @ReleaseFile="' + @ReleaseFile + '".');

-------------------------------------------------------------------------------
-- getting release-number from release-file
-------------------------------------------------------------------------------
SET @ReleaseNumber = SUBSTRING(@ReleaseFile, CHARINDEX('\Release ', @ReleaseFile, 0) + 9, 4);
SET @ReleaseNumber = ISNULL(@ReleaseNumber, '4939')

-- KiSS5000 check
IF (@ReleaseNumber = '5000')
BEGIN
  -- info
  PRINT ('Info: Detected new KiSS-5000 release, skipping version checks.');
  
  -- do not perform check for this version
  GOTO DONEFIRST;
  RETURN;
END;

-- validate
IF (@ReleaseNumber NOT LIKE '4___')
BEGIN
  SET @ErrorMessage = 'The current release number "' + @ReleaseNumber + '" from @ReleaseFile does not match the expected pattern.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- parse
SELECT @ReleaseNumberMajor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 1, 1),
       @ReleaseNumberMinor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 2, 1),
       @ReleaseNumberRevision = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 3, 2);

-- info
PRINT ('Info: Detected release number "' + @ReleaseNumberMajor + '.' + @ReleaseNumberMinor + '.' + @ReleaseNumberRevision + '" for current release.');

-------------------------------------------------------------------------------
-- calc previous release number for database
-------------------------------------------------------------------------------
SET @PreviousReleaseNumber =  CASE @ReleaseNumber 
                                WHEN '4644' THEN '4632'
                                WHEN '4709' THEN '4644'
                                WHEN '4731' THEN '4709'
                                WHEN '4741' THEN '4731'
                                WHEN '4806' THEN '4741'
                                WHEN '4829' THEN '4806'
                                WHEN '4839' THEN '4829'
                                WHEN '4906' THEN '4839'
                                WHEN '4929' THEN '4906'
                                WHEN '4939' THEN '4929'
                                ELSE '????'
                              END;

SET @PreviousReleaseNumber = ISNULL(@PreviousReleaseNumber, '????');

-- validate
IF (@PreviousReleaseNumber NOT LIKE '4___')
BEGIN
  SET @ErrorMessage = 'The calculated version "' + @PreviousReleaseNumber + '" for previous database release does not match the expected pattern.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: Calculated expected previous database version "' + @PreviousReleaseNumber + '".');

-------------------------------------------------------------------------------
-- get current database version
-------------------------------------------------------------------------------
SELECT @CurrentDatabaseVersionNumber = CONVERT(VARCHAR, DBV.MajorVersion) +
                                       CONVERT(VARCHAR, DBV.MinorVersion) +
                                       CASE 
                                         WHEN LEN(CONVERT(VARCHAR, DBV.Build)) = 1 THEN '0' + CONVERT(VARCHAR, DBV.Build)
                                         ELSE CONVERT(VARCHAR, DBV.Build)
                                       END
FROM dbo.XDBVersion DBV WITH (READUNCOMMITTED)
WHERE DBV.XDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID();

SET @CurrentDatabaseVersionNumber = ISNULL(@CurrentDatabaseVersionNumber, '????');

-- info
PRINT ('Info: Current database version "' + @CurrentDatabaseVersionNumber + '".');

-------------------------------------------------------------------------------
-- check if last database version is the calculated previous version
-------------------------------------------------------------------------------
IF (@CurrentDatabaseVersionNumber <> @PreviousReleaseNumber)
BEGIN
  SET @ErrorMessage = 'The current database version does not match with the expected value (current="' + @CurrentDatabaseVersionNumber + '", expected="' + @PreviousReleaseNumber + '"). Please take the release script that matches with your current database version.';
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
  RETURN;
END;

-- info
PRINT ('Info: Database version is valid - continue with release script.');

-------------------------------------------------------------------------------
-- done info
-------------------------------------------------------------------------------
DONEFIRST:
PRINT ('Info: ---- 1. Prerequiste - done ----');
GO

--=============================================================================
-- 2. ...
--=============================================================================
-- TODO: Maybe we can check NSE ($NSE) so that a releasescript for one customer cannot be executed for another customer --> store $NSE in XDBVersion table.
GO

--=============================================================================
-- 3. ...
--=============================================================================
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Check_Prerequisites_For_ReleaseScript.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update document handling object with its proper database 
           information.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- view: XDocument (only SepDocDB!)
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\SepDocDB\XDocument.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\SepDocDB\XDocument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
IF EXISTS(SELECT TOP 1 1 FROM SYSOBJECTS WHERE name LIKE 'XDocument' AND xtype LIKE 'V')
BEGIN
  DROP VIEW dbo.XDocument
END
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
  $Author: Lloreggia $
  $Modtime: 23.12.09 17:06 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this view, if XDocument is located in a different DB
  -
  ATTENTION: - KISS4_BSS_MasterDev_DOC.dbo.XDocument have to be modified für different customers !!!
             - Do not insert this view if table XDocument already exists on same database !!!
  -
  RETURNS: all fields of table XDocument.
  -
  TEST:    SELECT * from dbo.XDocument
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Views/XDocument.sql $
 * 
 * 13    23.12.09 17:06 Lloreggia
 * Übernahme der Änderungen aus dem Branch 4.1.48
 * 
 * 12    13.11.09 15:38 Lloreggia
 * Updated to latest version (DB creation script working)
 * 
 * 11    2.09.09 7:55 Nweber
 * #4932: Dokumenten DB-Name mit KiSS_ZH_DEV_R4939_DOC ersetzen für das neue
 * Release-Tool
 * 
 * 10    25.06.09 13:07 Ckaeser
 * Alter2Create
 * 
 * 9     18.06.09 15:23 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 8     18.06.09 14:00 Rhesterberg
 * #2499: Gleichzeitige Bearbeitung von Dokumenten (Locking)
 * 
 * 7     17.06.09 17:03 Cjaeggi
 * #2499: Gleichzeitige Bearbeitung von Dokumenten
=================================================================================================*/

CREATE VIEW [dbo].[XDocument]
AS 

SELECT 
  DocumentID, DateCreation, UserID_Creator,
  FileBinary, DocFormatCode, FileExtension, DocReadOnly, DocTemplateID, XDocumentTS, 
  UserID_LastRead, DateLastRead, UserID_LastSave, DateLastSave, 
  DocTypeCode, DocTemplateName, 
  CheckOut_UserID, CheckOut_Date, CheckOut_Filename, CheckOut_Machine
FROM KiSS_ZH_DEV_R4939_DOC.dbo.XDocument
--@@TODO ???

GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\SepDocDB\XDocument.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\SepDocDB\XDocument.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- spXDocument_Lock
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_Lock;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-lock specific document for other users
    @DocumentID:          ID of either XDocument or XDocTemplate
    @CheckOutUserID:      The user id who locks the document
    @CheckoutFilename:    The local filename including path of locked document
    @CheckoutMachinename: The name of the computer of the user who locks the document
    @IsTemplate:          Is it a template? TRUE = locks XDocTemplate, FALSE = locks XDocument
  -
  RETURNS: Nothing or in case of error the error-code used for mulitlanguage message
=================================================================================================
  TEST:    EXEC dbo.spXDocument_Lock -1, -1, NULL, NULL, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_Lock
(
  @DocumentID INT,
  @CheckoutUserID INT,
  @CheckoutFilename VARCHAR(MAX),
  @CheckoutMachinename VARCHAR(MAX),
  @IsTemplate BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR ISNULL(@CheckOutUserID, -1) < 1 
      OR @CheckoutFilename IS NULL OR @CheckoutMachinename IS NULL
      OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('LockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- vars II.
  -----------------------------------------------------------------------------
  -- declare vars
  DECLARE @tmpCheckoutUserID INT;
  DECLARE @tmpCheckoutDate DATETIME;
  DECLARE @tmpUserName VARCHAR(200);
  DECLARE @tmpCheckoutFilename VARCHAR(MAX);
  DECLARE @tmpCheckoutMachinename VARCHAR(MAX);
  
  -----------------------------------------------------------------------------
  -- get current checked-out values
  -- ensure transaction was started from outer call of stored procedure
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    -- using XDocTemplate
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocTemplate DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    -- using table XDocument by using view XDocument
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocument DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocumentID = @DocumentID;
  END;
  
  -----------------------------------------------------------------------------
  -- check for existing chekcouts
  -----------------------------------------------------------------------------
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID != @CheckoutUserID)
  BEGIN
    -- file locked by other user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByAnotherUser' , 18, 1);
    RETURN;
  END
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID = @CheckoutUserID)
  BEGIN
    -- file locked by the actual user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByActualUser' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- no error occured, lock the document
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocTemplate
    --
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate 
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocumentID = @DocumentID;
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_Lock.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- spXDocument_UnLock
-------------------------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_UnLock;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-unlock specific document for other users
    @DocumentID: ID of either XDocument or XDocTemplate
    @IsTemplate: Is it a template? TRUE = unlocks XDocTemplate, FALSE = unlocks XDocument-
  RETURNS: Nothing or in case of error the errormessage
=================================================================================================
  TEST:    EXEC dbo.spXDocument_UnLock -1, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_UnLock
(
  @DocumentID INT,
  @IsTemplate BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('UnLockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- unlock documents
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocTemplate
    -- 
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocumentID = @DocumentID;
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXDocument_UnLock.sql' -------- */

GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_DocumentHandling.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to (re)create aggregate functions on database (x86 and x64).
           This script needs some extra rights and should be executed with sysadmin rights.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- drop functions first
-------------------------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1 FROM sysobjects WHERE Type = 'AF' AND [Name] = 'Conc'))
BEGIN
  DROP AGGREGATE [dbo].[Conc];
  DROP AGGREGATE [dbo].[ConcDistinct];
  DROP AGGREGATE [dbo].[ConcDistinctOrder];
  DROP ASSEMBLY [StringConcatenate];
END;

-------------------------------------------------------------------------------------------------
-- create assembly
-------------------------------------------------------------------------------------------------
IF (@@VERSION LIKE '%X64)%')
BEGIN
  -- Assembly erstellen für x64
  CREATE ASSEMBLY [StringConcatenate]
  AUTHORIZATION [dbo]
  FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A24000000000000005045000064860200FF13054B0000000000000000F00022200B0208000010000000100000000000000000000000200000000040000000000000200000001000000400000000000000040000000000000000600000001000000000000003004085000040000000000000400000000000000000100000000000002000000000000000000000100000000000000000000000000000000000000000400000A803000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000004800000000000000000000002E74657874000000E00C0000002000000010000000100000000000000000000000000000200000602E72737263000000A8030000004000000010000000200000000000000000000000000000400000402E72656C6F630000000000000060000000000000003000000000000000000000000000004000004200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004800000002000500A8220000380A0000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003202731000000A7D010000042ADE0F01281100000A2C012A027B010000040F01FE16040000016F1200000A6F1300000A2D12027B010000040F01281400000A6F1500000A2A4E027B010000040F017B010000046F1600000A2A9A027B010000046F1700000A7201000070027B010000046F1800000A281900000A281A00000A2A13300500240000000100001102036F1B00000A178D1C0000010A06161F2C9D066F1C00000A731D00000A7D010000042A9E027B010000046F1700000A037201000070027B010000046F1800000A281900000A6F1E00000A2A3202731000000A7D020000042ADE0F01281100000A2C012A027B020000040F01FE16040000016F1200000A6F1300000A2D12027B020000040F01281400000A6F1500000A2A4E027B020000040F017B020000046F1600000A2A6E7201000070027B020000046F1800000A281900000A281A00000A2A00000013300500240000000100001102036F1B00000A178D1C0000010A06161F2C9D066F1C00000A731D00000A7D020000042A72037201000070027B020000046F1800000A281900000A6F1E00000A2A3202731F00000A7D030000042A960F01281100000A2C012A027B030000040F01281400000A6F2000000A1F2C6F2100000A262A52027B030000040F017B030000046F2200000A262A000000133004003D000000020000117E2300000A0A027B030000042C28027B030000046F2400000A16311A027B0300000416027B030000046F2400000A17596F2500000A0A06732600000A2A4A02036F1B00000A732700000A7D030000042A4A03027B030000046F1200000A6F1E00000A2A0042534A4201000100000000000C00000076322E302E35303732370000000005006C00000018040000237E000084040000F803000023537472696E6773000000007C08000008000000235553008408000010000000234755494400000094080000A401000023426C6F620000000000000002000001571702080900000000FA013300160000010000001C0000000400000003000000120000000C00000003000000270000000D0000000200000001000000010000000200000000000A0001000000000006004C0045000A007D0062000600A9008E000A00DD00C80006000C01020106001E01020106003D01310106005D014B0106009B017C010600AF014B010600C8014B010600E3014B010600FE014B01060017024B01060030024B0106004F024B0106006C024B010600A30283020600C30283020600EB0245000A00010362000A0022036200060029037C0106003F037C0106005B034500060088038E000600AC0345000600D103450000000000010000000000010001000921100018000000050001000100092110002A0000000500020007000921100037000000050003000D000100B0000A000100B0000A000100B00038005020000000008600C300110001005D20000000008600E700150001009520000000008600F2001B000200A920000000008600F80021000300D02000000000E601190126000300002100000000E6012B012C0004002821000000008600C300110005003521000000008600E700150005006D21000000008600F200320006008121000000008600F80021000700A02100000000E601190126000700D02100000000E6012B012C000800ED21000000008600C30011000900FA21000000008600E700150009002022000000008600F2003C000A003822000000008600F80021000B00812200000000E601190126000B00942200000000E6012B012C000C00000001004A0300000100820300000100C40300000100DC03000001004A0300000100820300000100C40300000100DC03000001004A0300000100820300000100C40300000100DC03020009000300090004000900410076014200490076014700510076014200590076014200610076014200690076014200710076014200790076014200810076014200890076014200910076014C00990076011100A10076011100A90076015100B9007601B9000C007601110021005003C500C9006203C9000C006B03CD0021007403C9000C007E03D3000C009603D9000C009F0311000C00A403E300D900B303E9002100B803F0002900C603C900D900D603F6000C007601D90031002B0142003900760111003900DE0302013900DE0308013900DE030E01D900E50314013900EB031701390062031B012100760142003900760142002E00330055012E00630085012E00130025012E00230025012E002B002B012E003B0064012E00430025012E004B0025012E00530055012E005B007C01430073005700630073005700830073005700FD002101BF0004800000010000001A0EC74B000000000000E102000002000000000000000000000001003C0000000000020000000000000000000000010056000000000000000000003C4D6F64756C653E004167677265676174652E646C6C00436F6E6344697374696E63744F7264657200436F6E6344697374696E637400436F6E63006D73636F726C69620053797374656D0056616C7565547970650053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E536572766572004942696E61727953657269616C697A650053797374656D2E436F6C6C656374696F6E732E47656E65726963004C697374603100696E7465726D656469617465526573756C7400496E69740053797374656D2E446174612E53716C54797065730053716C537472696E6700416363756D756C617465004D65726765005465726D696E6174650053797374656D2E494F0042696E61727952656164657200526561640042696E6172795772697465720057726974650053797374656D2E5465787400537472696E674275696C6465720053797374656D2E5265666C656374696F6E00417373656D626C7956657273696F6E417474726962757465002E63746F720053797374656D2E52756E74696D652E496E7465726F70536572766963657300436F6D56697369626C6541747472696275746500417373656D626C7943756C7475726541747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C795469746C654174747269627574650053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465004167677265676174650053657269616C697A61626C654174747269627574650053716C55736572446566696E656441676772656761746541747472696275746500466F726D6174005374727563744C61796F7574417474726962757465004C61796F75744B696E640076616C7565006765745F49734E756C6C004F626A65637400546F537472696E6700436F6E7461696E73006765745F56616C756500416464006F746865720049456E756D657261626C6560310041646452616E676500536F727400546F417272617900537472696E67004A6F696E006F705F496D706C6963697400720052656164537472696E6700436861720053706C6974007700417070656E6400456D707479006765745F4C656E67746800000000032C000000000053D11236BE48D2419BD3042636AA6F140008B77A5C561934E089060615120D010E03200001052001011111052001011108042000111105200101121505200101121905200101110C0306121D052001011110042001010E042001010204200101080520010111596101000200000004005402124973496E76617269616E74546F4E756C6C73015402174973496E76617269616E74546F4475706C696361746573005402124973496E76617269616E74546F4F726465720054080B4D61784279746553697A65401F00000520010111610515120D010E032000020320000E052001021300052001011300092001011512690113000520001D13000600020E0E1D0E05000111110E0620011D0E1D030407011D03052001121D0E052001121D03052001121D1C02060E032000080520020E08080307010E05010000000029010024436F7079726967687420C2A920426F726E20496E666F726D6174696B204147203230303800000E010009416767726567617465000017010012426F726E20496E666F726D6174696B20414700000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F7773010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001000000018000080000000000000000000000000000001000100000030000080000000000000000000000000000001000000000048000000584000004C03000000000000000000004C0334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE0000010000000100C74B1A0E00000100C74B1A0E3F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004AC020000010053007400720069006E006700460069006C00650049006E0066006F00000088020000010030003000300030003000340062003000000048001300010043006F006D00700061006E0079004E0061006D0065000000000042006F0072006E00200049006E0066006F0072006D006100740069006B00200041004700000000003C000A000100460069006C0065004400650073006300720069007000740069006F006E0000000000410067006700720065006700610074006500000040000F000100460069006C006500560065007200730069006F006E000000000031002E0030002E0033003600310030002E0031003900330039003900000000003C000E00010049006E007400650072006E0061006C004E0061006D00650000004100670067007200650067006100740065002E0064006C006C0000006C00240001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A900200042006F0072006E00200049006E0066006F0072006D006100740069006B0020004100470020003200300030003800000044000E0001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000004100670067007200650067006100740065002E0064006C006C00000034000A000100500072006F0064007500630074004E0061006D00650000000000410067006700720065006700610074006500000044000F000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0033003600310030002E00310039003300390039000000000048000F00010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0033003600310030002E0031003900330039003900000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
  WITH PERMISSION_SET = SAFE;
END;
ELSE
BEGIN
  -- Assembly erstellen für x86
  CREATE ASSEMBLY [StringConcatenate]
  AUTHORIZATION [dbo]
  FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C0103000FEB254B0000000000000000E00002210B010800001000000020000000000000AE2E00000020000000400000000040000020000000100000040000000000000004000000000000000080000000100000000000000300408500001000001000000000100000100000000000001000000000000000000000005C2E00004F00000000400000A803000000000000000000000000000000000000006000000C000000CC2D00001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000B40E0000002000000010000000100000000000000000000000000000200000602E72737263000000A8030000004000000010000000200000000000000000000000000000400000402E72656C6F6300000C00000000600000001000000030000000000000000000000000000040000042000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000902E000000000000480000000200050028230000A40A00000300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000360002731100000A7D010000042A0000133002002C00000001000011000F01281200000A16FE010A062D022B1A027B010000040F01281300000A6F1400000A1F2C6F1500000A262A5600027B010000040F017B010000046F1600000A262A0000133004004C00000002000011007E1700000A0A027B010000042C13027B010000046F1800000A16FE0216FE012B01170C082D1A027B0100000416027B010000046F1800000A17596F1900000A0A06731A00000A0B2B00072A4E0002036F1B00000A731C00000A7D010000042A520003027B010000046F1D00000A6F1E00000A002A360002731F00000A7D020000042A00133002004100000001000011000F01281200000A16FE010A062D022B2F027B020000040F01FE16040000016F1D00000A6F2000000A0A062D13027B020000040F01281300000A6F2100000A002A5600027B020000040F017B020000046F2200000A002A00133002002000000003000011007201000070027B020000046F2300000A282400000A282500000A0A2B00062A1330050025000000040000110002036F1B00000A178D1E0000010A06161F2C9D066F2600000A732700000A7D020000042A7A00037201000070027B020000046F2300000A282400000A6F1E00000A002A360002731F00000A7D030000042A0000133002004100000001000011000F01281200000A16FE010A062D022B2F027B030000040F01FE16040000016F1D00000A6F2000000A0A062D13027B030000040F01281300000A6F2100000A002A5600027B030000040F017B030000046F2200000A002A00133002002C0000000300001100027B030000046F2800000A007201000070027B030000046F2300000A282400000A282500000A0A2B00062A1330050025000000040000110002036F1B00000A178D1E0000010A06161F2C9D066F2600000A732700000A7D030000042AAA00027B030000046F2800000A00037201000070027B030000046F2300000A282400000A6F1E00000A002A42534A4201000100000000000C00000076322E302E35303732370000000005006C00000034040000237E0000A00400002C04000023537472696E677300000000CC0800000800000023555300D4080000100000002347554944000000E4080000C001000023426C6F620000000000000002000001571702080900000000FA013300160000010000001E0000000400000003000000120000000C00000003000000280000000E0000000400000001000000010000000200000000000A0001000000000006004C0045000A007D00620006009A008E000A00D500C00006000401FA0006001601FA0006004401290106005D014B0106009B017C010600AF014B010600C8014B010600E3014B010600FE014B01060017024B01060030024B0106004F024B0106006C024B010600960283024B00AA0200000600D902B9020600F902B9020600210345000A00370362000A005803620006005F037C01060075037C010600A80345000600D80345000600EC03290106001C04450000000000010000000000010001000921100018000000050001000100092110001D000000050002000700092110002A000000050003000D000100A8000A000100A8002F000100A8002F005020000000008600BB000E0001006020000000008600DF00120001009820000000008600EA0018000200B020000000008600F0001E000300082100000000E6011101230003001C2100000000E6012301290004003121000000008600BB000E0005004021000000008600DF00120005008D21000000008600EA0036000600A421000000008600F0001E000700D02100000000E601110123000700012200000000E6012301290008002022000000008600BB000E0009003022000000008600DF00120009007D22000000008600EA003C000A009422000000008600F0001E000B00CC2200000000E601110123000B00FD2200000000E601230129000C0000000100800300000100A20300000100C90300000100D60300000100800300000100A20300000100C90300000100D60300000100800300000100A20300000100C90300000100D603020009000300090004000900410076014200490076014700510076014200590076014200610076014200690076014200710076014200790076014200810076014200890076014200910076014C00A10076015200A90076010E00B10076010E00B90076015700C9007601BF00190076010E0021008603C50021009103C90019009B03CD0019009B03D30019009B03DD00D900AF03E3001900B503E6001900C003EA002100760142002900CB03C900190076014200E100C003C9003100230142000C0076010E000C00DF03FD000C00E80303010C00FA0309010C0003041301D9000B041901210010042001D90021042B010C00760109010C0027040E002E00330067012E003B0076012E00630097012E00130037012E00230037012E002B003D012E006B00A0012E00430037012E004B0037012E00530067012E005B008E0143007B005D0063007B005D0083007B005D00D900F00026013201F7000480000001000000330E8F3C0000000000001703000002000000000000000000000001003C0000000000020000000000000000000000010056000000000000000000003C4D6F64756C653E004167677265676174652E646C6C00436F6E6300436F6E6344697374696E637400436F6E6344697374696E63744F72646572006D73636F726C69620053797374656D0056616C7565547970650053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E536572766572004942696E61727953657269616C697A650053797374656D2E5465787400537472696E674275696C64657200696E7465726D656469617465526573756C7400496E69740053797374656D2E446174612E53716C54797065730053716C537472696E6700416363756D756C617465004D65726765005465726D696E6174650053797374656D2E494F0042696E61727952656164657200526561640042696E6172795772697465720057726974650053797374656D2E436F6C6C656374696F6E732E47656E65726963004C69737460310053797374656D2E5265666C656374696F6E00417373656D626C7956657273696F6E417474726962757465002E63746F720053797374656D2E52756E74696D652E496E7465726F70536572766963657300436F6D56697369626C6541747472696275746500417373656D626C7943756C7475726541747472696275746500417373656D626C7954726164656D61726B41747472696275746500417373656D626C79436F7079726967687441747472696275746500417373656D626C7950726F6475637441747472696275746500417373656D626C79436F6D70616E7941747472696275746500417373656D626C79436F6E66696775726174696F6E41747472696275746500417373656D626C794465736372697074696F6E41747472696275746500417373656D626C795469746C654174747269627574650053797374656D2E446961676E6F73746963730044656275676761626C6541747472696275746500446562756767696E674D6F6465730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C697479417474726962757465004167677265676174650053657269616C697A61626C654174747269627574650053716C55736572446566696E656441676772656761746541747472696275746500466F726D6174005374727563744C61796F7574417474726962757465004C61796F75744B696E640076616C7565006765745F49734E756C6C006765745F56616C756500417070656E64006F7468657200537472696E6700456D707479006765745F4C656E67746800546F537472696E6700720052656164537472696E670077004F626A65637400436F6E7461696E73004164640049456E756D657261626C6560310041646452616E676500546F4172726179004A6F696E006F705F496D706C6963697400436861720053706C697400536F72740000032C0000000000E6B47244306DD344864147A778C26E550008B77A5C561934E0890306120D032000010520010111110520010111080420001111052001011215052001011219060615121D010E05200101110C052001011110042001010E042001010205200101114D04200101080520010111616101000200000004005402124973496E76617269616E74546F4E756C6C73015402174973496E76617269616E74546F4475706C696361746573005402124973496E76617269616E74546F4F726465720054080B4D61784279746553697A65401F0000052001011169032000020320000E052001120D0E052001120D0303070102052001120D1C02060E032000080520020E08080607030E1111020515121D010E052001021300052001011300092001011512750113000520001D13000600020E0E1D0E05000111110E04070111110620011D0E1D030407011D0305010000000029010024436F7079726967687420C2A920426F726E20496E666F726D6174696B204147203230303800000E010009416767726567617465000017010012426F726E20496E666F726D6174696B20414700000801000701000000000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F77730100000000000FEB254B000000000200000071000000E82D0000E81D0000525344534913C6E99C6C6A469A3E7C4FAF2672B501000000433A5C50726F6A656374735C4B69535334305C546F6F6C735C55736572446566696E656446756E6374696F6E735C554446735C4167677265676174655C6F626A5C7838365C44656275675C4167677265676174652E70646200000000842E000000000000000000009E2E0000002000000000000000000000000000000000000000000000902E0000000000000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF25002040000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001001000000018000080000000000000000000000000000001000100000030000080000000000000000000000000000001000000000048000000584000004C03000000000000000000004C0334000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000001008F3C330E000001008F3C330E3F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004AC020000010053007400720069006E006700460069006C00650049006E0066006F00000088020000010030003000300030003000340062003000000048001300010043006F006D00700061006E0079004E0061006D0065000000000042006F0072006E00200049006E0066006F0072006D006100740069006B00200041004700000000003C000A000100460069006C0065004400650073006300720069007000740069006F006E0000000000410067006700720065006700610074006500000040000F000100460069006C006500560065007200730069006F006E000000000031002E0030002E0033003600330035002E0031003500350030003300000000003C000E00010049006E007400650072006E0061006C004E0061006D00650000004100670067007200650067006100740065002E0064006C006C0000006C00240001004C006500670061006C0043006F007000790072006900670068007400000043006F0070007900720069006700680074002000A900200042006F0072006E00200049006E0066006F0072006D006100740069006B0020004100470020003200300030003800000044000E0001004F0072006900670069006E0061006C00460069006C0065006E0061006D00650000004100670067007200650067006100740065002E0064006C006C00000034000A000100500072006F0064007500630074004E0061006D00650000000000410067006700720065006700610074006500000044000F000100500072006F006400750063007400560065007200730069006F006E00000031002E0030002E0033003600330035002E00310035003500300033000000000048000F00010041007300730065006D0062006C0079002000560065007200730069006F006E00000031002E0030002E0033003600330035002E0031003500350030003300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000B03E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
  WITH PERMISSION_SET = SAFE;
END;

-------------------------------------------------------------------------------------------------
-- link functions to assemby
-------------------------------------------------------------------------------------------------
-- User-defined functions (UDF) erstellen
CREATE AGGREGATE [dbo].[Conc]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[Conc];

CREATE AGGREGATE [dbo].[ConcDistinct]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[ConcDistinct];

CREATE AGGREGATE [dbo].[ConcDistinctOrder]
(@input [nvarchar](200))
RETURNS[nvarchar](4000)
EXTERNAL NAME [StringConcatenate].[ConcDistinctOrder];
GO

-------------------------------------------------------------------------------------------------
-- config server
-------------------------------------------------------------------------------------------------
EXEC sp_configure 'clr enabled', 1;
GO

RECONFIGURE WITH OVERRIDE
PRINT 'RECONFIGURE has been executed.';
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_AggregateFunc_x86_x64.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply only required rights to KiSS database user 
           (kiss3, kiss, kiss4_pi, ...)
           
  HINTS:   - To fix on changes, too: /Database/Scripts/Automation/ApplySecurityToDatabases.sql
           - Prevent adding any GOs for easy copy into script above
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @RoleNameBookmarksOnly SYSNAME;
DECLARE @RoleNameExecutor SYSNAME;
DECLARE @RoleNameDefinitionViewer SYSNAME;
--
DECLARE @RoleName SYSNAME;
DECLARE @RoleMemberName SYSNAME;
--
DECLARE @SqlStatement NVARCHAR(1000);
DECLARE @UserSchemaName NVARCHAR(255);

SET @RoleNameBookmarksOnly = N'KiSS_BookmarksOnly';
SET @RoleNameExecutor = N'KiSS_db_executor';
SET @RoleNameDefinitionViewer = N'KiSS_db_definition_viewer';

-------------------------------------------------------------------------------------------------
-- validate bookmarks role, set owner to dbo if current user is assigned
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleNameBookmarksOnly
              AND type = 'R'
              AND owning_principal_id = USER_ID('kiss3')))
BEGIN
  -- change owner of role to dbo
  SET @SqlStatement = 'ALTER AUTHORIZATION ON ROLE::[' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '] TO [dbo];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Changed owner of role "' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '" to "dbo"');
END;

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_executor
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameExecutor;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT EXECUTE TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_definition_viewer
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameDefinitionViewer;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT VIEW DEFINITION TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- setup rights
-------------------------------------------------------------------------------------------------
---------------------------------------
-- remove user from role <db_owner>
---------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_role_members       RM
              INNER JOIN sys.database_principals U  ON U.principal_id = RM.member_principal_id
                                                   AND U.name = 'kiss3'
              INNER JOIN sys.database_principals R  ON R.principal_id = RM.role_principal_id
                                                   AND R.name = 'db_owner'))
BEGIN
  -- drop it
  EXEC sp_droprolemember 'db_owner', 'kiss3';

  -- info
  PRINT ('Info: Removed user "kiss3" from db_owner rights members');
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss3" is not member of role "db_owner"');
END;

---------------------------------------
-- drop and recreate user for login
---------------------------------------
-- check if need to drop first
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss3'
             AND type = N'S'))
BEGIN
  -- check if user owns a schema
  SELECT @UserSchemaName = SCH.name
  FROM sys.database_principals DBP
    INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
  WHERE DBP.name = N'kiss3'
    AND DBP.type = N'S';
  
  IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, changing owner of schema "' + @UserSchemaName + '" to [dbo].');
      
    -- change owner of schema
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [dbo];';
    EXEC sp_executesql @SqlStatement;
  END;
  
  -- info
  PRINT ('Info: Drop assignment of user "kiss3"');

  -- drop assignment of kiss3 user
  DROP USER [kiss3];
END;

-- create KiSS user for login
CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA = [dbo];

-- info
PRINT ('Info: Created user "kiss3" for login on database');

IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, rechanging owner of schema "' + @UserSchemaName + '" with owner [dbo] back to "kiss3".');
     
    -- rechange owner of schema to SqlUserName
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [kiss3];';
    EXEC sp_executesql @SqlStatement;
  END;


---------------------------------------
-- add KiSS user to specific members
---------------------------------------
-- public roles
EXEC sp_addrolemember 'db_datareader', 'kiss3';
EXEC sp_addrolemember 'db_datawriter', 'kiss3';

-- KiSS roles
EXEC sp_addrolemember @RoleNameExecutor, 'kiss3';
EXEC sp_addrolemember @RoleNameDefinitionViewer, 'kiss3';

-- add required/restrict rights (e.g. for INDENTITY_INSERTs)
GRANT ALTER ANY SCHEMA TO [kiss3];
DENY CREATE SCHEMA TO [kiss3];

USE [master];
GO
BEGIN TRY
  GRANT EXECUTE ON sys.xp_msver TO [kiss3];
END TRY
BEGIN CATCH
  PRINT ('Warning: Could not grant rights on sys.xp_msver to kiss3!')
END CATCH;
GO
USE [KiSS_ZH_DEV_R4939];
GO

-- info
PRINT ('Info: Added user "kiss3" as member to specific roles');
PRINT ('');
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply the bookmark user to database
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

----------------------------------------------------------------------------
-- remove kiss_bm if existing
----------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO

IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Drop user "kiss_bm" on database');
  
  -- drop
  DROP USER [kiss_bm];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss_bm" not found on database');
END;
GO

----------------------------------------------------------------------------
-- create login on server if not existing yet
----------------------------------------------------------------------------
USE [master];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.server_principals
               WHERE name = 'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Create login "kiss_bm" on server');
  
  -- create login
  CREATE LOGIN [kiss_bm] WITH PASSWORD=N'textmarken88$', DEFAULT_DATABASE=[KiSS_ZH_DEV_R4939], CHECK_EXPIRATION=OFF;
END
ELSE
BEGIN
  -- info
  PRINT ('Info: Login "kiss_bm" already exists on server');
END;
GO

----------------------------------------------------------------------------
-- create user on database if not existing yet
----------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sysusers
               WHERE name = 'kiss_bm'))
BEGIN
  -- info
  PRINT ('Info: Create user "kiss_bm" on database');
  
  -- create user
  CREATE USER [kiss_bm] FOR LOGIN [kiss_bm];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss_bm" already exists on database');
END;
GO

----------------------------------------------------------------------------
-- create role on database if not existing yet
----------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO

IF (NOT EXISTS(SELECT TOP 1 1
               FROM sysusers
               WHERE name = 'KiSS_BookmarksOnly'))
BEGIN
  -- info
  PRINT ('Info: Create role "KiSS_BookmarksOnly" on database');
  
  -- create role
  CREATE ROLE [KiSS_BookmarksOnly];
END
ELSE
BEGIN
  -- info
  PRINT ('Info: Role "KiSS_BookmarksOnly" already exists on database');
END;
GO

-- assign role to user
EXEC sp_addrolemember N'KiSS_BookmarksOnly', N'kiss_bm'
GO
GRANT EXECUTE ON [dbo].[spXGetBookmark] TO [KiSS_BookmarksOnly]
GO

----------------------------------------------------------------------------
-- DENY ON SEVERAL SERVER OBJECTS
----------------------------------------------------------------------------
USE [master]
GO

DENY ADMINISTER BULK OPERATIONS TO [kiss_bm]
GO
DENY ALTER ANY CONNECTION TO [kiss_bm]
GO
DENY ALTER ANY CREDENTIAL TO [kiss_bm]
GO
DENY ALTER ANY DATABASE TO [kiss_bm]
GO
DENY ALTER ANY ENDPOINT TO [kiss_bm]
GO
DENY ALTER ANY EVENT NOTIFICATION TO [kiss_bm]
GO
DENY ALTER ANY LINKED SERVER TO [kiss_bm]
GO
DENY ALTER ANY LOGIN TO [kiss_bm]
GO
DENY ALTER RESOURCES TO [kiss_bm]
GO
DENY ALTER SERVER STATE TO [kiss_bm]
GO
DENY ALTER SETTINGS TO [kiss_bm]
GO
DENY ALTER TRACE TO [kiss_bm]
GO
DENY AUTHENTICATE SERVER TO [kiss_bm]
GO
DENY CREATE ANY DATABASE TO [kiss_bm]
GO
DENY CREATE DDL EVENT NOTIFICATION TO [kiss_bm]
GO
DENY CREATE ENDPOINT TO [kiss_bm]
GO
DENY CREATE TRACE EVENT NOTIFICATION TO [kiss_bm]
GO
DENY EXTERNAL ACCESS ASSEMBLY TO [kiss_bm]
GO
DENY SHUTDOWN TO [kiss_bm]
GO
DENY UNSAFE ASSEMBLY TO [kiss_bm]
GO
DENY VIEW ANY DATABASE TO [kiss_bm]
GO
GRANT VIEW ANY DEFINITION TO [kiss_bm]
GO
DENY VIEW SERVER STATE TO [kiss_bm]
GO

----------------------------------------------------------------------------
-- after all, switch back to original database
----------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_BookmarkUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select optional document database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939_DOC') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939_DOC'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
-- use document database (name must be given all the time, if no document database exists, use default database)
USE [KiSS_ZH_DEV_R4939_DOC];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply only required rights to KiSS database user 
           (kiss3, kiss, kiss4_pi, ...)
           
  HINTS:   - To fix on changes, too: /Database/Scripts/Automation/ApplySecurityToDatabases.sql
           - Prevent adding any GOs for easy copy into script above
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @RoleNameBookmarksOnly SYSNAME;
DECLARE @RoleNameExecutor SYSNAME;
DECLARE @RoleNameDefinitionViewer SYSNAME;
--
DECLARE @RoleName SYSNAME;
DECLARE @RoleMemberName SYSNAME;
--
DECLARE @SqlStatement NVARCHAR(1000);
DECLARE @UserSchemaName NVARCHAR(255);

SET @RoleNameBookmarksOnly = N'KiSS_BookmarksOnly';
SET @RoleNameExecutor = N'KiSS_db_executor';
SET @RoleNameDefinitionViewer = N'KiSS_db_definition_viewer';

-------------------------------------------------------------------------------------------------
-- validate bookmarks role, set owner to dbo if current user is assigned
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleNameBookmarksOnly
              AND type = 'R'
              AND owning_principal_id = USER_ID('kiss3')))
BEGIN
  -- change owner of role to dbo
  SET @SqlStatement = 'ALTER AUTHORIZATION ON ROLE::[' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '] TO [dbo];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Changed owner of role "' + CONVERT(VARCHAR(255), @RoleNameBookmarksOnly) + '" to "dbo"');
END;

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_executor
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameExecutor;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT EXECUTE TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- (re)define new role KiSS_db_definition_viewer
-------------------------------------------------------------------------------------------------
-- apply role
SET @RoleName = @RoleNameDefinitionViewer;

-- ** <dropmembersandrole> **
-- drop role-members
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals 
            WHERE name = @RoleName AND type = 'R'))
BEGIN
  DECLARE Member_Cursor CURSOR FOR
    SELECT [name]
    FROM sys.database_principals 
    WHERE principal_id IN (SELECT member_principal_id 
                            FROM sys.database_role_members 
                            WHERE role_principal_id IN (SELECT principal_id
                                                        FROM sys.database_principals 
                                                        WHERE [name] = @RoleName 
                                                          AND type = 'R'));
  
  OPEN Member_Cursor;
  
  FETCH NEXT FROM Member_Cursor
  INTO @RoleMemberName;
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    EXEC sp_droprolemember @rolename = @RoleName, @membername = @RoleMemberName;
     
    -- info
    PRINT ('Info: Dropped member "' + CONVERT(VARCHAR(255), @RoleMemberName) + '" from role "' + CONVERT(VARCHAR(255), @RoleName) + '"');
  
    FETCH NEXT FROM Member_Cursor
    INTO @RoleMemberName;
  END;
  
  CLOSE Member_Cursor;
  DEALLOCATE Member_Cursor;
END;

-- drop role
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_principals
            WHERE name = @RoleName 
              AND type = 'R'))
BEGIN
  -- drop
  SET @SqlStatement = 'DROP ROLE [' + CONVERT(NVARCHAR(255), @RoleName) + '];';
  EXEC sp_executesql @SqlStatement;
  
  -- info
  PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" dropped');
END;
-- ** </dropmembersandrole> **

-- create role
SET @SqlStatement = 'CREATE ROLE ' + CONVERT(NVARCHAR(255), @RoleName) + '; ' + 
                    'GRANT VIEW DEFINITION TO ' + CONVERT(NVARCHAR(255), @RoleName) + ';';

EXEC sp_executesql @SqlStatement;

-- info
PRINT ('Info: Role "' + CONVERT(VARCHAR(255), @RoleName) + '" created');
PRINT ('');

-------------------------------------------------------------------------------------------------
-- setup rights
-------------------------------------------------------------------------------------------------
---------------------------------------
-- remove user from role <db_owner>
---------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.database_role_members       RM
              INNER JOIN sys.database_principals U  ON U.principal_id = RM.member_principal_id
                                                   AND U.name = 'kiss3'
              INNER JOIN sys.database_principals R  ON R.principal_id = RM.role_principal_id
                                                   AND R.name = 'db_owner'))
BEGIN
  -- drop it
  EXEC sp_droprolemember 'db_owner', 'kiss3';

  -- info
  PRINT ('Info: Removed user "kiss3" from db_owner rights members');
END
ELSE
BEGIN
  -- info
  PRINT ('Info: User "kiss3" is not member of role "db_owner"');
END;

---------------------------------------
-- drop and recreate user for login
---------------------------------------
-- check if need to drop first
IF (EXISTS(SELECT TOP 1 1
           FROM sys.database_principals 
           WHERE name = N'kiss3'
             AND type = N'S'))
BEGIN
  -- check if user owns a schema
  SELECT @UserSchemaName = SCH.name
  FROM sys.database_principals DBP
    INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
  WHERE DBP.name = N'kiss3'
    AND DBP.type = N'S';
  
  IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, changing owner of schema "' + @UserSchemaName + '" to [dbo].');
      
    -- change owner of schema
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [dbo];';
    EXEC sp_executesql @SqlStatement;
  END;
  
  -- info
  PRINT ('Info: Drop assignment of user "kiss3"');

  -- drop assignment of kiss3 user
  DROP USER [kiss3];
END;

-- create KiSS user for login
CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA = [dbo];

-- info
PRINT ('Info: Created user "kiss3" for login on database');

IF (ISNULL(@UserSchemaName, '') <> '')
  BEGIN
    -- info
    PRINT ('Info: User owns a schema, rechanging owner of schema "' + @UserSchemaName + '" with owner [dbo] back to "kiss3".');
     
    -- rechange owner of schema to SqlUserName
    SET @SqlStatement = N'ALTER AUTHORIZATION ON SCHEMA::[' + @UserSchemaName + N'] TO [kiss3];';
    EXEC sp_executesql @SqlStatement;
  END;


---------------------------------------
-- add KiSS user to specific members
---------------------------------------
-- public roles
EXEC sp_addrolemember 'db_datareader', 'kiss3';
EXEC sp_addrolemember 'db_datawriter', 'kiss3';

-- KiSS roles
EXEC sp_addrolemember @RoleNameExecutor, 'kiss3';
EXEC sp_addrolemember @RoleNameDefinitionViewer, 'kiss3';

-- add required/restrict rights (e.g. for INDENTITY_INSERTs)
GRANT ALTER ANY SCHEMA TO [kiss3];
DENY CREATE SCHEMA TO [kiss3];

USE [master];
GO
BEGIN TRY
  GRANT EXECUTE ON sys.xp_msver TO [kiss3];
END TRY
BEGIN CATCH
  PRINT ('Warning: Could not grant rights on sys.xp_msver to kiss3!')
END CATCH;
GO
USE [KiSS_ZH_DEV_R4939];
GO

-- info
PRINT ('Info: Added user "kiss3" as member to specific roles');
PRINT ('');
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDropObject.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDropObject.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------------------------
-- special drop this stored procedure
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.objects 
            WHERE object_id = OBJECT_ID(N'[dbo].[spDropObject]') 
              AND type in (N'P', N'PC')))
BEGIN
  DROP PROCEDURE [dbo].[spDropObject];
  PRINT ('Info: Dropped stored procedure [dbo].[spDropObject]')
END;
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spDropObject
(
  @MainObjectName VARCHAR(776),
  @ObjectName VARCHAR(776) = NULL
)
AS 
BEGIN
  SET NOCOUNT ON;
  
  DECLARE @SQL VARCHAR(512);
  DECLARE @xtype VARCHAR(2);
  
  IF (CHARINDEX('.#', @MainObjectName) > 0 OR CHARINDEX('#', @MainObjectName) = 1)
  BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL THEN 'IX'
                    END
    FROM tempdb..sysobjects        OBJ
      LEFT JOIN tempdb..sysobjects SUB ON SUB.parent_obj = OBJ.id 
                                      AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN tempdb..sysindexes IDX ON IDX.id = OBJ.id 
                                      AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName);
    
    SET @MainObjectName = SUBSTRING(@MainObjectName, CHARINDEX('#', @MainObjectName), 1000);
  END 
  ELSE 
  BEGIN
    SELECT @xtype = CASE
                      WHEN @ObjectName IS NULL THEN OBJ.xtype
                      WHEN SUB.xtype IS NOT NULL THEN SUB.xtype
                      WHEN IDX.id IS NOT NULL THEN 'IX'
                    END
    FROM sysobjects        OBJ
      LEFT JOIN sysobjects SUB ON SUB.parent_obj = OBJ.id 
                              AND SUB.id = OBJECT_ID(@ObjectName)
      LEFT JOIN sysindexes IDX ON IDX.id = OBJ.id 
                              AND IDX.name = @ObjectName
    WHERE OBJ.id = OBJECT_ID(@MainObjectName);
    
    IF (@xtype IN ('U'))
    BEGIN
      SET @SQL = 'EXECUTE spDropTableRef ''' + @MainObjectName + '''';
      EXECUTE (@SQL);
    END;
  END;
  
  SET @SQL = CASE @xtype
               WHEN 'U'  THEN 'DROP TABLE ['     + @MainObjectName + ']'  -- User table
               WHEN 'TR' THEN 'DROP TRIGGER ['   + @MainObjectName + ']'  -- Trigger
               
               WHEN 'V'  THEN 'DROP VIEW ['      + @MainObjectName + ']'  -- View
               
               WHEN 'P'  THEN 'DROP PROCEDURE [' + @MainObjectName + ']'  -- Stored procedure
               
               WHEN 'FN' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Scalar function
               WHEN 'TF' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Table function
               WHEN 'IF' THEN 'DROP FUNCTION ['  + @MainObjectName + ']'  -- Inlined table-function
               
               WHEN 'PK' THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- PrimaryKey
               WHEN 'D'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- Default or DEFAULT constraint
               WHEN 'UQ' THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'
               WHEN 'C'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- CHECK constraint
               
               WHEN 'F'  THEN 'ALTER TABLE ['    + @MainObjectName + '] DROP CONSTRAINT [' + @ObjectName + ']'  -- FOREIGN KEY constraint
               
               WHEN 'IX' THEN 'DROP INDEX '     + @MainObjectName + '.' + @ObjectName
               
               WHEN 'K'  THEN NULL  -- PRIMARY KEY or UNIQUE constraint
               
               WHEN 'L'  THEN NULL  -- Log
               WHEN 'R'  THEN NULL  -- Rule
               WHEN 'RF' THEN NULL  -- replication filter stored procedure
               
               WHEN 'S'  THEN NULL  -- System table
               WHEN 'X'  THEN NULL  -- Extended stored procedure
               
               ELSE NULL
             END;
  
  IF (NOT @SQL IS NULL)
  BEGIN
    PRINT '  - ' + @SQL;
    EXECUTE (@SQL);
  END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDropObject.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDropObject.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_1_PreReleaseDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\1. Dispatcher\ZH\R4939_Dispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\1. Dispatcher\ZH\R4939_Dispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup old migration tables.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- e.g. EXECUTE dbo.spDropObject _Old_FaPhase;
-------------------------------------------------------------------------------
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Cleanup_OldMigrationTables.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_KZH-2241_Update_BaZahlungsweg.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_KZH-2241_Update_BaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to uppercase all IBAN
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
UPDATE BaZahlungsweg SET IBANNummer = UPPER(IBANNummer) WHERE IBANNummer IS NOT NULL
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_KZH-2241_Update_BaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_KZH-2241_Update_BaZahlungsweg.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\1. Dispatcher\ZH\R4939_Dispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\1. Dispatcher\ZH\R4939_Dispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to add a new db version for given release.
=================================================================================================
  TEST: SELECT * FROM dbo.XDBVersion ORDER BY VersionDate, XDBVersionID;
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------------------------
DECLARE @Major INT;
DECLARE @Minor INT;
DECLARE @Build INT;
DECLARE @Revision INT;

DECLARE @BackwardCompatible VARCHAR(25);
DECLARE @VersionDescription VARCHAR(255);

-------------------------------------------------------------------------------------------------
-- define version
-------------------------------------------------------------------------------------------------
-- next release (e.g. 4.3.20)
SET @Major = 4;
SET @Minor = 9;
SET @Build = 39;
SET @Revision = 0;

-- backwards compatible (e.g. 4.3.8)
SET @BackwardCompatible = '4.9.30.0';

-- description (release info: season and year)
SET @VersionDescription = 'Autumn 2017'; -- Spring, Summer, Autumn, Winter

-------------------------------------------------------------------------------------------------
-- insert new db version entry (every time we call this script to have real history)
-- >> no more changes required below, setup version vars only above!
-------------------------------------------------------------------------------------------------
-- description for version
SET @VersionDescription = 'Release ' + CONVERT(VARCHAR(10), @Major) + '.' + 
                                       CONVERT(VARCHAR(10), @Minor) + '.' + 
                                       CONVERT(VARCHAR(10), @Build) + ISNULL(' - ' + @VersionDescription, '');

-- add new entry
EXEC dbo.spXDBVersionAddEntry @MajorVersion = @Major, 
                              @MinorVersion = @Minor, 
                              @Build = @Build, 
                              @Revision = @Revision, 
                              @BackwardCompatibleDownToClientVersion = @BackwardCompatible, 
                              @Description = @VersionDescription, 
                              @UserID = NULL;

-- fix some values
UPDATE DBV
SET DBV.Creator  = 'ReleaseScript',
    DBV.Modifier = 'ReleaseScript',
    DBV.Modified = GETDATE()
FROM dbo.XDBVersion DBV
WHERE DBV.XDBVersionID = dbo.fnXDBVersionGetCurrentDBVersionID();

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Release 4939\2. ChangeScripts\R4939_xxxx_Add_NewDBVersion.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create or update a config value with the name of the actual db.
  This config value is used to prevent Kiss from using a database that is not initialised
  whith a release skript. We want to prevent that the production document database is used
  from the integration environment.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- System Konfigurationswert  System\Allgemein\DbName
-------------------------------------------------------------------------------
DECLARE @CONFIGPATH VARCHAR(MAX);
SET @CONFIGPATH = 'System\Allgemein\DbName';
PRINT ('Checking system configuration value '  + @CONFIGPATH);

DECLARE @CURRENTDBNAME VARCHAR(400);
SET  @CURRENTDBNAME =  'KiSS_ZH_DEV_R4939';  

PRINT ('Current db-name is: ' + @CURRENTDBNAME);

IF (NOT EXISTS (SELECT TOP 1 1 
                FROM dbo.XConfig 
                WHERE KeyPath = @CONFIGPATH))
BEGIN
  PRINT ('Configuration value '  + @CONFIGPATH + ' does not exist. Creating it now.');
  
  INSERT INTO dbo.XConfig 
  (
    KeyPath,
    [System],
    DatumVon,
    ValueCode,
    ValueVarchar,
    [Description],
    OriginalValueVarchar
  )
  VALUES 
  (
    @CONFIGPATH, --KeyPath
    1, -- System: ja
    '01.01.2011', --DatumVon
    1, --ValueCode (1: varchar, 2: int, 3: decimal ...) 
    @CURRENTDBNAME, --ValueVarchar
    ('Name der Datenbank. Beim Einloggen wird geprüft, ob der aktuelle Datenbank-Name mit ' +
     'diesem Wert übereinstimmt. Bei einer Nichtübereinstimmung kann der User nicht einloggen. ' +
     'Damit verhindern wir, dass versehentlich von einer Integrationsumgebung Dokumente auf ' +
     'der Produktionsumgebung mutiert, gelöscht oder eingefügt werden. ' +
     'Der erwartete Wert kann mit dem SQL "SELECT DB_NAME()" herausgefunden werden.'),
    @CURRENTDBNAME --Original Value
  );
END
ELSE
BEGIN
  PRINT ('Configuration value "'  + @CONFIGPATH + '" already exists. Updating it now.'); 
  
  UPDATE dbo.XConfig
  SET ValueVarchar = @CURRENTDBNAME 
  WHERE KeyPath = @CONFIGPATH;
END; 

-------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------
PRINT ('Done with checking "' + @CONFIGPATH + '"');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SetDbNameConfigValue.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup empty extended properties (no content in value or '(null)')
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnName VARCHAR(255);
DECLARE @PropertyName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(255) NOT NULL,
  ColumnName VARCHAR(255),
  PropertyName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ColumnName, PropertyName)
  SELECT TableName     = OBJECT_NAME(EXT.major_id), 
         ColumnName    = COL.name,
         PropertyName  = EXT.name
  FROM sys.extended_properties EXT
    LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                  AND COL.column_id = EXT.minor_id
  WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
    AND EXT.name <> 'microsoft_database_tools_support'
    AND ISNULL(EXT.value, '') IN ('', '(null)')
  ORDER BY TableName, 
           ColumnName, 
           CASE 
             WHEN EXT.name = 'MS_Description' THEN 0 
             ELSE 1 
           END, 
           PropertyName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName    = TMP.TableName,
         @ColumnName   = TMP.ColumnName,
         @PropertyName = TMP.PropertyName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- drop extended property
  -----------------------------------------------------------------------------
  EXEC dbo.spXExtendedProperty @TableName, @ColumnName, @PropertyName, '_delete_', 0, 1;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix constrainst created WITH NOCHECK to WITH CHECK.
           Reason:
           Constraints defined WITH NOCHECK are not considered by the query optimizer. These 
           constraints are ignored until all such constraints are re-enabled.
           
           See: http://msdn.microsoft.com/en-us/library/aa275462(v=sql.80).aspx
           
           Hint: Use "DBCC CHECKCONSTRAINTS (table_name)" to validate only
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(1000);
DECLARE @ConstraintName VARCHAR(1000);
DECLARE @SQLStatement NVARCHAR(4000);
DECLARE @ErrorMessage VARCHAR(8000);
DECLARE @ErrorCount INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(1000) NOT NULL,
  ConstraintName VARCHAR(1000) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ConstraintName)
  SELECT TableName      = OBJECT_NAME(parent_object_id),
         ConstraintName = name
  FROM sys.foreign_keys
  WHERE is_not_trusted = 1
    AND is_disabled = 0
  ORDER BY TableName, ConstraintName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table
SET @ErrorCount = 0;

-- info
PRINT ('Info: Found "' + CONVERT(VARCHAR(50), @EntriesCount) + '" invalid constraints');

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName      = TMP.TableName,
         @ConstraintName = TMP.ConstraintName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- try to fix constraint
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to fix constraint here
    SET @SQLStatement = 'ALTER TABLE [dbo].[' + @TableName + '] WITH CHECK CHECK CONSTRAINT [' + @ConstraintName + '];';
    EXECUTE sp_executesql @SQLStatement;
    
    -- save
    COMMIT TRANSACTION;
    
    -- done
    PRINT ('Info: Successfully fixed table "' + @TableName + '" and constraint "' + @ConstraintName + '".');
  END TRY
  BEGIN CATCH
    -- undo
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = 'Warning: Could not fix table "' + @TableName + '" and constraint "' + @ConstraintName + '". Database error was: ' + ISNULL(ERROR_MESSAGE(), '<error?>');
    SET @ErrorCount = @ErrorCount + 1;

    -- show message and continue
    PRINT (@ErrorMessage);
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- info
PRINT ('Info: Having now "' + CONVERT(VARCHAR(50), @ErrorCount) + '" invalid constraints after fixing');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for BaPerson.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaPerson]'))
BEGIN
  DROP TRIGGER dbo.trHist_BaPerson;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaAdresse.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaAdresse.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for BaAdresse.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaAdresse]'))
BEGIN
  DROP TRIGGER dbo.trHist_BaAdresse;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaAdresse.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_BaAdresse.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for XUser.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_XUser]'))
BEGIN
  DROP TRIGGER dbo.trHist_XUser;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for XOrgUnit.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_XOrgUnit]'))
BEGIN
  DROP TRIGGER dbo.trHist_XOrgUnit;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit_User.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit_User.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for XOrgUnit_User.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_XOrgUnit_User]'))
BEGIN
  DROP TRIGGER dbo.trHist_XOrgUnit_User;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit_User.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Drop_HistoryTrigger_XOrgUnit_User.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\CreateViews_Common.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\CreateViews_Common.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPersonSimple.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPersonSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPersonSimple;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table BaPerson. The aim of this view is to be faster as
           the VwPerson.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a person. (BaPersonID, NameVorname)
=================================================================================================
  TEST:    SELECT TOP 10 BaPersonID, NameVorname FROM dbo.vwPersonSimple;
=================================================================================================*/

CREATE VIEW dbo.vwPersonSimple
AS
SELECT
  PRS.BaPersonID,
  NameVorname = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
  PRS.Versichertennummer,
  PRS.GeschlechtCode,
  PRS.Geburtsdatum,
  DisplayText = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' +
                IsNull(CONVERT(varchar,dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum)),'-') + ',' +
                IsNull((SELECT TOP 1 GES.ShortText
                        FROM dbo.XLOVCode GES WITH(READUNCOMMITTED)
                        WHERE GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode),'?') + ')'
FROM dbo.BaPerson PRS WITH (READUNCOMMITTED);

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPersonSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPersonSimple.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\vwUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\vwUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwUser;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwUser
AS
SELECT
  USR.UserID,
  USR.LogonName,
  USR.FirstName,
  USR.LastName,
  USR.ShortName,
  USR.IsUserAdmin,
  USR.PasswordHash,
  USR.IsLocked,
  USR.GenderCode,
  USR.LanguageCode,
  USR.ModulID,
  USR.UserProfileCode,
  USR.isMandatsTraeger,
  USR.Phone,
  USR.EMail,
  USR.ChiefID,
  USR.PermissionGroupID,
  USR.GrantPermGroupID,
  USR.JobPercentage,
  USR.HoursPerYearForCaseMgmt,
  USR.PrimaryUserID,
  USR.Funktion,
  USR.SachbearbeiterID,
  ORG.OrgUnitID,
  OrgUnit                = ORG.ItemName,
  OrgUnitShort           = IsNull(QUOE.ShortText, ORG.ItemName),
  BenutzerNr             = USR.UserID,
  Logon                  = USR.LogonName,
  Name                   = USR.LastName,
  Vorname                = USR.FirstName,
  Kurzzeichen            = USR.ShortName,
  Telefon                = USR.Phone,
  FrauHerr               = CASE USR.GenderCode
                             WHEN 1 THEN 'Herr'
                             WHEN 2 THEN 'Frau'
                           END ,
  NameVorname            = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  NameVornameOhneKomma   = USR.LastName + IsNull(' ' + USR.FirstName, ''),
  Text1RTF               = USR.Text1,
  USR.Text1,
  Text2RTF               = USR.Text2,
  USR.Text2,
  VornameName            = IsNull(USR.FirstName + ' ','') + USR.LastName,
  OrgEinheitAdresseFeld  = ORG.Adresse,
  OrgEinheitEMail        = ORG.EMail,
  OrgEinheitFax          = ORG.Fax,
  OrgEinheitLogoRTF      = ORG.Logo,
  OrgEinheitName         = ORG.ItemName,
  OrgEinheitTelefon      = ORG.Phone,
  OrgEinheitTelFaxWWW    = ORG.WWW,
  OrgEinheitText1RTF     = ORG.Text1,
  OrgEinheitText1        = ORG.Text1,
  OrgEinheitText2RTF     = ORG.Text2,
  OrgEinheitText2        = ORG.Text2,
  OrgEinheitText3RTF     = ORG.Text3,
  OrgEinheitText3        = ORG.Text3,
  OrgEinheitText4RTF     = ORG.Text4,
  OrgEinheitText4        = ORG.Text4,
  OrgEinheitWWW          = ORG.WWW,
  Sozialzentrum          = SZ.Text,
  SozialzentrumKurz      = SZ.ShortText,
  SozialzentrumCode      = SZ.Code,
  StellenleiterID        = ORG.ChiefID,
  StellenleiterName      = STL.LastName + IsNull(', ' + STL.FirstName,''),
  StellenleiterLogon     = STL.LogonName,
  StellenleiterStvID     = ORG.StellvertreterID,
  StellenleiterStvName   = STV.LastName + IsNull(', ' + STV.FirstName,''),
  StellenleiterStvLogon  = STV.LogonName,
  LogonNameVornameOrgUnit = USR.LogonName + ' - ' + USR.LastName + IsNull(', ' + USR.FirstName, '')
                            + IsNull(' (' + ORG.ItemName + ')', ''),
  DisplayText             = USR.LogonName + ' - ' + USR.LastName + IsNull(', ' + USR.FirstName, '')
                            + IsNull(' (' + ORG.ItemName + ')', '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
     -- OrgUnit
     LEFT JOIN dbo.XOrgUnit_User OUU  WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                     OUU.OrgUnitMemberCode = 2
     LEFT JOIN dbo.XOrgUnit      ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
     LEFT JOIN dbo.XLOVCode      QUOE   WITH (READUNCOMMITTED) ON QUOE.LOVName = 'QuOrgUnitTeam' AND
                                     QUOE.Code = OUU.OrgUnitID

     -- Stellenleiter/Stv.
     LEFT JOIN dbo.XUser        STL  WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
     LEFT JOIN dbo.XUser        STV  WITH (READUNCOMMITTED) ON STV.UserID = ORG.StellvertreterID

     -- Bestimmung Sozialzentrum
     LEFT JOIN dbo.XOrgUnit      PAR1 WITH (READUNCOMMITTED) ON PAR1.OrgUnitID = ORG.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR2 WITH (READUNCOMMITTED) ON PAR2.OrgUnitID = PAR1.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR3 WITH (READUNCOMMITTED) ON PAR3.OrgUnitID = PAR2.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR4 WITH (READUNCOMMITTED) ON PAR4.OrgUnitID = PAR3.ParentID
     LEFT JOIN dbo.XLOVCode      SZ   WITH (READUNCOMMITTED) ON SZ.LOVName = 'FaSozialzentrum' AND
                                     CONVERT(int,SZ.Value1) in (ORG.OrgUnitID,PAR1.OrgUnitID,PAR2.OrgUnitID,PAR3.OrgUnitID,PAR4.OrgUnitID)

GO
GRANT SELECT ON [dbo].[vwUser] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\vwUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\vwUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmUser.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmUser
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmUser.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmUser.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmUser]
AS

SELECT
  BenutzerNr					= USR.UserID,
  Logon							= USR.LogonName,
  Name							= USR.LastName,
  Vorname						= USR.FirstName,
  Kurzzeichen					= USR.ShortName,
  Telefon						= USR.Phone,
  EMail							= USR.EMail,
  Funktion						= USR.Funktion,
  FrauHerr						= CASE USR.GenderCode
								   WHEN 1 THEN 'Herr'
								   WHEN 2 THEN 'Frau'
								   END ,
  NameVorname					= USR.LastName + IsNull(', ' + USR.FirstName,''),
  NameVornameOhneKomma			= USR.LastName + IsNull(' ' + USR.FirstName,''),
  Text1MitFMT					= USR.Text1 ,
  Text1OhneFMT					= USR.Text1 ,
  Text2MitFMT					= USR.Text2 ,
  Text2OhneFMT					= USR.Text2 ,
  VornameName					= IsNull(USR.FirstName + ' ','') + USR.LastName,
  FrauHerrVornameName			= CASE USR.GenderCode WHEN 1 THEN 'Herr ' WHEN 2 THEN 'Frau ' ELSE '' END +
									IsNull(USR.FirstName + ' ','') + USR.LastName,
  OrgEinheitAdresseFeld			= ORG.Adresse,
  OrgEinheitAdresseFeldOhneStdZH = replace(convert(varchar(2000),Org.Adresse), 'Stadt Zürich' + char(13) + char(10),''),
  OrgEinheitAdresseEinzeilig	= replace(convert(varchar(2000),ORG.Adresse), char(13) + char(10), ', '),
  OrgEinheitAdresseEinzOhneStdZH = replace( 
									replace(convert(varchar(2000),ORG.Adresse), char(13) + char(10), ', '),
									'Stadt Zürich, ', ''),
  OrgEinheitEMail				= ORG.EMail,
  OrgEinheitFax					= ORG.Fax,
  OrgEinheitLogoMitFMT			= ORG.Logo,
  OrgEinheitName				= ORG.ItemName,
  OrgEinheitTelefon				= ORG.Phone,
  OrgEinheitTelFaxWWW			= IsNull('Tel. ' + ORG.Phone, '') + 
								  IsNull(char(13) + char(10) + 'Fax ' + ORG.Fax, '') + 
								  IsNull(char(13) + char(10) + ORG.WWW, '') /* +
								   char(13) + char(10) +
								   char(13) + char(10) +
								   'Ihre Kontaktperson' + char(13) + char(10) +
								   USR.LastName + IsNull(' ' + USR.FirstName,'') +
								   IsNull( char(13) + char(10) + 'Direktwahl ' + USR.Phone,'') +
								   IsNull( char(13) + char(10) + USR.EMail,'') */ ,
  OrgEinheitText1MitFMT			= ORG.Text1,
  OrgEinheitText1ohneFMT		= ORG.Text1,
  OrgEinheitText2MitFMT			= ORG.Text2,
  OrgEinheitText2ohneFMT		= ORG.Text2,
  OrgEinheitText3MitFMT			= ORG.Text3,
  OrgEinheitText3ohneFMT		= ORG.Text3,
  OrgEinheitText4MitFMT			= ORG.Text4,
  OrgEinheitText4ohneFMT		= ORG.Text4,
  OrgEinheitWWW					= ORG.WWW,

  StellenleiterVornameName		= IsNull(STL.FirstName + ' ','') + STL.LastName,
  StellenleiterStvVornameName	= IsNull(STV.FirstName + ' ','') + STV.LastName,

  Sozialzentrum					= SZ.Text,
  SozialzentrumKurz				= SZ.ShortText,
  SozialzentrumCode				= SZ.Code,
  SozialzentrumLtgAnrede		= CASE ZL.GenderCode
									WHEN 1 THEN 'Herr'
									WHEN 2 THEN 'Frau'
								  END,
  SozialzentrumLtg				=ZL.FirstName +IsNull(' ' + ZL.LastName,''),
  SozialzentrumAdresseOhneStdZH = replace(convert(varchar(2000),SZ1.Adresse), 'Stadt Zürich' + char(13) + char(10),''),
  SozialzentrumAdresseEinzeilig = replace(replace(convert(varchar(2000),SZ1.Adresse), char(13) + char(10), ', '), 
									'Stadt Zürich, ','')


FROM dbo.XUser USR WITH (READUNCOMMITTED)
     LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
     LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
     LEFT OUTER JOIN dbo.XUser         STL WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
     LEFT OUTER JOIN dbo.XUser         STV WITH (READUNCOMMITTED) ON STV.UserID = ORG.StellvertreterID

     -- Bestimmung Sozialzentrum (analog vwUser)
     LEFT JOIN dbo.XOrgUnit      PAR1 WITH (READUNCOMMITTED) ON PAR1.OrgUnitID = ORG.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR2 WITH (READUNCOMMITTED) ON PAR2.OrgUnitID = PAR1.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR3 WITH (READUNCOMMITTED) ON PAR3.OrgUnitID = PAR2.ParentID
     LEFT JOIN dbo.XOrgUnit      PAR4 WITH (READUNCOMMITTED) ON PAR4.OrgUnitID = PAR3.ParentID
     LEFT JOIN dbo.XLOVCode      SZ   WITH (READUNCOMMITTED) ON SZ.LOVName = 'FaSozialzentrum' AND
                                     CONVERT(int,SZ.Value1) in (ORG.OrgUnitID,PAR1.OrgUnitID,PAR2.OrgUnitID,PAR3.OrgUnitID,PAR4.OrgUnitID)
	 -- Leitung Sozialzentrum
	 LEFT JOIN dbo.XOrgUnit		 SZ1  WITH (READUNCOMMITTED) ON SZ1.OrgUnitID = CONVERT(int,SZ.Value1)
	 LEFT JOIN dbo.Xuser		 ZL   WITH (READUNCOMMITTED) ON ZL.Userid = SZ1.ChiefID

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmUser.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmUser.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwUserSimple.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwUserSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwUserSimple;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This is a simple view of the table XUser. The aim of this view is to be faster as
           the vwUser.
           Joins are not allowed in this view, in order to keep it fast!
  -
  RETURNS: A few amount of information about a user. 
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwUserSimple;
=================================================================================================*/

CREATE VIEW dbo.vwUserSimple
AS
SELECT
  USR.UserID,
  USR.LogonName,
  USR.LastName,
  USR.FirstName,
  NameVorname            = USR.LastName + IsNull(', ' + USR.FirstName, ''),
  DisplayText            = USR.LastName + IsNull(', ' + USR.FirstName, '') + ' - ' + USR.LogonName
FROM dbo.XUser USR WITH (READUNCOMMITTED);
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwUserSimple.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwUserSimple.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewForeignKeys.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewForeignKeys.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject XViewForeignKeys
GO

CREATE VIEW dbo.XViewForeignKeys AS
SELECT DISTINCT ForeignKeyName = sob.[Name],
                PKTable = OBJECT_NAME( sfk.rkeyid ),
                PKColumns = dbo.fnGetReferencedKeyColumnsOfForeignKey( sfk.constid ),
                FKTable = OBJECT_NAME( sfk.fkeyid ),
                FKColumns = dbo.fnGetForeignKeyColumnsOfForeignKey( sfk.constid )
FROM sysforeignkeys sfk
  INNER JOIN sysobjects sob
  ON sfk.constid = sob.id

GO
GRANT SELECT ON [dbo].[XViewForeignKeys] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewForeignKeys.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewForeignKeys.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewIndex.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewIndex.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject XViewIndex
GO

CREATE VIEW dbo.XViewIndex AS
SELECT IndexName = si.Name,
       TableName = so.Name,
       PrimaryKey = CAST( ( CASE (si.Status & 2048) WHEN 2048 THEN 1 ELSE 0 END ) AS bit ),
       [Unique] = CAST( INDEXPROPERTY(si.id, si.Name, 'IsUnique') AS bit ),
       [Clustered] = CAST( INDEXPROPERTY(si.id, si.Name, 'IsClustered') AS bit ),
       Keys = dbo.fnGetKeyColumnsOfIndex( so.Name, si.Name )

FROM sysindexes si
  INNER JOIN sysobjects so
  ON so.id = si.id

WHERE si.indid > 0 AND
      si.indid < 255 AND
      INDEXPROPERTY(si.id, si.Name, 'IsStatistics') = 0 AND
      INDEXPROPERTY(si.id, si.Name, 'IsHypothetical') = 0

GO
GRANT SELECT ON [dbo].[XViewIndex] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewIndex.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\ZH\XViewIndex.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwBaKlientensystemPerson;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Eine übergreifende View, um FaFallPerson aus ZH und Standard zu abstrahieren
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwBaKlientensystemPerson;
=================================================================================================*/

CREATE VIEW dbo.vwBaKlientensystemPerson
AS
SELECT FaFallID,
       BaPersonID,
       DatumVon,
       DatumBis
FROM dbo.FaFallPerson FFP WITH (READUNCOMMITTED);
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwBaKlientensystemPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBDEZLEUebersicht;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:58 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for ZLE-Erfassung (only dummy for columns)
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmBDEZLEUebersicht
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
 * 
 * 4     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 3     23.10.08 9:31 Cjaeggi
 * Removed change again
 * 
 * 2     23.10.08 9:19 Cjaeggi
 * Changed fnBDEGetUebersicht
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmBDEZLEUebersicht
AS
SELECT FCN.UserID, 
       FCN.MonatJahrText, 
       FCN.PensumProzent, 
       FCN.SollArbeitszeitProTag, 
       FCN.GZIstArbeitszeitProMonat, 
       FCN.GZSollArbeitszeitProMonat, 
       FCN.GZMonatsSaldo, 
       FCN.GZUebertragVorjahr, 
       FCN.GZUebertragVormonate, 
       FCN.GZKorrekturen, 
       FCN.GZAusbezahlteUeberstunden, 
       FCN.GZSaldo, 
       FCN.SLIstArbeitszeitProMonat, 
       FCN.FerienUebertragVorjahr, 
       FCN.FerienAnspruchProJahr, 
       FCN.FerienBisherBezogen, 
       FCN.FerienZugabenKuerzungen, 
       FCN.FerienKorrekturen, 
       FCN.FerienSaldo
FROM dbo.fnBDEGetUebersicht(- 1, dbo.fnLastDayOf(GETDATE()), 1, 0) AS FCN
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmBDEZLEUebersicht.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwIxBDELeistung_BDELeistungsart_AuswDLCode;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET ANSI_PADDING ON;
GO
SET ANSI_WARNINGS ON;
GO
SET CONCAT_NULL_YIELDS_NULL ON;
GO
SET NUMERIC_ROUNDABORT OFF;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ARITHABORT ON;
GO

/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Indexed view to improve performance of BDELeistung with INNER JOIN on BDELeistungsart.
           Usage for example in dbo.fnFaIsPersonClientByRule
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode;
=================================================================================================*/

CREATE VIEW dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode WITH SCHEMABINDING
AS
SELECT
  -- BDELeistung
  BaPersonID             = LEI.BaPersonID,
  Datum                  = LEI.Datum,
  DauerSUM               = SUM(ISNULL(LEI.Dauer, 0.0)),
  
  -- BDELeistungsart
  AuswDienstleistungCode = BLA.AuswDienstleistungCode,
  cBig                   = COUNT_BIG(*)
FROM dbo.BDELeistung             LEI
  INNER JOIN dbo.BDELeistungsart BLA ON BLA.BDELeistungsartID = LEI.BDELeistungsartID
GROUP BY LEI.BaPersonID, LEI.Datum, BLA.AuswDienstleistungCode;
GO

-------------------------------------------------------------------------------
-- create indexes
-------------------------------------------------------------------------------
CREATE UNIQUE CLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO

CREATE NONCLUSTERED INDEX IX_vwIxBDELeistung_BDELeistungsart_AuswDLCode_BaPersonID_Datum_DauerSUM_AuswDienstleistungCode 
ON [vwIxBDELeistung_BDELeistungsart_AuswDLCode]
(
  [BaPersonID] ASC,
  [Datum] ASC,
  [DauerSUM] ASC,
  [AuswDienstleistungCode] ASC
) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
        SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, 
        ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [DATEN2];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\vwIxBDELeistung_BDELeistungsart_AuswDLCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmGvGesuch;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken-View für die Gesuchverwaltung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmGvGesuch;
=================================================================================================*/

CREATE VIEW dbo.vwTmGvGesuch
AS
SELECT
  -----------------------------------------------------------------------------
  -- GvGesuch
  -----------------------------------------------------------------------------
  GvGesuchID              = GGE.GvGesuchID,
  BaPersonID              = GGE.BaPersonID,
  UserID                  = GGE.XUserID_Autor,
  GesuchsDatum            = GGE.GesuchsDatum,
  Gesuchsgrund            = GGE.Gesuchsgrund,
  BetragBewilligt         = GGE.BetragBewilligt,
  BewilligtAm             = GGE.BewilligtAm,
  BegruendungMitFmt       = GGE.Begruendung, -- RTF
  BegruendungOhneFmt      = GGE.Begruendung, -- NORTF
  Bemerkung               = GGE.Bemerkung,
  BewilligungBetragKS1    = GGE.BetragBewilligtKompetenzStufe1,
  BewilligungDatumKS1     = GGE.DatumBewilligtKompetenzStufe1,
  BewilligungBemerkungKS1 = GGE.BemerkungBewilligungKompetenzStufe1,
  BewilligungBetragKS2    = GGE.BetragBewilligtKompetenzStufe2,
  BewilligungDatumKS2     = GGE.DatumBewilligtKompetenzStufe2,
  BewilligungBemerkungKS2 = GGE.BemerkungBewilligungKompetenzStufe2,

  -----------------------------------------------------------------------------
  -- Bewilligung
  -----------------------------------------------------------------------------
  BewilligtVonName      = USRB.FirstName,
  BewilligtVonVorname   = USRB.LastName,
  BewilligtVonAbteilung = USRB.OrgEinheitName,

  -----------------------------------------------------------------------------
  -- Abschluss (externer Fonds)
  -----------------------------------------------------------------------------
  AbschlussDatum  = GGE.AbschlussDatum,
  AbschlussgrundD = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 1),
  AbschlussgrundF = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 2),
  AbschlussgrundI = dbo.fnGetLOVMLText('GvAbschlussgrund', GGE.GvAbschlussgrundCode, 3),

  -----------------------------------------------------------------------------
  -- Berechnet
  -----------------------------------------------------------------------------
  BetragBeantragt     = BBT.BetragBeantragt,
  BetragEigenleistung = ISNULL((SELECT SUM(CASE APO.GvAntragPositionTypCode
                                             WHEN 1 THEN APO.Betrag
                                             WHEN 2 THEN -APO.Betrag
                                             WHEN 3 THEN -APO.Betrag
                                           END)
                                FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                WHERE APO.GvGesuchID = GGE.GvGesuchID), $0),
  TotalAusFLBFond     = ISNULL((SELECT SUM(GGE1.BetragBewilligt)
                                FROM dbo.GvGesuch GGE1 WITH (READUNCOMMITTED)
                                WHERE GGE1.BaPersonID = GGE.BaPersonID
                                  AND YEAR(GGE1.GesuchsDatum) = YEAR(GETDATE())), $0),
  Kuerzung            = dbo.fnMax(BBT.BetragBeantragt - GGE.BetragBewilligt, $0),

  -----------------------------------------------------------------------------
  -- User
  -----------------------------------------------------------------------------
  Mitarbeiter  = USR.NameVorname,
  KGS          = KGS.ItemName,
  Kostenstelle = KST.ItemName,
  
  -----------------------------------------------------------------------------
  -- Person
  -----------------------------------------------------------------------------
  Klient = PRS.NameVorname,

  -----------------------------------------------------------------------------
  -- Fonds
  -----------------------------------------------------------------------------
  FondsNameKurz   = GFD.NameKurz,
  FondsNameLang   = GFD.NameLang,
  FondsBemerkungD = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 1, GFD.Bemerkung),
  FondsBemerkungF = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 2, GFD.Bemerkung),
  FondsBemerkungI = dbo.fnGetMLTextByDefault(GFD.BemerkungTID, 3, GFD.Bemerkung),
  FondsTypD       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 1),
  FondsTypF       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 2),
  FondsTypI       = dbo.fnGetLOVMLText('GvFondsTyp', GFD.GvFondsTypCode, 3),

  -----------------------------------------------------------------------------
  -- Verteiler
  -----------------------------------------------------------------------------
  Verteiler       = CASE 
                      WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + ', ' + USR.VornameName
                      ELSE AKS.BeantragendeStelle + ', ' + AKS.Kontaktperson + ', ' + AKS.Ort
                    END,
  VerteilerMehrzeilig = CASE 
                         WHEN AKS.Ort IS NULL THEN 'Pro Infirmis, '+  KST.ItemName + CHAR(13) + CHAR(10) + USR.VornameName
                         ELSE ISNULL(AKS.BeantragendeStelle + CHAR(13) + CHAR(10),'') +
                              ISNULL(AKS.Zusatz + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Kontaktperson + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.Strasse + ISNULL(' ' + AKS.HausNr, '') + CHAR(13) + CHAR(10), '') +
                              ISNULL(dbo.fnBaGetPostfachText(NULL, AKS.Postfach, AKS.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                              ISNULL(AKS.PLZ + ' ', '') + ISNULL(AKS.Ort + CHAR(13) + CHAR(10), '')+
                              ISNULL(AKS.EMail, '')
                        END

FROM dbo.GvGesuch                    GGE  WITH (READUNCOMMITTED)
  INNER JOIN dbo.vwUser              USR  WITH (READUNCOMMITTED) ON USR.UserID = GGE.XUserID_Autor
  INNER JOIN dbo.vwPersonSimple      PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = GGE.BaPersonID
  INNER JOIN dbo.GvFonds             GFD  WITH (READUNCOMMITTED) ON GFD.GvFondsID = GGE.GvFondsID
  OUTER APPLY (SELECT BetragBeantragt     = ISNULL((SELECT SUM(APO.Betrag)
                                                    FROM dbo.GvAntragPosition APO WITH (READUNCOMMITTED)
                                                    WHERE APO.GvGesuchID = GGE.GvGesuchID
                                                      AND APO.GvAntragPositionTypCode = 2), $0)) BBT
  -- Benutzer der zuletzt das Gesuch bewilligt hat (letzer Eintrag mit Status "Prüfung abschliessen")
  LEFT JOIN dbo.GvBewilligung        GBE  WITH (READUNCOMMITTED) ON GBE.GvGesuchID = GGE.GvGesuchID
                                                                AND GBE.GvBewilligungCode = 5 -- Prüfung abschliessen
                                                                AND NOT EXISTS(SELECT TOP 1 1
                                                                               FROM dbo.GvBewilligung GBE2 WITH (READUNCOMMITTED)
                                                                               WHERE GBE2.GvGesuchID = GBE.GvGesuchID
                                                                                 AND GvBewilligungCode NOT IN (7, 8, 9) -- Zahlungen ausführen, Auflagen erledigen, Gesuch abschliessen
                                                                                 AND GBE2.Created > GBE.Created)
  LEFT JOIN dbo.vwUser               USRB WITH (READUNCOMMITTED) ON USRB.UserID = GBE.UserID
  LEFT JOIN dbo.XOrgUnit             KST  WITH (READUNCOMMITTED) ON KST.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(GGE.XUserID_Autor, 1))
  LEFT JOIN dbo.XOrgUnit             KGS  WITH (READUNCOMMITTED) ON KGS.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(GGE.XUserID_Autor)
  LEFT JOIN dbo.GvAbklaerendeStelle  AKS  WITH (READUNCOMMITTED) ON AKS.GvGesuchID = GGE.GvGesuchID
;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\vwTmGvGesuch.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwXConfig_public.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwXConfig_public.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwXConfig_public;
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get details for SingleSignOn. 
  -
  RETURNS: Details of table XConfig.
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwXConfig_public;
=================================================================================================*/

CREATE VIEW dbo.vwXConfig_public
AS
SELECT
  CNF.XNamespaceExtensionID,
  CNF.KeyPath,
  CNF.System,
  CNF.DatumVon,
  CNF.ValueCode,
  CNF.LOVName,
  CNF.ValueBit,
  CNF.OriginalValueBit,
  CNF.ValueDateTime,
  CNF.OriginalValueDateTime,
  CNF.ValueDecimal,
  CNF.OriginalValueDecimal,
  CNF.ValueInt,
  CNF.OriginalValueInt,
  CNF.ValueMoney,
  CNF.OriginalValueMoney,
  CNF.ValueVarchar,
  CNF.OriginalValueVarchar
FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
  OUTER APPLY (SELECT TOP 1 DatumBis = DatumVon
               FROM dbo.XConfig CNFI WITH (READUNCOMMITTED)
               WHERE CNFI.KeyPath = CNF.KeyPath
                 AND CNFI.DatumVon > CNF.DatumVon
               ORDER BY CNFI.DatumVon ASC
               ) CNF2
WHERE CNF.KeyPath IN ('System\Allgemein\SingleSignOn',
                      'System\Allgemein\SingleSignOn\Domain',
                      'System\Allgemein\SingleSignOn\Gruppe',
                      'System\Allgemein\Benutzername_TechnischerBenutzer',
                      'System\Allgemein\Passwort_TechnischerBenutzer')
  AND GETDATE() BETWEEN CNF.DatumVon AND ISNULL(CNF2.DatumBis, '99991231');
  
GO

-- DO NOT REMOVE!
GRANT SELECT ON [dbo].[vwXConfig_public] TO [kiss_public];
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwXConfig_public.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\System\vwXConfig_public.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\CreateViews_Common.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\CreateViews_Common.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\ZH\CreateViews.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\ZH\CreateViews.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_DOSSIER.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_DOSSIER.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_DOSSIER]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_DOSSIER;
END;
GO
/*===============================================================================================
  $Revision: 6 $
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
=================================================================================================*/

CREATE VIEW dbo.vwVIS_DOSSIER
AS
SELECT FALL_NR          = DOS.Number,
       DepartmentId     = DOS.ResponsibleDepartmentId,
       ABTEILUNG        = DEP.DepartmentShortCut,
       ZIP_NR           = REPLACE(DOS.MainPersonZipCode, '.', ''),
       NAME             = DOS.MainPersonSurname,
       ALLIANZNAME      = DOS.MainPersonAllianceName,
       VORNAME          = DOS.MainPersonGivenName,
       G_DAT            = DOS.MainPersonDateOfBirth,
       H_ORT            = DOS.MainPersonNativePlace,
       ZIV              = DOS.MainPersonMaritalState,
       AHV_NR           = REPLACE(DOS.MainPersonAhvNumber, '.', ''),
       SEX              = DOS.MainPersonGender,
       WMA_STR          = DOS.MainPersonStreet,
       WMA_POSTLAGERND  = DOS.MainPersonPosteRestante,
       WMA_PLZ          = DOS.MainPersonZip,
       WMA_ORT          = DOS.MainPersonCity,
       Id               = DOS.Id,
       RespDepId        = DOS.ResponsibleDepartmentId
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Dossier]            DOS
  INNER JOIN [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Department] DEP ON DEP.Id = DOS.ResponsibleDepartmentId

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO



GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_DOSSIER.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_DOSSIER.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MANDATSTRAEGER]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_MANDATSTRAEGER;
END;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Nimmt den aktuellsten Mandatsträger aus dem Bericht
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MANDATSTRAEGER
AS
WITH CTE AS
(
  SELECT MAND_ID          = MRI.Number,
         VORMSCH_ID       = MAN.ArrangementObsoleteIdentity,
         ArrangementId    = MAN.ArrangementId,
         PERS_NR          = MAN.PersonNumber,
         NAME             = MAN.MandateOfficerSurname,
         VORNAME          = MAN.MandateOfficerGivenName,
         CATEGORY         = MAN.MandateOfficerCategory,
         M_ERNENN_DT      = MAN.DateOfNomination,
         M_AUFHEB_DT      = MAN.DateOfDismissal,
         BERICHTSTERMIN   = MRI.ReportDate,
         T1               = MRI.MandateReportCategory,
         BERICHT_VON      = MRI.ReportStart,
         BERICHT_PER      = MRI.ReportEnd,
         MAHNUNG1         = MRI.Dunning1,
         MAHNUNG2         = MRI.Dunning2,
         MAHNUNG3         = MRI.Dunning3,
         EINGANG_SDS      = MRI.ClearingOfficeEntry,
         AUSGANG_SDS      = MRI.ClearingOfficeExit,
         VB_BESCHLUSS     = MRI.Demandnote,
         RB_SB_BRZ        = MRI.Receipt,
         FRISTERSTRECKUNG = MRI.TimelimitExtension,
         FALL_NR          = MAN.DossierNumber,
         BK_ID            = MRI.Id,
         MandateId        = MAN.Id,
         RankBericht      = RANK() OVER (PARTITION BY MRI.MandateID ORDER BY ISNULL(MRI.ReportStart, '17530101') DESC, ISNULL(MRI.ReportEnd, '99991231') DESC) -- pro Mandat die Berichte nummerieren
  FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Mandate]                  MAN
    LEFT JOIN [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[MandateReportInfo] MRI ON MRI.MandateId = MAN.Id
)

SELECT  MAND_ID,
        VORMSCH_ID,
        ArrangementId,
        PERS_NR,
        NAME,
        VORNAME,
        CATEGORY,
        M_ERNENN_DT,
        M_AUFHEB_DT,
        BERICHTSTERMIN,
        T1,
        BERICHT_VON,
        BERICHT_PER,
        MAHNUNG1,
        MAHNUNG2,
        MAHNUNG3,
        EINGANG_SDS,
        AUSGANG_SDS,
        VB_BESCHLUSS,
        RB_SB_BRZ,
        FRISTERSTRECKUNG,
        FALL_NR,
        BK_ID,
        MandateId
FROM CTE
WHERE RankBericht = 1; -- nur das aktuellest Bericht jeden Mandats

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER_SIMPLE.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER_SIMPLE.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MANDATSTRAEGER_SIMPLE]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_MANDATSTRAEGER_SIMPLE;
END;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: einfache View um den Name eines Mandatsträger zu haben
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MANDATSTRAEGER_SIMPLE
AS
SELECT PERS_NR          = MAN.PersonNumber,
       NAME             = MAN.MandateOfficerSurname,
       VORNAME          = MAN.MandateOfficerGivenName,
       NameVorname      = MAN.MandateOfficerSurname + ', ' + MAN.MandateOfficerGivenName,
       CATEGORY         = MAN.MandateOfficerCategory,
       M_ERNENN_DT      = MAN.DateOfNomination,
       M_AUFHEB_DT      = MAN.DateOfDismissal,
       MandateId        = MAN.Id
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Mandate] MAN

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER_SIMPLE.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MANDATSTRAEGER_SIMPLE.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MASSNAHMEN]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_MASSNAHMEN;
END;
GO
/*===============================================================================================
  $Revision: 8 $
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
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MASSNAHMEN
AS
SELECT Vormsch_ID                 = ARR.ObsoleteIdentity,
       ArrangementId              = ARR.ID,
       FALL_NR                    = ARR.DossierNumber,
       BESCH_A_ED                 = ARR.DateOfOrder,
       BESCH_A_AD                 = ARR.DateOfRepeal,
       Massnahme                  = ARR.ArrangementArticleName,
       Mandatstyp                 = ARR.ArrangementTypeName,
       DossierId                  = ARR.DossierId,
       ArrangementId_Neurechtlich = ARR.ArrangementNewLawId,
       IstNeurechtlich            = ARR.IsNewLaw
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Arrangement] ARR

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN_HIST.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN_HIST.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_MASSNAHMEN_HIST]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_MASSNAHMEN_HIST;
END;
GO
/*===============================================================================================
  $Revision: 7 $
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
=================================================================================================*/
CREATE VIEW dbo.vwVIS_MASSNAHMEN_HIST
AS
SELECT Vormsch_ID    = ARR.ObsoleteIdentity,
       ArrangementId = ARR.ID,
       FALL_NR       = ARR.DossierNumber,
       BESCH_A_ED    = ARH.DateOfOrder,
       BESCH_A_AD    = ARH.DateOfRepeal,
       Massnahme     = ARH.ArticleDescription,
       Mandatstyp    = ARH.ArrangementDescription
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[ArrangementHistory]  ARH
  INNER JOIN [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Arrangement] ARR ON ARR.Id = ARH.ArrangementId
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO



GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN_HIST.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_MASSNAHMEN_HIST.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_ABTEILUNG.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_ABTEILUNG.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_ABTEILUNG]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_ABTEILUNG;
END;
GO
/*===============================================================================================
  $Revision: 7 $
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
=================================================================================================*/
CREATE VIEW dbo.vwVIS_ABTEILUNG
AS
SELECT Waisenrat     = OrphanConcilGivenname + ' ' + OrphanConcilSurname + ', KESB Mitglied',
       Telefon       = OrphanConcilPhoneExternal,
       Abteilung     = DepartmentShortCut,
       AbteilungLang = DepartmentName,
       Id            = Id
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Department]

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_ABTEILUNG.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_ABTEILUNG.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_BERICHT.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_BERICHT.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_BERICHT]'))
BEGIN
  EXECUTE dbo.spDropObject vwVIS_BERICHT;
END;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <Beschreibung der View, Zweck und Einsatz>
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwVIS_BERICHT;
=================================================================================================*/
CREATE VIEW dbo.vwVIS_BERICHT
AS
WITH CTE AS
(
  SELECT MAND_ID             = MRI.Number,
         VORMSCH_ID          = MAN.ArrangementObsoleteIdentity,
         ArrangementId       = MAN.ArrangementId,
         BERICHTSTERMIN      = MRI.ReportDate,
         T1                  = MRI.MandateReportCategory,
         BERICHT_VON         = MRI.ReportStart,
         BERICHT_PER         = MRI.ReportEnd,
         MAHNUNG1            = MRI.Dunning1,
         MAHNUNG2            = MRI.Dunning2,
         MAHNUNG3            = MRI.Dunning3,
         EINGANG_SDS         = MRI.ClearingOfficeEntry,
         AUSGANG_SDS         = MRI.ClearingOfficeExit,
         VB_BESCHLUSS        = MRI.Demandnote,
         RB_SB_BRZ           = MRI.Receipt,
         FRISTERSTRECKUNG    = MRI.TimelimitExtension,
         FALL_NR             = MAN.DossierNumber,
         BK_ID               = MRI.Id,
         MandateId           = MRI.MandateId,
         RankBericht         = RANK() OVER (PARTITION BY MRI.MandateID ORDER BY ISNULL(MRI.ReportStart, '17530101') DESC, ISNULL(MRI.ReportEnd, '99991231') DESC) -- pro Mandat die Berichte nummerieren
  FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Mandate]                   MAN
    INNER JOIN [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[MandateReportInfo] MRI ON MRI.MandateId = MAN.Id
)

SELECT  MAND_ID,
        VORMSCH_ID,
        ArrangementId,
        BERICHTSTERMIN,
        T1,
        BERICHT_VON,
        BERICHT_PER,
        MAHNUNG1,
        MAHNUNG2,
        MAHNUNG3,
        EINGANG_SDS,
        AUSGANG_SDS,
        VB_BESCHLUSS,
        RB_SB_BRZ,
        FRISTERSTRECKUNG,
        FALL_NR,
        BK_ID,
        MandateId,
        IstAktiv = CASE WHEN RankBericht = 1 
                     THEN CONVERT(BIT, 1) 
                     ELSE CONVERT(BIT, 0) 
                   END
FROM CTE

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_BERICHT.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_BERICHT.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_OPERATION.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_OPERATION.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT TOP 1 1 FROM master.dbo.sysservers WHERE srvname = 'SZHM24946\SOZ_KISS_D') 
   AND EXISTS (SELECT TOP 1 1 FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVIS_OPERATION]'))
BEGIN 
  EXECUTE dbo.spDropObject vwVIS_OPERATION;
END;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwVIS_OPERATION
AS
SELECT 
  MandateReportInfoId = MandateReportInfoId,
  GenemigungVB        = VbDecision
FROM [SZHM24946\SOZ_KISS_D].[KiSS_ZH_VIS_Test].[kiss].[Operation]

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_OPERATION.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwVIS_OPERATION.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAlteFallNr.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAlteFallNr.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAlteFallNr
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAlteFallNr.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAlteFallNr.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwTmAlteFallNr]
AS

SELECT	BaPersonID,
		AlteFallNr = FallNrAlt,
		AltePersNr = PersonNrAlt,
		DatumVon
FROM	dbo.BaAlteFallNr  WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmAlteFallNr] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAlteFallNr.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAlteFallNr.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylBuchungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylBuchungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylBuchungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:52 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylBuchungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwAsylBuchungen]
AS

SELECT
		KBK.BaPersonID, KBU.KbBuchungTypCode, Betrag = IsNull(KBK.Betrag, KBU.Betrag),
		KBK.VerwPeriodeVon, KBK.VerwPeriodeBis, BKA.Hauptvorgang, BKA.Teilvorgang, LEI.FaFallID

FROM
		dbo.KbBuchungBrutto KBU WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.KbBuchungBruttoPerson    KBK WITH (READUNCOMMITTED) ON KBU.KbBuchungBruttoID = KBK.KbBuchungBruttoID
		LEFT OUTER JOIN dbo.BgKostenart              BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = KBU.BgKostenartID
		LEFT OUTER JOIN dbo.BgBudget                 BUD WITH (READUNCOMMITTED) ON BUD.BgBudgetID        = KBU.BgBudgetID
		LEFT OUTER JOIN dbo.BgFinanzplan             FIP WITH (READUNCOMMITTED) ON FIP.BgFinanzplanID    = BUD.BgFinanzplanID
		LEFT OUTER JOIN dbo.FaLeistung               LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID      = FIP.FaLeistungID
WHERE
		(KBU.KbBuchungTypCode IN (1))
		AND (KBU.KbBuchungStatusCode IN (6, 10))
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylBuchungen] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylBuchungen]  TO [tools_sonar_ek_asyl_role]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylBuchungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylBuchungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFall.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylFall
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylFall.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:52 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST: AND DatumVon < @PeriodeBis AND (DatumBis IS NULL OR DatumBis < @PeriodeVon) X-S, ToDo: Periode berücksichtigen
   .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylFall.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwAsylFall]
AS

SELECT
		FAL.FaFallID,
		WVC.DatumVon AS WVVon,
		WVC.DatumBis AS WVBis,
		LogonName = CAST( USR.LogonName AS varchar(10)),
		ORG.OrgUnitID,
		ORG.ItemName AS TeamName,
		Kostenstelle = CAST( ORG.Kostenstelle AS varchar(10)),
		FalltraegerBaPersonID = FAL.BaPersonID
FROM
		dbo.FaFall FAL WITH (READUNCOMMITTED)
		INNER JOIN dbo.FaFallPerson  FAP WITH (READUNCOMMITTED)
				ON FAP.FaFallID   = FAL.FaFallID
		INNER JOIN dbo.BaPerson      PRS WITH (READUNCOMMITTED)
				ON PRS.BaPersonID = FAL.BaPersonID
		INNER JOIN dbo.BaWVCode      WVC WITH (READUNCOMMITTED)
				ON WVC.BaPersonID = PRS.BaPersonID
				AND WVC.BaWVStatusCode = 1
				AND WVC.BaBedID IN (16026, 16029)

		LEFT OUTER JOIN  dbo.XUser          USR WITH (READUNCOMMITTED) ON USR.UserID     = FAL.UserID
		LEFT OUTER JOIN  dbo.XOrgUnit_User  U2O WITH (READUNCOMMITTED) ON U2O.UserID     = USR.UserID AND U2O.OrgUnitMemberCode = 2
		LEFT OUTER JOIN  dbo.XOrgUnit       ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID  = U2O.OrgUnitID
WHERE
		 (PRS.AuslaenderStatusCode = 29 OR WVC.WVCode = 17)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylFall] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylFall]  TO [tools_sonar_ek_asyl_role]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFall.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFallMitglieder.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFallMitglieder.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON
GO
EXECUTE dbo.spDropObject vwAsylFallMitglieder
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylFallMitglieder.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:52 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylFallMitglieder.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwAsylFallMitglieder]
AS

SELECT     FAL.FaFallID, PRS.BaPersonID, FAP.DatumVon AS ImFallVon, FAP.DatumBis AS ImFallBis, AufenthaltCode = CAST( XLA.Value1 AS varchar(30)), XLC.ShortText AS WVCode,
           WVC.DatumVon AS WVVon, WVC.DatumBis AS WVBis, WVC.SKZNummer AS SKZNr
FROM         dbo.FaFall        AS FAL WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaFallPerson  AS FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = FAL.FaFallID
  INNER JOIN dbo.BaPerson      AS PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAP.BaPersonID
  LEFT OUTER JOIN dbo.BaWVCode AS WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID = PRS.BaPersonID AND WVC.BaWVStatusCode = 1
  INNER JOIN dbo.XLOVCode      AS XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BaWVCode' AND XLC.Code = WVC.WVCode
  INNER JOIN dbo.XLOVCode      AS XLA WITH (READUNCOMMITTED) ON XLA.LOVName = 'BaAufenthaltsstatus' AND XLA.Code = PRS.AuslaenderStatusCode
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylFallMitglieder] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylFallMitglieder]  TO [tools_sonar_ek_asyl_role]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFallMitglieder.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylFallMitglieder.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylGemeinde.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylGemeinde.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwAsylGemeinde
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylGemeinde.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylGemeinde.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW dbo.vwAsylGemeinde
AS

SELECT BaGemeindeID, PLZ, Name, Kanton, BFSCode
FROM dbo.BaGemeinde WITH (READUNCOMMITTED)
WHERE GemeindeAufhebungDatum IS NULL

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylGemeinde] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylGemeinde]  TO [tools_sonar_ek_asyl_role]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylGemeinde.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylGemeinde.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylLand.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylLand.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwAsylLand
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwAsylLand.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwAsylLand.sql $
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW dbo.vwAsylLand
AS

SELECT
		BaLandID, Text AS Land
FROM
		dbo.BaLand WITH (READUNCOMMITTED)

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwAsylLand] TO [tools_access]
GO
GRANT  SELECT  ON [dbo].[vwAsylLand]  TO [tools_sonar_ek_asyl_role]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylLand.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwAsylLand.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaNamen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaNamen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBaNamen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaNamen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaNamen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[vwBaNamen]
AS

SELECT
		-UserID AS ID,
		'Mitarbeiter' AS Typ,
		LastName + IsNull(' ' + FirstName, '') AS Name,
		NULL AS Strasse,
		NULL AS Ort
FROM
		dbo.XUser WITH (READUNCOMMITTED)
UNION ALL
SELECT
		P.BaPersonID AS ID,
		'Person' AS Typ,
		P.Name + IsNull(' ' + P.Vorname, '') AS Name,
		A.Strasse + IsNull(' ' + A.HausNr, '') AS Strasse,
		A.PLZ + IsNull(' ' + A.Ort, '') AS Ort
FROM
		dbo.BaPerson P WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.BaAdresse A WITH (READUNCOMMITTED)
				ON A.BaPersonID=P.BaPersonID
				AND A.BaAdresseID = (		SELECT TOP 1 Q.BaAdresseID
																FROM dbo.BaAdresse Q WITH (READUNCOMMITTED)
																WHERE Q.BaPersonID = P.BaPersonID
																				AND Q.AdresseCode = 1  -- Wohnsitz
																				AND GetDate() BETWEEN IsNull(Q.DatumVon, GetDate())
																				AND IsNull(Q.DatumBis, GetDate())
														)
UNION ALL
SELECT
		B.BaInstitutionID AS ID,
		'Institution' AS Typ,
		B.Name AS Name,
		A.Strasse + IsNull(' ' + A.HausNr, '') AS Strasse,
		A.PLZ + IsNull(' ' + A.Ort, '') AS Ort
FROM
		dbo.BaInstitution B WITH (READUNCOMMITTED)
		LEFT OUTER JOIN dbo.BaAdresse A WITH (READUNCOMMITTED)
				ON A.BaInstitutionID=B.BaInstitutionID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBaNamen]  TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaNamen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaNamen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwPerson
GO
/*===============================================================================================
  $Revision: 9 $
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
=================================================================================================*/

CREATE VIEW dbo.vwPerson
AS

  SELECT
    PRS.BaPersonID,
    PRS.StatusPersonCode,
    PRS.Titel,
    [Name] = PRS.Name,
    Name_AI = PRS.Name COLLATE Latin1_General_CI_AI,
    PRS.FruehererName,
    Vorname = PRS.Vorname,
    Vorname_AI = PRS.Vorname COLLATE Latin1_General_CI_AI,
    PRS.Vorname2,
    PRS.Geburtsdatum,
    PRS.Sterbedatum,
    PRS.AHVNummer,
    PRS.Versichertennummer,
    PRS.HaushaltVersicherungsNummer,
    PRS.NNummer,
    PRS.BFFNummer,
    PRS.ZARNummer,
    PRS.ZEMISNummer,
    PRS.ZIPNr,
    PRS.KantonaleReferenznummer,
    PRS.GeschlechtCode,
    PRS.ZivilstandCode,
    PRS.ZivilstandDatum,
    PRS.HeimatgemeindeCode,
    PRS.HeimatgemeindeCodes,
    PRS.NationalitaetCode,
    PRS.ReligionCode,
    PRS.AuslaenderStatusCode,
    PRS.AuslaenderStatusGueltigBis,
    PRS.Telefon_P,
    PRS.Telefon_G,
    PRS.MobilTel1,
    PRS.MobilTel2,
    PRS.EMail,
    PRS.SprachCode,
    PRS.Unterstuetzt,
    PRS.Fiktiv,
    PRS.Bemerkung,
    PRS.EinwohnerregisterAktiv,
    PRS.EinwohnerregisterID,
    EinwohnerregisterIDOhne0er = REPLACE(LTRIM(REPLACE(PRS.EinwohnerregisterID, '0', ' ')), ' ', '0'), -- Führende Nullen ausblenden
    PRS.DeutschVerstehenCode,
    PRS.WichtigerHinweisCode,
    PRS.ZuzugKtPLZ,
    PRS.ZuzugKtOrtCode,
    PRS.ZuzugKtOrt,
    PRS.ZuzugKtKanton,
    PRS.ZuzugKtLandCode,
    PRS.ZuzugKtDatum,
    PRS.ZuzugKtSeitGeburt,
    PRS.ZuzugGdePLZ,
    PRS.ZuzugGdeOrtCode,
    PRS.ZuzugGdeOrt,
    PRS.ZuzugGdeKanton,
    PRS.ZuzugGdeLandCode,
    PRS.ZuzugGdeDatum,
    PRS.ZuzugGdeSeitGeburt,
    PRS.UntWohnsitzPLZ,
    PRS.UntWohnsitzOrt,
    PRS.UntWohnsitzKanton,
    PRS.UntWohnsitzLandCode,
    PRS.WegzugPLZ,
    PRS.WegzugOrtCode,
    PRS.WegzugOrt,
    PRS.WegzugKanton,
    PRS.WegzugLandCode,
    PRS.WegzugDatum,
    PRS.WohnsitzWieBaPersonID,
    PRS.AufenthaltWieBaInstitutionID,
    PRS.ErwerbssituationCode,
    PRS.GrundTeilzeitarbeit1Code,
    PRS.GrundTeilzeitarbeit2Code,
    PRS.BaGrundNichtErwerbstaetigCode,
    PRS.ErwerbsBrancheCode,
    PRS.ErlernterBerufCode,
    PRS.BerufCode,
    PRS.HoechsteAusbildungCode,
    PRS.AbgebrocheneAusbildungCode,
    PRS.ArbeitSpezFaehigkeiten,
    PRS.VerID,
    PRS.KbKostenstelleID,
    PRS.InCHSeit,
    PRS.InCHSeitGeburt,
    PRS.PUAnzahlVerlustscheine,
    PRS.PUKrankenkasse,
    PRS.PraemienuebernahmeVon,
    PRS.PraemienuebernahmeBis,
    PRS.PersonOhneLeistung,
    PRS.BaPersonTS,
    PRS.HCMCFluechtling,
    PRS.StellensuchendCode,
    PRS.ResoNr,
    PRS.NEAnmeldung,
    PRS.Creator,
    PRS.Created,
    PRS.Modifier,
    PRS.Modified,

    --PRS.*,

    NameVorname    = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
    VornameName    = IsNull(PRS.Vorname + ' ', '') + PRS.Name,
    NameVorname_AI = PRS.Name + IsNull(', ' + PRS.Vorname, '')  COLLATE Latin1_General_CI_AI,
    VornameName_AI = IsNull(PRS.Vorname + ' ', '') + PRS.Name COLLATE Latin1_General_CI_AI,
    [Alter]        = CONVERT(int, (DateDiff(dd, PRS.Geburtsdatum, GetDate()) + .5) / 365.25),
    AlterMortal    = dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum),

    Nationalitaet  = NAT.Text,
    Heimatort      = HEI.Name + IsNull(' ' + HEI.Kanton, ''),

    WohnsitzBaAdresseID     = ADR1.BaAdresseID,
    Wohnsitz                = IsNull(ADR1.Zusatz + ', ', '') +
                              IsNull(ADR1.Postfach + ', ', '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + ', ', '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzMehrzeilig      = IsNull(ADR1.Zusatz + char(13) + char(10), '') +
                              IsNull(ADR1.Postfach + char(13) + char(10), '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzAdressZusatz    = ADR1.Zusatz,
    WohnsitzStrasse         = ADR1.Strasse,
    WohnsitzStrasseCode     = ADR1.StrasseCode,
    WohnsitzHausNr          = ADR1.HausNr,
    WohnsitzStrasseHausNr   = ADR1.Strasse + IsNull(' ' + ADR1.HausNr, ''),
    WohnsitzPostfach        = ADR1.Postfach,
    WohnsitzPLZ             = ADR1.PLZ,
    WohnsitzOrt             = ADR1.Ort,
    WohnsitzPLZOrt          = IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzKanton          = ADR1.Kanton,
    WohnsitzLand            = LAN1.Text,
    WohnsitzOrtschaftCode   = ADR1.OrtschaftCode,
    WohnsitzLandCode        = LAN1.BaLandID,
    WohnsitzBemerkung       = ADR1.Bemerkung,
    WohnsitzDatumVon        = ADR1.DatumVon,
    WohnsitzDatumBis        = ADR1.DatumBis,

    AufenthaltBaAdresseID   = ADR3.BaAdresseID,
    Aufenthalt              = IsNull(INS3.Name + ', ', '') +
                              IsNull(ADR3.Zusatz + ', ', '') +
                              IsNull(ADR3.Postfach + ', ', '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + ', ', '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltMehrzeilig    = IsNull(INS3.Name + char(13) + char(10), '') +
                              IsNull(ADR3.Zusatz + char(13) + char(10), '') +
                              IsNull(ADR3.Postfach + char(13) + char(10), '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltAdressZusatz  = ADR3.Zusatz,
    AufenthaltStrasse       = ADR3.Strasse,
    AufenthaltHausNr        = ADR3.HausNr,
    AufenthaltStrasseHausNr = ADR3.Strasse + IsNull(' ' + ADR3.HausNr, ''),
    AufenthaltPostfach      = ADR3.Postfach,
    AufenthaltPLZ           = ADR3.PLZ,
    AufenthaltOrt           = ADR3.Ort,
    AufenthaltPLZOrt        = IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltKanton        = ADR3.Kanton,
    AufenthaltLand          = LAN3.Text,
    AufenthaltOrtschaftCode = ADR3.OrtschaftCode,
    AufenthaltLandCode      = LAN3.BaLandID,
    AufenthaltBemerkung     = ADR3.Bemerkung,

    AufenthaltBaInstitutionID = ADR3.BaInstitutionID,
    AufenthaltInstitutionName = INS3.Name,
    DisplayText               = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' +
                                IsNull(CONVERT(varchar,dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum)),'-') + ',' +
                                IsNull(GES.ShortText,'?') + ')',
    GeschlechtKurz            = GES.ShortText

  FROM dbo.BaPerson                    PRS WITH(READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaLand         NAT  WITH(READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
    LEFT OUTER JOIN dbo.BaGemeinde     HEI  WITH(READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeCode

    LEFT OUTER  JOIN dbo.BaAdresse     ADR1 WITH(READUNCOMMITTED) ON ADR1.BaPersonID = PRS.BaPersonID AND ADR1.AdresseCode = 1
                                                                 AND GetDate() BETWEEN IsNull(ADR1.DatumVon, GetDate()) AND IsNull(ADR1.DatumBis, GetDate())
    LEFT  OUTER JOIN dbo.BaLand        LAN1 WITH(READUNCOMMITTED) ON LAN1.BaLandID = ADR1.BaLandID

    LEFT  OUTER JOIN dbo.BaAdresse     ADR3 WITH(READUNCOMMITTED) ON ADR3.BaPersonID = PRS.BaPersonID AND ADR3.AdresseCode = 3
                                                                 AND GetDate() BETWEEN IsNull(ADR3.DatumVon, GetDate()) AND IsNull(ADR3.DatumBis, GetDate())
    LEFT  OUTER JOIN dbo.BaLand        LAN3 WITH(READUNCOMMITTED) ON LAN3.BaLandID = ADR3.BaLandID
    LEFT  OUTER JOIN dbo.XLOVCode      GES WITH(READUNCOMMITTED)  ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
    LEFT  OUTER JOIN dbo.BaInstitution INS3 WITH(READUNCOMMITTED) ON INS3.BaInstitutionID = ADR3.BaInstitutionID
  WHERE NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.BaAdresse WITH(READUNCOMMITTED)
                    WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 1
                      AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
                      AND BaAdresseID > ADR1.BaAdresseID)
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM dbo.BaAdresse  WITH(READUNCOMMITTED)
                    WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 3
                      AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
                      AND BaAdresseID > ADR3.BaAdresseID)

GO
GRANT SELECT ON [dbo].[vwPerson] TO [tools_access]
GO
GRANT SELECT ON [dbo].[vwPerson] TO [tools_sonar_ek_asyl_role]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson2.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson2.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwPerson2
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaPerson2.sql $
  $Author: Mmarghitola $
  $Modtime: 7.09.10 10:30 $
  $Revision: 1 $
=================================================================================================
  Description: vwPerson2 ergibt die gleichen Ergebnisse wie vwPerson, ist aber viel
               schneller, falls zu einer Person die Adresse gefunden werden muss.
               Bei der Suche nach einer Personen mit einer bestimmten Adresse ist vwPerson schneller.
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaPerson2.sql $
 * 
 * 1     7.09.10 15:12 Mmarghitola
 * #6587: vwBaPerson2 und vwInstitution2 hinzugefügt
 * 
=================================================================================================*/

CREATE VIEW [dbo].[vwPerson2]
AS

  SELECT
PRS.BaPersonID,
PRS.StatusPersonCode,
PRS.Titel,
[Name] = PRS.Name,
Name_AI = PRS.Name COLLATE Latin1_General_CI_AI,
PRS.FruehererName,
Vorname = PRS.Vorname,
Vorname_AI = PRS.Vorname COLLATE Latin1_General_CI_AI,
PRS.Vorname2,
PRS.Geburtsdatum,
PRS.Sterbedatum,
PRS.AHVNummer,
PRS.Versichertennummer,
PRS.HaushaltVersicherungsNummer,
PRS.NNummer,
PRS.BFFNummer,
PRS.ZIPNr,
PRS.KantonaleReferenznummer,
PRS.GeschlechtCode,
PRS.ZivilstandCode,
PRS.ZivilstandDatum,
PRS.HeimatgemeindeCode,
PRS.HeimatgemeindeCodes,
PRS.NationalitaetCode,
PRS.ReligionCode,
PRS.AuslaenderStatusCode,
PRS.AuslaenderStatusGueltigBis,
PRS.Telefon_P,
PRS.Telefon_G,
PRS.MobilTel1,
PRS.MobilTel2,
PRS.EMail,
PRS.SprachCode,
PRS.Unterstuetzt,
PRS.Fiktiv,
PRS.Bemerkung,
PRS.EinwohnerregisterAktiv,
PRS.DeutschVerstehenCode,
PRS.WichtigerHinweisCode,
PRS.ZuzugKtPLZ,
PRS.ZuzugKtOrtCode,
PRS.ZuzugKtOrt,
PRS.ZuzugKtKanton,
PRS.ZuzugKtLandCode,
PRS.ZuzugKtDatum,
PRS.ZuzugKtSeitGeburt,
PRS.ZuzugGdePLZ,
PRS.ZuzugGdeOrtCode,
PRS.ZuzugGdeOrt,
PRS.ZuzugGdeKanton,
PRS.ZuzugGdeLandCode,
PRS.ZuzugGdeDatum,
PRS.ZuzugGdeSeitGeburt,
PRS.UntWohnsitzPLZ,
PRS.UntWohnsitzOrt,
PRS.UntWohnsitzKanton,
PRS.UntWohnsitzLandCode,
PRS.WegzugPLZ,
PRS.WegzugOrtCode,
PRS.WegzugOrt,
PRS.WegzugKanton,
PRS.WegzugLandCode,
PRS.WegzugDatum,
PRS.WohnsitzWieBaPersonID,
PRS.AufenthaltWieBaInstitutionID,
PRS.ErwerbssituationCode,
PRS.GrundTeilzeitarbeit1Code,
PRS.GrundTeilzeitarbeit2Code,
PRS.ErwerbsBrancheCode,
PRS.ErlernterBerufCode,
PRS.BerufCode,
PRS.HoechsteAusbildungCode,
PRS.AbgebrocheneAusbildungCode,
PRS.ArbeitSpezFaehigkeiten,
PRS.VerID,
PRS.KbKostenstelleID,
PRS.InCHSeit,
PRS.InCHSeitGeburt,
PRS.PUAnzahlVerlustscheine,
PRS.PUKrankenkasse,
PRS.PraemienuebernahmeVon,
PRS.PraemienuebernahmeBis,
PRS.PersonOhneLeistung,
PRS.BaPersonTS,
PRS.HCMCFluechtling,
PRS.StellensuchendCode,
PRS.ResoNr,
PRS.NEAnmeldung,
PRS.Creator,
PRS.Created,
PRS.Modifier,
PRS.Modified,

--PRS.*,

    NameVorname    = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
    VornameName    = IsNull(PRS.Vorname + ' ', '') + PRS.Name,
    NameVorname_AI = PRS.Name + IsNull(', ' + PRS.Vorname, '')  COLLATE Latin1_General_CI_AI,
    VornameName_AI = IsNull(PRS.Vorname + ' ', '') + PRS.Name COLLATE Latin1_General_CI_AI,
    [Alter]        = CONVERT(int, (DateDiff(dd, PRS.Geburtsdatum, GetDate()) + .5) / 365.25),
    AlterMortal    = dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum),

    Nationalitaet  = NAT.Text,
    Heimatort      = HEI.Name + IsNull(' ' + HEI.Kanton, ''),

    WohnsitzBaAdresseID     = ADR1.BaAdresseID,
    Wohnsitz                = IsNull(ADR1.AdressZusatz + ', ', '') +
                              IsNull(ADR1.Postfach + ', ', '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + ', ', '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzMehrzeilig      = IsNull(ADR1.AdressZusatz + char(13) + char(10), '') +
                              IsNull(ADR1.Postfach + char(13) + char(10), '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzAdressZusatz    = ADR1.AdressZusatz,
    WohnsitzStrasse         = ADR1.Strasse,
    WohnsitzStrasseCode     = ADR1.StrasseCode,
    WohnsitzHausNr          = ADR1.HausNr,
    WohnsitzStrasseHausNr   = ADR1.Strasse + IsNull(' ' + ADR1.HausNr, ''),
    WohnsitzPostfach        = ADR1.Postfach,
    WohnsitzPLZ             = ADR1.PLZ,
    WohnsitzOrt             = ADR1.Ort,
    WohnsitzPLZOrt          = IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzKanton          = ADR1.Kanton,
    WohnsitzLand            = LAN1.Text,
    WohnsitzOrtschaftCode   = ADR1.OrtschaftCode,
    WohnsitzLandCode        = LAN1.BaLandID,
    WohnsitzBemerkung       = ADR1.Bemerkung,
    WohnsitzDatumVon        = ADR1.DatumVon,
    WohnsitzDatumBis        = ADR1.DatumBis,

    AufenthaltBaAdresseID   = ADR3.BaAdresseID,
    Aufenthalt              = IsNull(INS3.Name + ', ', '') +
                              IsNull(ADR3.AdressZusatz + ', ', '') +
                              IsNull(ADR3.Postfach + ', ', '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + ', ', '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltMehrzeilig    = IsNull(INS3.Name + char(13) + char(10), '') +
                              IsNull(ADR3.AdressZusatz + char(13) + char(10), '') +
                              IsNull(ADR3.Postfach + char(13) + char(10), '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltAdressZusatz  = ADR3.AdressZusatz,
    AufenthaltStrasse       = ADR3.Strasse,
    AufenthaltHausNr        = ADR3.HausNr,
    AufenthaltStrasseHausNr = ADR3.Strasse + IsNull(' ' + ADR3.HausNr, ''),
    AufenthaltPostfach      = ADR3.Postfach,
    AufenthaltPLZ           = ADR3.PLZ,
    AufenthaltOrt           = ADR3.Ort,
    AufenthaltPLZOrt        = IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltKanton        = ADR3.Kanton,
    AufenthaltLand          = LAN3.Text,
    AufenthaltOrtschaftCode = ADR3.OrtschaftCode,
    AufenthaltLandCode      = LAN3.BaLandID,
    AufenthaltBemerkung     = ADR3.Bemerkung,

    AufenthaltBaInstitutionID = ADR3.BaInstitutionID,
    AufenthaltInstitutionName = INS3.Name,
    DisplayText               = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' +
                                IsNull(CONVERT(varchar,dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum)),'-') + ',' +
                                IsNull(GES.ShortText,'?') + ')',
    GeschlechtKurz            = GES.ShortText

  FROM dbo.BaPerson               PRS WITH(READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaLand					NAT  WITH(READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
    LEFT  OUTER JOIN dbo.BaGemeinde     HEI  WITH(READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeCode

    OUTER APPLY
    (
      SELECT TOP 1 BaLandID,
    BaAdresseID,
    AdressZusatz = Zusatz,
    Postfach,
    Strasse, HausNr,
    PLZ, Ort, StrasseCode, Kanton, Bemerkung, DatumVon, DatumBis, OrtschaftCode
      FROM dbo.BaAdresse ADR_I1
      WHERE ADR_I1.BaPersonID = PRS.BaPersonID AND ADR_I1.AdresseCode = 1 AND
        GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY BaAdresseID DESC
    ) ADR1
    LEFT  OUTER JOIN dbo.BaLand					LAN1 WITH(READUNCOMMITTED) ON LAN1.BaLandID = ADR1.BaLandID

    OUTER APPLY
    (
      SELECT TOP 1 BaLandID,
    BaAdresseID,
    AdressZusatz = Zusatz,
    Postfach,
    Strasse, HausNr,
    PLZ, Ort, BaInstitutionID, Kanton, Bemerkung, OrtschaftCode
      FROM dbo.BaAdresse ADR_I2
      WHERE ADR_I2.BaPersonID = PRS.BaPersonID AND ADR_I2.AdresseCode = 3 AND
        GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY BaAdresseID DESC
    ) ADR3
    LEFT  OUTER JOIN dbo.BaLand					LAN3 WITH(READUNCOMMITTED) ON LAN3.BaLandID = ADR3.BaLandID
    LEFT  OUTER JOIN dbo.XLOVCode       GES WITH(READUNCOMMITTED)  ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
    LEFT  OUTER JOIN dbo.BaInstitution  INS3 WITH(READUNCOMMITTED) ON INS3.BaInstitutionID = ADR3.BaInstitutionID


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson2.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwPerson2.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwVmGetMTName.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwVmGetMTName.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwVmGetMTName
GO

CREATE VIEW [dbo].[vwVmGetMTName]
AS

SELECT     LEI.BaPersonID, LEI.DatumVon, LEI.DatumBis, [User] = USR.NameVorname + ' (' + USR.OrgUnit + ')'
FROM         dbo.FaLeistung AS LEI
  INNER JOIN dbo.vwUser AS USR ON LEI.UserID = USR.UserID
WHERE     (LEI.FaProzessCode = 210)

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwVmGetMTName.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwVmGetMTName.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwInstitution
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwInstitution.sql $
  $Author: Mmarghitola $
  $Modtime: 18.08.10 14:47 $
  $Revision: 5 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwInstitution.sql $
 * 
 * 5     18.08.10 14:55 Mmarghitola
 * Sternchen in View aufgrund von Risiken (Schemaänderungen in zu Grunde
 * liegender Tabelle führen zu inkonsistenter Ansicht) entfernt
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwInstitution]
AS
  SELECT
    INS.[BaInstitutionID],
    INS.[Name],
    [InstitutionName] = INS.[Name],
    INS.[InstitutionTypCode],
    INS.[Debitor],
    INS.[Kreditor],
    INS.[Telefon],
    INS.[Fax],
    INS.[EMail],
    INS.[SprachCode],
    INS.[Bemerkung],
    INS.[Aktiv],
    INS.[Anrede],
    INS.[Homepage],
    INS.[BaFreigabeStatusCode],
    INS.[DefinitivUserID],
    INS.[DefinitivDatum],
    INS.[Creator],
    INS.[Created],
    INS.[ErstelltUserID],
    [ErstelltDatum] = INS.[Created],
    INS.[Modifier],
    INS.[Modified],
    INS.[MutiertUserID],
    [MutiertDatum] = INS.[Modified],
    INS.[BaInstitutionTS],
    Typ               = TYP.Text,
    Adresse           = IsNull(ADR.Zusatz + ', ', '') +
                        IsNull(ADR.Postfach + ', ', '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + ', ', '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    AdresseMehrzeilig = IsNull(ADR.Zusatz + char(13) + char(10), '') +
                        IsNull(ADR.Postfach + char(13) + char(10), '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + char(13) + char(10), '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    OrtStrasse        = IsNull(ADR.Ort, '') + IsNull(', ' + ADR.Strasse + IsNull(' ' + ADR.HausNr, ''), ''),
    AdressZusatz      = ADR.Zusatz,
    ADR.Strasse,
    ADR.HausNr,
    StrasseHausNr     = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
    ADR.Postfach,
    ADR.PLZ,
    ADR.Ort,
    PLZOrt            = IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    ADR.Kanton,
    Land              = LAN.Text,
    OrtschaftCode     = ADR.OrtschaftCode,
    LandCode          = LAN.BaLandID
  FROM dbo.BaInstitution           INS WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaAdresse  ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND ADR.BaPersonID IS NULL
    LEFT OUTER JOIN dbo.BaLand     LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
    LEFT OUTER JOIN dbo.XLOVCode   TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode
  WHERE NOT EXISTS (SELECT * FROM dbo.BaAdresse WITH (READUNCOMMITTED)
                    WHERE BaInstitutionID = INS.BaInstitutionID AND BaPersonID IS NULL
                      AND BaAdresseID > ADR.BaAdresseID)

GO
GRANT SELECT ON [dbo].[vwInstitution] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwZahlungsweg.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwZahlungsweg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwZahlungsweg.sql $
  $Author: Rstahel $
  $Modtime: 30.05.10 22:01 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwZahlungsweg.sql $
 * 
 * 4     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 19.05.2008
Description: Zahlungsweg suchen nur Krediotren-Buchungen
===================================================================================================
Tests:
select * from vwZahlungsweg
===================================================================================================
History:
--------
19.05.2008 : sozheo : neu erstellt
===================================================================================================
*/

CREATE VIEW [dbo].[vwZahlungsweg]
AS

--set rowcount 1000
SELECT
  BaZahlungswegID = Z.BaZahlungswegID,
  EinzahlungsscheinCode = Z.EinzahlungsscheinCode,
  Glaeubiger_BaPersonID = Z.BaPersonID,
  Glaeubiger_BaInstitutionID = Z.BaInstitutionID,
  Glaeubiger_BaBankID = Z.BaBankID,
  Glaeubiger_PCKontoNr = Z.PostKontoNummer,
  Glaeubiger_BankKontoNr = Z.BankKontoNummer,
  Glaeubiger_IBAN = Z.IBANNummer,
  Glaeubiger_BankName = B.Name,
  Glaeubiger_BankStrasse = B.Strasse,
  Glaeubiger_BankPLZ = B.PLZ,
  Glaeubiger_BankOrt = B.Ort,
  Glaeubiger_Bank_BCN = B.ClearingNr,
  Glaeubiger_Name = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName
    WHEN Z.BaPersonID IS NULL THEN I.Name
    ELSE P.NameVorname
  END,
  Glaeubiger_Name2 = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseName2
    WHEN Z.BaPersonID IS NULL THEN I.AdressZusatz
    ELSE P.WohnsitzAdressZusatz
  END,
  Glaeubiger_Strasse = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseStrasse
    WHEN Z.BaPersonID IS NULL THEN I.Strasse
    ELSE P.WohnsitzStrasse
  END,
  Glaeubiger_HausNr = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN NULL
    WHEN Z.BaPersonID IS NULL THEN I.HausNr
    ELSE P.WohnsitzHausNr
  END,
  Glaeubiger_PLZ = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePLZ
    WHEN Z.BaPersonID IS NULL THEN I.PLZ
    ELSE P.WohnsitzPLZ
  END,
  Glaeubiger_Ort = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseOrt
    WHEN Z.BaPersonID IS NULL THEN I.Ort
    ELSE P.WohnsitzOrt
  END,
  Glaeubiger_Postfach = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdressePostfach
    WHEN Z.BaPersonID IS NULL THEN I.Postfach
    ELSE P.WohnsitzPostfach
  END,
  Glaeubiger_LandCode = CASE
    WHEN Z.AdresseName IS NOT NULL AND Z.AdressePLZ IS NOT NULL AND Z.AdresseOrt IS NOT NULL THEN Z.AdresseLandCode
    WHEN Z.BaPersonID IS NULL THEN I.LandCode
    ELSE P.WohnsitzLandCode
  END,
  Glauebiger_Auszahlungsart = XLE.Value1
FROM dbo.BaZahlungsweg Z WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.BaBank B WITH (READUNCOMMITTED) ON B.BaBankID = CASE
    WHEN Z.BaBankID IS NULL AND Z.PostKontoNummer IS NOT NULL THEN (
      SELECT PB.BaBankID FROM dbo.BaBank PB WITH (READUNCOMMITTED)
      WHERE PB.ClearingNr = '9000' )
    ELSE Z.BaBankID
  END
  LEFT OUTER JOIN dbo.vwPerson P ON P.BaPersonID = Z.BaPersonID
  LEFT OUTER JOIN dbo.vwInstitution I ON I.BaInstitutionID = Z.BaInstitutionID
  LEFT JOIN dbo.XLOVCode XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = Z.EinzahlungsscheinCode

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwZahlungsweg.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaZahlungsweg.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBaZahlungsweg
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaZahlungsweg.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaZahlungsweg.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwBaZahlungsweg]
AS

SELECT
		ZAL.BaZahlungswegID,
		ZAL.BaPersonID,
		ZAL.BaInstitutionID,
		ZAL.DatumVon,
		ZAL.DatumBis,
		ZAL.EinzahlungsscheinCode,
		ZAL.ZahlinformationAktiv,
		ZAL.BaBankID,
		ZAL.BankKontoNummer,
		ZAL.IBANNummer,
		ZAL.PostKontoNummer,
		ZAL.ESRTeilnehmer,
		ZAL.AdresseName,
		ZAL.AdresseName2,
		ZAL.AdresseStrasse,
		ZAL.AdresseHausNr,
		ZAL.AdressePostfach,
		ZAL.AdressePLZ,
		ZAL.AdresseOrt,
		ZAL.AdresseLandCode,
		ZAL.BaZahlwegModulStdCodes,
		ZAL.BaZahlungswegTS,
		ZAL.IsZkbVmKonto,
		ZAL.WMAVerwenden,
		[Name]     = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN IsNull(PRS.Vorname + ' ', '') + PRS.Name
												ELSE INS.Name END,
		Adresse		 = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.Wohnsitz
												ELSE INS.Adresse END,
		Empfaenger = CASE		WHEN ZAL.BaPersonID IS NOT NULL THEN IsNull( PRS.Vorname + ' ', '') + PRS.Name + IsNull( ', ' + PRS.Wohnsitz, '')
												ELSE INS.Name + IsNull( ', ' + INS.Adresse, '') END
FROM
		dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED)
		LEFT OUTER JOIN vwPerson      PRS ON PRS.BaPersonID      = ZAL.BaPersonID
		LEFT OUTER JOIN vwInstitution INS ON INS.BaInstitutionID = ZAL.BaInstitutionID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBaZahlungsweg]  TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaZahlungsweg.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBaZahlungsweg.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBgPosition.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBgPosition.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwBgPosition
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBgPosition.sql $
  $Author: Mmarghitola $
  $Modtime: 19.08.10 16:44 $
  $Revision: 9 (Version 10 wurde rollbacked)
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBgPosition.sql $
 * 
 * 7     19.08.10 16:45 Mmarghitola
 * Anpassen line-endings
 * 
 * 6     19.08.10 9:42 Mmarghitola
 * fehlendes Komma ergänzt
 * 
 * 5     19.08.10 9:40 Mmarghitola
 * falsche Spalten entfernt.
 * 
 * 4     18.08.10 14:55 Mmarghitola
 * Sternchen in View aufgrund von Risiken (Schemaänderungen in zu Grunde
 * liegender Tabelle führen zu inkonsistenter Ansicht) entfernt
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwBgPosition]
AS
  SELECT
    BPO.[BgPositionID],
    BPO.[BgBudgetID],
    BPO.[BgKategorieCode],
    BPO.[DatumVon],
    BPO.[DatumBis],
    BPO.[BgPositionID_CopyOf],
    BPO.[BgPositionID_Parent],
    BPO.[BaPersonID],
    BPO.[BaInstitutionID],
    BPO.[DebitorBaPersonID],
    BPO.[BgPositionsartID],
    BPO.[Buchungstext],
    BPO.[Betrag],
    BPO.[Reduktion],
    BPO.[Abzug],
    BPO.[MaxBeitragSD],
    BPO.[BgSpezkontoID],
    BPO.[Bemerkung],
    BPO.[VerwPeriodeVon],
    BPO.[VerwPeriodeBis],
    BPO.[FaelligAm],
    BPO.[RechnungDatum],
    BPO.[BetragAnfrage],
    BPO.[VerwaltungSD],
    BPO.[BgBewilligungStatusCode],
    BPO.[BewilligtVon],
    BPO.[BewilligtBis],
    BPO.[BewilligtBetrag],
    BPO.[FPPosition],
    BPO.[Value1],
    BPO.[Value2],
    BPO.[Value3],
    BPO.[BetragGBLAufAusgabekonto],
    BPO.[ErstelltUserID],
    BPO.[ErstelltDatum],
    BPO.[MutiertUserID],
    BPO.[MutiertDatum],
    BPO.[BgPositionTS],
    BPO.[Hidden],
    BPO.[BgPositionID_AutoForderung],
    BPO.[Rechnungsnummer],
    BetragFinanzplan = CASE
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,   -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(CONVERT(money, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                               FROM dbo.BgPosition SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND GetDate() BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') ))))
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      ELSE CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
    END,
    BetragBudget = CASE
      WHEN BPO.BgPositionsartID IN (32011, 32015, 32016, 32017, 32018, 32019,3102)
                                                          THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug - IsNull(
                                                              (SELECT SUM(Betrag - Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                               FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                                               WHERE BgBudgetID = BPO.BgBudgetID AND BgPositionsartID IN (32021, 32022) AND MaxBeitragSD = $0.00
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )
                                                             , $0.00)))
      WHEN BPO.BgPositionsartID IN (32021, 32022)         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, dbo.fnMIN(BPO.Betrag - BPO.Reduktion - BPO.Abzug,  -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(CONVERT(money, dbo.fnMIN(MaxBeitragSD, Betrag - Reduktion - Abzug))), $0.00)
                                                               FROM dbo.BgPosition SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') ))))
      ELSE CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - BPO.Abzug))
    END,
    BetragRechnung = CASE
      WHEN BPO.BgPositionsartID IN (32011, 32015, 32016, 32017, 32018, 32019,3102)
                                                          THEN CONVERT(money, dbo.fnMIN(BPO.MaxBeitragSD, BPO.Betrag - BPO.Reduktion - IsNull(
                                                              (SELECT SUM(Betrag - Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
                                                               FROM dbo.BgPosition WITH (READUNCOMMITTED)
                                                               WHERE BgBudgetID = BPO.BgBudgetID AND BgPositionsartID IN (32021, 32022) AND MaxBeitragSD = $0.00
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )
                                                             , $0.00)))
      WHEN BPO.BgPositionsartID BETWEEN 39100 AND 39199
        AND BPO.BgPositionsartID != SPT.BgGruppeCode THEN CONVERT(money, dbo.fnMIN(BPO.Betrag - BPO.Reduktion,   -- EFB <= Erwerbseinkommen
                                                              (SELECT IsNull(SUM(Betrag - Reduktion), $0.00)
                                                               FROM dbo.BgPosition             SBPO WITH (READUNCOMMITTED)
                                                                 INNER JOIN dbo.BgPositionsart  SBPT WITH (READUNCOMMITTED) ON SBPT.BgPositionsartID = SBPO.BgPositionsartID
                                                               WHERE SBPO.BgBudgetID = BPO.BgBudgetID AND SBPO.BaPersonID = BPO.BaPersonID AND SBPT.BgGruppeCode = 3101
                                                                 AND CASE WHEN BBG.MasterBudget = 1 THEN GetDate() ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15) END BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') )))
      WHEN BPO.BgPositionsartID IN (32021, 32022)         THEN BPO.Betrag - BPO.Reduktion - BPO.Abzug   -- VVG
      WHEN BPO.BgPositionsartID = 60901                   THEN BPO.Betrag -- Asyl-Nettolohn: Quellsteuer nicht abziehen
      ELSE BPO.Betrag - BPO.Reduktion
    END
  FROM dbo.BgPosition BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget       BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID = BPO.BgBudgetID
    LEFT OUTER JOIN dbo.BgPositionsart  SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = BPO.BgPositionsartID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwBgPosition]  TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBgPosition.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwBgPosition.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwEkEntscheid.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwEkEntscheid.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwEkEntscheid
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwEkEntscheid.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:53 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwEkEntscheid.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwEkEntscheid]
AS
SELECT     WKE.WhEkEntscheidID, WKE.Datum, WKE.BaPersonID, PRS.Name, PRS.Vorname, PRS.NNummer, FAL.FaFallID,
                      WKE.Bemerkung, WKE.EntscheidJahr, WKE.EntscheidKW, WKE.EntscheidLaufNr,
                      LEI.UserID, WKE.WhVerfuegungGrundCode, XLC.Text, XLC.ShortText, TeamID = ORG.OrgUnitID, Team = ORG.ItemName
FROM         dbo.WhEkEntscheid WKE WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON WKE.FaLeistungID = LEI.FaLeistungID
  INNER JOIN dbo.FaFall       FAL WITH (READUNCOMMITTED) ON FAL.FaFallID     = LEI.FaFallID
  INNER JOIN dbo.XLOVCode     XLC WITH (READUNCOMMITTED) ON XLC.LOVName      = 'WhVerfuegungGrund' AND XLC.Code = WKE.WhVerfuegungGrundCode
  INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID   = WKE.BaPersonID
--  INNER JOIN dbo.XUser        USR ON USR.UserID       = LEI.UserID
  INNER JOIN dbo.XOrgUnit_User O2U WITH (READUNCOMMITTED) ON O2U.UserID       = LEI.UserID AND OrgUnitMemberCode = 2 /*Mitglied*/
  INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID    = O2U.OrgUnitID
WHERE     (WKE.EntscheidJahr IS NOT NULL) AND (WKE.EntscheidKW IS NOT NULL) --AND (WKE.EntscheidLaufNr IS NULL)

--lov WhVerfuegungGrund

--lov whekstatus
/*
select Top 10 *
from BaPerson

select *
from XOrgUnit


*/
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT SELECT ON [dbo].[vwEkEntscheid] TO [tools_access]
GO
GRANT SELECT ON [dbo].[vwEkEntscheid] TO [tools_sonar_ek_asyl_role]
GO
GRANT  UPDATE  ON [dbo].[vwEkEntscheid] (
	[EntscheidLaufNr]
	) TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwEkEntscheid.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwEkEntscheid.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstIKAuszug.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstIKAuszug.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwSstIKAuszug;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwSstIKAuszug;
=================================================================================================*/

CREATE VIEW dbo.vwSstIKAuszug
AS
SELECT  [SstIKAuszugID],
        [BaPersonID],
        [AnforderungDatum],
        [SstIkAuszugAnforderungCode],
        [AnforderungUserID],
        [Versichertennummer],
        [JahrVon],
        [JahrBis],
        [MessageID],
        [ExportDatum],
        [ExportXML],
        [ImportDatum],
        [ImportXML],
        [ImportFehlermeldung],
        [DocumentID],
        [Deaktiviert],
        [Creator]  = IKATEMP.[Creator],
        [Created]  = IKATEMP.[Created],
        [Modifier] = IKATEMP.[Modifier],
        [Modified] = IKATEMP.[Modified],
        [SstIKAuszugTS],
        [SstIkAuszugStatusCode],
        [Bemerkung] = CASE 
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 1 THEN 'Automatische Anfrage (Grund: Genehmigung 1.Finanzplan)'
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 2 THEN 'Automatische Anfrage (Grund: WSH seit 2 Jahren) '
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 3 THEN 'Automatische Anfrage (Grund: WSH seit 5 Jahren) '
                        WHEN IKATEMP.SstIkAuszugAnforderungCode = 4
                         AND IKATEMP.SstIkAuszugStatusCode IN (1, 2, 3, 4) THEN 'Manuelle Anfrage' + ISNULL(' durch ' + USR.LogonName, '')
                        ELSE ''
                      END + 
                      CASE 
                        WHEN IKATEMP.SstIkAuszugStatusCode IN (2, 4) THEN ', bei SVA bestellt'  -- Also in case of Import-Error (Decision by Claudia Corrodi)
                        WHEN IKATEMP.SstIkAuszugStatusCode = 3 THEN ', Auszug wird erstellt'
                        ELSE ''
                      END
FROM (SELECT [SstIKAuszugID],
             [BaPersonID],
             [AnforderungDatum],
             [SstIkAuszugAnforderungCode],
             [AnforderungUserID],
             [Versichertennummer],
             [JahrVon],
             [JahrBis],
             [MessageID],
             [ExportDatum],
             [ExportXML],
             [ImportDatum],
             [ImportXML],
             [ImportFehlermeldung],
             [DocumentID],
             [Deaktiviert],
             [Creator],
             [Created],
             [Modifier],
             [Modified],
             [SstIKAuszugTS],
             [SstIkAuszugStatusCode] = CASE 
                                         WHEN Deaktiviert = 1 THEN 6   -- Deaktiviert
                                         WHEN ExportDatum IS NULL THEN 1 -- Angefordert
                                         WHEN ExportDatum > ISNULL(ImportDatum, '1900-01-01') THEN 2 -- Exportiert
                                         WHEN ImportDatum IS NOT NULL
                                          AND ImportDatum > ExportDatum
                                           THEN CASE 
                                                  WHEN ImportFehlermeldung IS NOT NULL THEN 4 -- Importiert mit Fehler
                                                  WHEN DocumentID IS NULL THEN 3 -- Importiert, PDF noch pendent
                                                  ELSE 5  -- Importiert, PDF erstellt
                                                END
                                       END
      FROM dbo.SstIKAuszug IKA WITH (READUNCOMMITTED)) IKATEMP
  LEFT JOIN dbo.XUser                                  USR  WITH (READUNCOMMITTED) ON USR.UserID = IKATEMP.AnforderungUserID;

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstIKAuszug.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstIKAuszug.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwFaDokumente.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwFaDokumente.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwFaDokumente
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwFaDokumente.sql $
  $Author: Mmarghitola $
  $Modtime: 20.09.10 18:56 $
  $Revision: 10 $
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

=================================================================================================*/

CREATE VIEW [dbo].[vwFaDokumente]
AS

SELECT [FaDokumenteID]
      ,[FaLeistungID]
      ,[Vertraulich]
      ,[DatumErstellung]
      ,[FaDokStatusCode]
      ,[StatusLetztUserID]
      ,[StatusLetztDatum]
      ,[Absender]
      ,[Absender_Freitext]
      ,[Adressat]
      ,[Adressat_Freitext]
      ,[Stichwort]
      ,[FaDokVerwendungCode]
      ,[DocumentID]
      ,[FaDokThemaCode]
      ,[BaPersonID]
      ,[VisumXTaskID]
      ,[FaDokVisumStatusCode]
      ,[VisumStatusDatum]
      ,[VisumStatusUserID]
      ,[Bemerkung]
      ,[NichtKlibuRelevant]
      ,[ErstelltUserID]
      ,[ErstelltDatum]
      ,[MutiertUserID]
      ,[MutiertDatum]
      ,[FaDokumenteTS]
      ,[MigHerkunftCode]
  FROM [dbo].[FaDokumente]
   
UNION ALL

-- Generierte IK-Auszüge mit den FaDokumenten dynamisch zusammen darstellen und zwar in allen relevanten Fällen (ohne dafür für jeden Fall ein neues FaDokument zu erzeugen)
SELECT 
	[FaDokumenteID] = -1,
	[FaLeistungID] = LEI.FaLeistungID,
	[Vertraulich] = 0,	-- Nicht vertraulich
	[DatumErstellung] = IKA.ImportDatum,
	[FaDokStatusCode] = 2,	-- FaDokStatusCode aktuell
	[StatusLetztUserID] = NULL,
	[StatusLetztDatum] = NULL,
	[Absender] = (SELECT TOP 1 BaInstitutionID FROM BaInstitution WHERE Name = 'SVA Zürich'),
	[Absender_Freitext] = NULL,
	[Adressat] = NULL,
	[Adressat_Freitext] = NULL,
	[Stichwort] = 'SVA: IK-Auszug von ' + CONVERT(varchar, IKA.JahrVon) + ' bis ' + CONVERT(varchar, IKA.JahrBis) + ' für ' + PER.NameVorname, -- Stichwort
	[FaDokVerwendungCode] = 1, -- FaDokVerwendung	Eingang
	[DocumentID] = IKA.DocumentID,
	[FaDokThemaCode] = 5, -- 5	Versicherungen und Ersatzeinkommen 
	[BaPersonID] = PER.BaPersonID,
	[VisumXTaskID] = NULL,
	[FaDokVisumStatusCode] = NULL,
	[VisumStatusDatum] = NULL,
	[VisumStatusUserID] = NULL,
	[Bemerkung] =
		CASE 
			WHEN IKA.SstIkAuszugAnforderungCode = 1 THEN 'Automatisch angeforderter IK-Auszug (Grund: Genehmigung 1.Finanzplan)'
			WHEN IKA.SstIkAuszugAnforderungCode = 2 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 2 Jahren)'
			WHEN IKA.SstIkAuszugAnforderungCode = 3 THEN 'Automatisch angeforderter IK-Auszug (Grund: WSH seit 5 Jahren)'
			WHEN IKA.SstIkAuszugAnforderungCode = 4 THEN 'Manuell angeforderter IK-Auszug' + ISNULL(' durch ' + USR.DisplayText, '')
			ELSE ''
		END,
	[NichtKlibuRelevant] = 0,
	[ErstelltUserID] = NULL,
	[ErstelltDatum] = NULL,
	[MutiertUserID] = NULL,
	[MutiertDatum] = NULL,
	[FaDokumenteTS] = NULL,
	[MigHerkunftCode] = NULL
FROM vwSstIKAuszug IKA
	INNER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.BaPersonID = IKA.BaPersonID 
	LEFT JOIN dbo.vwUser USR WITH (READUNCOMMITTED) ON USR.UserID = IKA.AnforderungUserID
	INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID FROM FaLeistung WHERE FaFallID = FAP.FaFallID AND FaProzessCode = 200 ORDER BY DatumVon DESC)	-- Aktuellste aktive Fallführung
	INNER JOIN dbo.vwPersonSimple PER WITH (READUNCOMMITTED) ON PER.BaPersonID = IKA.BaPersonID
WHERE IKA.DocumentID IS NOT NULL AND IKA.Deaktiviert = 0



GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwFaDokumente.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwFaDokumente.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution2.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution2.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwInstitution2
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwInstitution2.sql $
  $Author: Mmarghitola $
  $Modtime: 7.09.10 10:49 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Liefert die gleiche Daten wie vwInstitution. vwInstitution2 ist schneller, falls
    für eine Institution eine Adresse gefunden werden muss. vwInstitution ist schneller, falls
    zu einer Adresse eine Institution gefunden werden muss
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwInstitution2.sql $
 * 
 * 1     7.09.10 15:12 Mmarghitola
 * #6587: vwBaPerson2 und vwInstitution2 hinzugefügt
 * 
=================================================================================================*/

CREATE VIEW [dbo].[vwInstitution2]
AS
  SELECT
    INS.[BaInstitutionID],
    INS.[Name],
    InstitutionName = INS.[Name],
    INS.[InstitutionTypCode],
    INS.[Debitor],
    INS.[Kreditor],
    INS.[Telefon],
    INS.[Fax],
    INS.[EMail],
    INS.[SprachCode],
    INS.[Bemerkung],
    INS.[Aktiv],
    INS.[Anrede],
    INS.[Homepage],
    INS.[BaFreigabeStatusCode],
    INS.[DefinitivUserID],
    INS.[DefinitivDatum],
    INS.[Creator],
    INS.[Created],
    INS.[ErstelltUserID],
    [ErstelltDatum] = INS.[Created],
    INS.[Modifier],
    INS.[Modified],
    INS.[MutiertUserID],
    [MutiertDatum] = INS.[Modified],
    INS.[BaInstitutionTS],
    Typ               = TYP.Text,
    Adresse           = IsNull(ADR.Zusatz + ', ', '') +
                        IsNull(ADR.Postfach + ', ', '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + ', ', '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    AdresseMehrzeilig = IsNull(ADR.Zusatz + char(13) + char(10), '') +
                        IsNull(ADR.Postfach + char(13) + char(10), '') +
                        IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr, '') + char(13) + char(10), '') +
                        IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    OrtStrasse        = IsNull(ADR.Ort, '') + IsNull(', ' + ADR.Strasse + IsNull(' ' + ADR.HausNr, ''), ''),
    AdressZusatz      = ADR.Zusatz,
    ADR.Strasse,
    ADR.HausNr,
    StrasseHausNr     = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
    ADR.Postfach,
    ADR.PLZ,
    ADR.Ort,
    PLZOrt            = IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    ADR.Kanton,
    Land              = LAN.Text,
    OrtschaftCode     = ADR.OrtschaftCode,
    LandCode          = LAN.BaLandID
  FROM dbo.BaInstitution      INS WITH (READUNCOMMITTED)
    LEFT OUTER JOIN dbo.XLOVCode   TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode
    OUTER APPLY
    (
      SELECT TOP 1 ADR2.Zusatz, ADR2.Strasse, ADR2.HausNr, ADR2.Ort, ADR2.Kanton, ADR2.OrtschaftCode,
        ADR2.Postfach, ADR2.PLZ, ADR2.BaLandID
      FROM dbo.BaAdresse ADR2
      WHERE ADR2.BaInstitutionID = INS.BaInstitutionID
      ORDER BY ADR2.BaAdresseID DESC
    ) ADR
    LEFT OUTER JOIN dbo.BaLand		 LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution2.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwInstitution2.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKgBuchung
GO

CREATE VIEW [dbo].[vwKgBuchung] AS
SELECT
  BUC.KgBuchungID,
  BUC.KgPeriodeID,
  BUC.KgPositionID,
  BUC.KgBuchungTypCode,
  BUC.KgAusgleichStatusCode,
  BUC.KgZahlungseingangID,
  BUC.CodeVorlage,
  BUC.BelegNr,
  BUC.BelegNrPos,
  BUC.BuchungsDatum,
  BUC.SollKtoNr,
  BUC.HabenKtoNr,
  BUC.Betrag,
  BUC.BetragFW,
  BUC.FbWaehrungID,
  BUC.Text,
  BUC.ValutaDatum,
  BUC.BarbezugDatum,
  BUC.TransferDatum,
  BUC.KgBuchungStatusCode,
  BUC.UserIDKasse,
  BUC.BaZahlungswegID,
  BUC.BaInstitutionID,
  BUC.EinzahlungsscheinCode,
  BUC.KgAuszahlungsArtCode,
  BUC.BaBankID,
  BUC.BankKontoNummer,
  BUC.IBANNummer,
  BUC.PostKontoNummer,
  BUC.ESRTeilnehmer,
  BUC.ESRReferenznummer,
  BUC.BeguenstigtName,
  BUC.BeguenstigtName2,
  BUC.BeguenstigtStrasse,
  BUC.BeguenstigtHausNr,
  BUC.BeguenstigtPostfach,
  BUC.BeguenstigtOrt,
  BUC.BeguenstigtPLZ,
  BUC.BeguenstigtLandCode,
  BUC.MitteilungZeile1,
  BUC.MitteilungZeile2,
  BUC.MitteilungZeile3,
  BUC.MitteilungZeile4,
  BUC.ErstelltUserID,
  BUC.ErstelltDatum,
  BUC.MutiertUserID,
  BUC.MutiertDatum,
  BUC.KgBuchungTS,
  BUC.PscdFehlermeldung,
  BUC.PscdBelegNr,
  BUC.StorniertKgBuchungID,
  BUC.NeubuchungVonKgBuchungID,
  FaLeistungID             = LEI.FaLeistungID,
  SollKtoName              = KTOS.KontoName,
  SollKtoNrName            = KTOS.KontoNr + ' ' + KTOS.KontoName,
  SollKontoartCode         = KTOS.KgKontoartCode ,
  HabenKtoName             = KTOH.KontoName ,
  HabenKtoNrName           = KTOH.KontoNr + ' ' + KTOH.KontoName,
  HabenKontoartCode        = KTOH.KgKontoartCode ,
  Mandant                  = PRS.NameVorname,
  BaPersonID               = LEI.BaPersonID,
  Adresse                  = PRS.Wohnsitz,
  MTLogon                  = USR1.LogonName,
  MTName                   = IsNull(USR1.LastName,'') + IsNull(', ' + USR1.FirstName,''),
  ErfLogon                 = USR2.LogonName ,
  ErfName                  = IsNull(USR2.LastName,'') + IsNull(', ' + USR2.FirstName,'') ,
  StatusText               = STA.Text,
  PeriodeVon               = PER.PeriodeVon,
  PeriodeBis               = PER.PeriodeBis,
  PeriodeAbgeschlossenBis  = PER.AbgeschlossenBis,
  KgPeriodeStatusCode      = PER.KgPeriodeStatusCode,
  KgPeriodeStatusText      = PST.Text,
  FallBaPersonID           = FAL.BaPersonID
FROM   KgBuchung BUC
       INNER JOIN KgKonto          KTOS ON KTOS.KgPeriodeID = BUC.KgPeriodeID AND
                                           KTOS.KontoNr = BUC.SollKtoNr
       INNER JOIN KgKonto          KTOH ON KTOH.KgPeriodeID = BUC.KgPeriodeID AND
                                           KTOH.KontoNr = BUC.HabenKtoNr
       INNER JOIN KgPeriode        PER  ON PER.KgPeriodeID = BUC.KgPeriodeID
       INNER JOIN FaLeistung       LEI  ON LEI.FaLeistungID = PER.FaLeistungID
       INNER JOIN vwPerson2         PRS  ON PRS.BaPersonID = LEI.BaPersonID
       INNER JOIN FaFall           FAL  ON FAL.FaFallID = LEI.FaFallID
       LEFT  JOIN XUser            USR1 ON USR1.UserID = LEI.UserID
       LEFT  JOIN XUser            USR2 ON USR2.UserID = BUC.ErstelltUserID
       LEFT  JOIN XLOVCode         STA  ON STA.LOVName = 'KgBuchungStatus' AND
                                           STA.Code = BUC.KgBuchungStatusCode
       LEFT  JOIN XLOVCode         PST  ON PST.LOVName = 'KgPeriodeStatus' AND
                                           PST.Code = PER.KgPeriodeStatusCode

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchungCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchungCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKgBuchungCode
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKgBuchungCode.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:54 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKgBuchungCode.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKgBuchungCode] AS

SELECT
BCO.KgBuchungCodeID,
BCO.Code,
BCO.SollKtoNr,
BCO.HabenKtoNr,
BCO.Betrag,
BCO.Text,
BCO.UserID,
BCO.KgBuchungCodeTS,
SollKtoName =		(		SELECT TOP 1 KontoName
										FROM   dbo.KgPeriode P WITH (READUNCOMMITTED)
										INNER JOIN dbo.KgKonto K WITH (READUNCOMMITTED) ON K.KgPeriodeID = P.KgPeriodeID
										WHERE  KontoNr = BCO.SollKtoNr --ergibt bei bestimmter Datenkonstelation Fehler (varchar und int feld)!!!
										ORDER BY PeriodeVon DESC),
HabenKtoName =  (		SELECT TOP 1 KontoName
										FROM   dbo.KgPeriode P WITH (READUNCOMMITTED)
										INNER JOIN dbo.KgKonto K WITH (READUNCOMMITTED) ON K.KgPeriodeID = P.KgPeriodeID
										WHERE  KontoNr = BCO.HabenKtoNr --ergibt bei bestimmter Datenkonstelation Fehler (varchar und int feld)!!!
										ORDER BY PeriodeVon DESC),
MTLogon   = USR.LogonName,
MTName    = USR.LastName + IsNull(', ' + USR.FirstName,'')
FROM   dbo.KgBuchungCode BCO WITH (READUNCOMMITTED)
       LEFT OUTER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = BCO.UserID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwKgBuchungCode]  TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchungCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKgBuchungCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwKIS.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwKIS.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKIS
GO
/*===============================================================================================
  $Revision: 10 $
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
=================================================================================================*/

CREATE VIEW dbo.vwKIS
AS

SELECT KENNUNG            = 'KIS2014',
       DAT_EXPORT         = CONVERT(CHAR(8), GETDATE(), 112) + RIGHT('0' + CONVERT(VARCHAR(6), DATEPART(hh, GETDATE()) * 10000 + DATEPART(mi, GETDATE()) * 100 + DATEPART(ss, GETDATE())), 6),
       EXPORT_USR         = 'KiSS  ',
       zip_nr             = ISNULL(CONVERT(char(9), PRS.ZIPNr), '051' + CONVERT(CHAR(6), PRS.BaPersonID)),
       ahv_nr             = CONVERT(CHAR(14), ISNULL(PRS.AHVNummer, '')),
       sozvers_nr         = REPLACE(PRS.Versichertennummer, '.', ''),
       nachname           = CONVERT(CHAR(32), ISNULL(PRS.Name, '')),
       vorname            = CONVERT(CHAR(32), ISNULL(PRS.Vorname, '')),
       strasse            = CONVERT(CHAR(32), CASE WHEN ADR.Gesperrt = 1 THEN 'gesperrt' ELSE ISNULL(PRS.WohnsitzStrasse, '') END),
       plz                = CONVERT(CHAR(8), CASE WHEN ADR.Gesperrt = 1 THEN '' ELSE ISNULL(PRS.WohnsitzPLZ, '') END),
       ort                = CONVERT(CHAR(32), CASE WHEN ADR.Gesperrt = 1 THEN 'gesperrt' ELSE ISNULL(PRS.WohnsitzOrt, '') END),
       dat_geburt         = ISNULL(CONVERT(CHAR(8), PRS.Geburtsdatum, 112), ''),
       dat_tod            = ISNULL(CONVERT(CHAR(8),  PRS.Sterbedatum, 112), ''),
       geschlecht_code    = CONVERT(CHAR(1),  CASE GeschlechtCode WHEN 1 THEN 'm' WHEN 2 THEN 'w' ELSE '' END),
       heimatort          = CONVERT(CHAR(32), ISNULL(GMD.Name, '')),
       nationalitaet      = CONVERT(CHAR(32), ISNULL(LAN.[Text], '')),
       leistungsart_code  = CONVERT(CHAR(5), ISNULL(LEI.FaProzessCode + 1000, '')),
       dat_bezug_von      = ISNULL(CONVERT(CHAR(8), LEI.DatumVon, 112), ''),
       dat_bezug_bis      = ISNULL(CONVERT(CHAR(8), LEI.DatumBis, 112), ''),
       fall_nr            = CONVERT(CHAR(10), ISNULL(LEI.FaLeistungID, '')),
       person_nr          = CONVERT(CHAR(10), ISNULL(PRS.BaPersonID, '')),
       sb_nachname        = CONVERT(CHAR(32), ISNULL(USR.LastName, '')),
       sb_vorname         = CONVERT(CHAR(32), ISNULL(USR.FirstName, '')),
       bereich            = CONVERT(CHAR(32), ISNULL(ORG.ItemName, '')),
       sb_telefon         = CONVERT(CHAR(24), ISNULL(USR.Phone, '')),
       sb_email           = CONVERT(CHAR(64), ISNULL(USR.EMail, ''))
FROM dbo.vwPerson                PRS
  LEFT OUTER JOIN dbo.BaAdresse  ADR WITH (READUNCOMMITTED) ON ADR.BaAdresseID  = PRS.WohnsitzBaAdresseID
  INNER JOIN dbo.FaLeistung      LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID   = PRS.BaPersonID
  INNER JOIN dbo.XUser           USR WITH (READUNCOMMITTED) ON USR.UserID       = LEI.UserID
  INNER JOIN dbo.XOrgUnit_User   U2O WITH (READUNCOMMITTED) ON U2O.UserID       = USR.UserID AND OrgUnitMemberCode = 2 /*Mitglied*/
  INNER JOIN dbo.XOrgUnit        ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID    = U2O.OrgUnitID
  LEFT OUTER JOIN dbo.BaGemeinde GMD WITH (READUNCOMMITTED) ON GMD.BaGemeindeID = PRS.HeimatgemeindeCode
  LEFT OUTER JOIN dbo.BaLand     LAN WITH (READUNCOMMITTED) ON LAN.BaLandID     = PRS.NationalitaetCode
WHERE LEI.ModulID <> 4 AND LEI.FaProzessCode <> 201


GO
GRANT SELECT ON [dbo].[vwKIS] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwKIS.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwKIS.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKlientLeistung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKlientLeistung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKlientLeistung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKlientLeistung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:54 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKlientLeistung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKlientLeistung]
AS
SELECT DISTINCT
       Rolle        = CASE LEI.FaProzessCode
                      WHEN 200 THEN 'Klient/in'
                      WHEN 201 THEN 'Klient/in'
                      WHEN 210 THEN 'Person mit zivilr. Massn.'
                      WHEN 300 THEN 'unterstützt'
                      WHEN 301 THEN 'Schuldner/in'
                      WHEN 302 THEN 'Schuldner/in'
                      WHEN 304 THEN 'Schuldner/in'
                      WHEN 402 THEN 'Anspruchsperson'
                      WHEN 404 THEN 'Anspruchsperson'
                      WHEN 405 THEN 'Gläubiger/in'
                      WHEN 406 THEN 'Gläubiger/in'
                      WHEN 407 THEN 'Gläubiger/in'
                      WHEN 408 THEN 'Schuldner/in'
                      WHEN 409 THEN 'Schuldner/in'
                      WHEN 410 THEN 'Schuldner/in'
                      WHEN 500 THEN 'Person mit zivilr. Massn.'
                      END,
       FaLeistungID = LEI.FaLeistungID,
       BaPersonID   = COALESCE(FAP.BaPersonID,FPP.BaPersonID,GLA.BaPersonID,LEI.BaPersonID)
FROM   dbo.FaLeistung LEI WITH (READUNCOMMITTED)
       LEFT OUTER JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.FaFallID = LEI.FaFallID AND
                                              LEI.FaProzessCode = 200
       LEFT OUTER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.FaLeistungID = LEI.FaLeistungID
       LEFT OUTER JOIN dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BgFinanzplanID = FPL.BgFinanzplanID AND
                                              FPP.IstUnterstuetzt = 1
       LEFT OUTER JOIN dbo.IkRechtstitel         RTI WITH (READUNCOMMITTED) ON RTI.FaLeistungID = LEI.FaLeistungID
       LEFT OUTER JOIN dbo.IkGlaeubiger          GLA WITH (READUNCOMMITTED) ON GLA.IkRechtstitelID = RTI.IkRechtstitelID

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
GRANT  SELECT  ON [dbo].[vwKlientLeistung]  TO [tools_access]
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKlientLeistung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKlientLeistung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditor.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwKreditor;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwKreditor
AS
SELECT BaZahlungswegID            = ZAH.BaZahlungswegID,
       ZahlungswegDatumVon        = ZAH.DatumVon,
       ZahlungswegDatumBis        = ZAH.DatumBis,
       EinzahlungsscheinCode      = ZAH.EinzahlungsscheinCode,
       BankKontoNummer            = ZAH.BankKontoNummer,
       IBANNummer                 = ZAH.IBANNummer,
       PostKontoNummer            = ZAH.PostKontoNummer,
       ESRTeilnehmer              = ZAH.ESRTeilnehmer,
       BaKontoartCode             = ZAH.BaKontoartCode,
       BaKontoart                 = KAR.Text,
       Verwendungszweck           = ZAH.Verwendungszweck,
       --
       BaBankID                   = ZAH.BaBankID,
       BankName                   = BNK.Name,
       BankZusatz                 = BNK.Zusatz,
       BankStrasse                = BNK.Strasse,
       BankPLZ                    = BNK.PLZ,
       BankOrt                    = BNK.Ort,
       BankClearingNr             = BNK.ClearingNr,
       BankPCKontoNr              = BNK.PCKontoNr,
       BankGueltigAb              = BNK.GueltigAb,
       BankLandCode               = BNK.LandCode,
       --
       BaInstitutionID            = ZAH.BaInstitutionID ,
       InstitutionName            = INS.Name,
       InstitutionTypCode         = INS.InstitutionTypCode,
       BaFreigabeStatusCode       = INS.BaFreigabeStatusCode,
       InstitutionTyp             = INS.Typ,
       InstitutionAdresse         = INS.Adresse,
       InstitutionOrtStrasse      = INS.OrtStrasse,
       InstitutionAdressZusatz    = INS.AdressZusatz,
       InstitutionStrasse         = INS.Strasse,
       InstitutionHausNr          = INS.HausNr,
       InstitutionStrasseHausNr   = INS.StrasseHausNr,
       InstitutionPostfach        = INS.Postfach,
       InstitutionPLZ             = INS.PLZ,
       InstitutionOrt             = INS.Ort,
       InstitutionPLZOrt          = INS.PLZOrt,
       InstitutionKanton          = INS.Kanton,
       InstitutionLand            = INS.Land,
       InstitutionLandCode        = INS.LandCode,
       --
       BaPersonID                 = ZAH.BaPersonID,
       PersonName                 = PRS.Name,
       PersonVorname              = PRS.Vorname,
       PersonNameVorname          = PRS.NameVorname,
       PersonAdresse              = PRS.Wohnsitz,
       PersonAdressZusatz         = PRS.WohnsitzAdressZusatz,
       PersonStrasse              = PRS.WohnsitzStrasse,
       PersonStrasseCode          = PRS.WohnsitzStrasseCode,
       PersonHausNr               = PRS.WohnsitzHausNr,
       PersonStrasseHausNr        = PRS.WohnsitzStrasseHausNr,
       PersonPostfach             = PRS.WohnsitzPostfach,
       PersonPLZ                  = PRS.WohnsitzPLZ,
       PersonOrt                  = PRS.WohnsitzOrt,
       PersonPLZOrt               = PRS.WohnsitzPLZOrt,
       PersonKanton               = PRS.WohnsitzKanton,
       PersonLand                 = PRS.WohnsitzLand,
       PersonLandCode             = PRS.WohnsitzLandCode,
       PersonAdresseDatumVon      = PRS.WohnsitzDatumVon,
       PersonAdresseDatumBis      = PRS.WohnsitzDatumBis,
       --
       Kreditor                   = ISNULL(INS.Name,PRS.NameVorname),
       ZusatzInfo                 = CASE
                                      WHEN ZAH.WMAVerwenden = 0
                                        THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                             ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                             ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                             ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                             ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                      WHEN PRS.BaPersonID IS NOT NULL 
                                        THEN PRS.WohnsitzMehrzeilig
                                      ELSE INS.AdresseMehrzeilig
                                    END + CHAR(13) + CHAR(10) +
                                    '** ' + EIZ.ShortText + ' **' + CHAR(13) + CHAR(10) +
                                    ISNULL(dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)) + ISNULL(', ' + BNK.Name,'') + CHAR(13) + CHAR(10),'') +
                                    ISNULL(ZAH.BankKontoNummer + CHAR(13) + CHAR(10), '') +
                                    ISNULL(ZAH.IBANNummer,''),
       Zahlungsweg                = EIZ.ShortText +
                                    ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)),'') +
  		                              ISNULL(', ' + BNK.Name, '') +
                                    ISNULL(', ' + ZAH.BankKontoNummer, '') +
                                    ISNULL(', ' + ZAH.IBANNummer,''),
       --
       BeguenstigtName				    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseName ELSE PRS.NameVorname END,
       BeguenstigtName2			      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseName2 ELSE PRS.WohnsitzAdressZusatz END,	
       BeguenstigtStrasse			    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseStrasse ELSE PRS.WohnsitzStrasse END,
       BeguenstigtHausNr			    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseHausNr ELSE PRS.WohnsitzHausNr END,
       BeguenstigtPostfach			  = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdressePostfach ELSE PRS.WohnsitzPostfach END,
       BeguenstigtOrt				      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseOrt ELSE PRS.WohnsitzOrt END,
       BeguenstigtPLZ				      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdressePLZ ELSE PRS.WohnsitzPLZ END,
       BeguenstigtLandCode			  = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseLandCode ELSE PRS.WohnsitzLandCode END,
       InstitutionIstKreditor     = INS.Kreditor
FROM dbo.BaZahlungsweg         ZAH WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaBank         BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID
  LEFT JOIN dbo.vwInstitution2 INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
  LEFT JOIN dbo.vwPerson2      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAH.BaPersonID
  LEFT JOIN dbo.XLOVCode       EIZ WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' 
                                                         AND EIZ.Code = ZAH.EinzahlungsscheinCode
  LEFT JOIN dbo.XLOVCode       KAR WITH (READUNCOMMITTED) ON KAR.LOVName = 'BaKontoart' 
                                                         AND KAR.Code = ZAH.BaKontoartCode;
GO

-------------------------------------------------------------------------------
-- grant access
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
GRANT SELECT ON [dbo].[vwKreditor] TO [tools_access];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditor.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditor.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditorInfo.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditorInfo.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwKreditorInfo
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwKreditorInfo.sql $
  $Author: Mmarghitola $
  $Modtime: 21.09.10 15:19 $
  $Revision: 10 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwKreditorInfo.sql $
 * 
 * 9     23.09.10 21:55 Mmarghitola
 * #6587: Kleine Verbesserungen
 * 
 * 8     20.09.10 18:56 Mmarghitola
 * #6147: Änderungen Klientenkontoabrechnung, Optimierungen (#6015)
 * 
 * 7     30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 6     18.01.10 13:01 Mminder
 * #4644: Bereinigung nach Diskussion mit Nicolas
 * 
 * 5     18.01.10 12:48 Mminder
 * #4644: Änderung an BaBank in Release integriert
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     1.12.09 14:03 Nweber
 * #4644: Fehlermeldung wenn eine Bank eine neue ClearingNr hat.
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwKreditorInfo]
AS
SELECT
      BaZahlungswegID       = ZAL.BaZahlungswegID,
      EinzahlungsscheinCode = ZAL.EinzahlungsscheinCode,
      BaPersonID            = ZAL.BaPersonID,
      BaInstitutionID       = ZAL.BaInstitutionID,
      BaBankID              = ZAL.BaBankID,
      PCKontoNr             = ZAL.PostKontoNummer,
      BankKontoNr           = ZAL.BankKontoNummer,
      IBAN                  = ZAL.IBANNummer,
      ESRTeilnehmer         = ZAL.ESRTeilnehmer,
      BankName              = ISNULL(BNK.Name, BNK2.Name),
      BankStrasse           = ISNULL(BNK.Strasse, BNK2.Strasse),
      BankPLZ               = ISNULL(BNK.PLZ, BNK2.PLZ),
      BankOrt               = ISNULL(BNK.Ort, BNK2.Ort),
      Bank_BCN              = ISNULL(BNK.ClearingNr, BNK2.ClearingNr),
      Name = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseName 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseName
        WHEN ZAL.BaPersonID IS NULL THEN INS.Name
        ELSE PRS.NameVorname
      END,
      Name2 = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseName2 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseName2
        WHEN ZAL.BaPersonID IS NULL THEN INS.AdressZusatz
        ELSE PRS.WohnsitzAdressZusatz
      END,
      StrasseHausNr = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseStrasse 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseStrasse + IsNull(' ' + ZAL.AdresseHausNr, '')
        WHEN ZAL.BaPersonID IS NULL THEN INS.StrasseHausNr
        ELSE PRS.WohnsitzStrasseHausNr
      END,
      Strasse = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseStrasse 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseStrasse
        WHEN ZAL.BaPersonID IS NULL THEN INS.Strasse
        ELSE PRS.WohnsitzStrasse
      END,
      HausNr = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseHausNr 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseHausNr
        WHEN ZAL.BaPersonID IS NULL THEN INS.HausNr
        ELSE PRS.WohnsitzHausNr
      END,
      PLZ = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdressePLZ 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdressePLZ
        WHEN ZAL.BaPersonID IS NULL THEN INS.PLZ
        ELSE PRS.WohnsitzPLZ
      END,
      Ort = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseOrt 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseOrt
        WHEN ZAL.BaPersonID IS NULL THEN INS.Ort
        ELSE PRS.WohnsitzOrt
      END,
      Postfach = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdressePostfach
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdressePostfach
        WHEN ZAL.BaPersonID IS NULL THEN INS.Postfach
        ELSE PRS.WohnsitzPostfach
      END,
      LandCode = CASE
        --WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL THEN ZAL.AdresseLandCode 
        WHEN ZAL.WMAVerwenden = 0 THEN ZAL.AdresseLandCode
        WHEN ZAL.BaPersonID IS NULL THEN INS.LandCode
        ELSE PRS.WohnsitzLandCode
      END,
      Auszahlungsart = XLE.Value1,
      AuszahlungsartText = XLE.ShortText,
      KreditorMehrZeilig         = CASE
                                   WHEN ZAL.AdresseName IS NOT NULL AND ZAL.AdressePLZ IS NOT NULL AND ZAL.AdresseOrt IS NOT NULL
                                        THEN ZAL.AdresseName + char(13) + char(10) +
                                             IsNull(ZAL.AdresseName2 + char(13) + char(10), '') +
                                             IsNull(ZAL.AdressePostfach + char(13) + char(10), '') +
                                             IsNull(ZAL.AdresseStrasse + IsNull(' ' + ZAL.AdresseHausNr, '') + char(13) + char(10), '') +
                                             ZAL.AdressePLZ + ' ' + ZAL.AdresseOrt
                                   WHEN PRS.BaPersonID IS NOT NULL
                                        THEN PRS.NameVorname + char(13) + char(10) + PRS.WohnsitzMehrzeilig
                                   ELSE INS.Name + char(13) + char(10) + INS.AdresseMehrzeilig
                                   END
    FROM dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED)
      LEFT OUTER JOIN dbo.BaBank BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = Zal.BaBankID AND ZAL.PostKontoNummer IS NULL
      LEFT JOIN dbo.BaBank BNK2 WITH (READUNCOMMITTED) ON BNK2.ClearingNr = '9000' /*Postfinance*/ AND ZAL.PostKontoNummer IS NOT NULL
      LEFT OUTER JOIN dbo.vwPerson2      PRS ON PRS.BaPersonID      = ZAL.BaPersonID
      LEFT OUTER JOIN dbo.vwInstitution2 INS ON INS.BaInstitutionID = ZAL.BaInstitutionID
      LEFT OUTER JOIN dbo.XLOVCode      XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = ZAL.EinzahlungsscheinCode

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditorInfo.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwKreditorInfo.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwLeistungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwLeistungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwLeistungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwLeistungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:55 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwLeistungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwLeistungen]
AS

SELECT
	LEI.FaFallID AS FaFallID,
	LEI.FaLeistungID AS FaLeistungID,
    LEI.ModulID AS ModulID,
    LEI.FaProzessCode AS FaProzessCode,
    CONVERT(varchar, LEI.DatumVon,104)  AS DatumVon,
    CONVERT(varchar, LEI.DatumBis,104)  AS DatumBis,
    CONVERT(varchar, LEI.DatumVon,104) + IsNull('-' + CONVERT(varchar, LEI.DatumBis,104), '')  AS DatumVonBis,
	LEI.BaPersonID AS BaPersonID,
    LEI.SachbearbeiterID AS SachbearbeiterID,
    LEI.UserID AS UserID,
	MOD.Name AS FaLeistungName,
	LOV.ShortText AS FaProzessCodeName,
	PRS.NameVorname AS [LT Name],                            -- Leistungsträger
    SA.NameVorname AS [SA Name],                             -- Sozialarbeite
    SA.ShortName AS [SA ShortName],
	SA.SozialzentrumCode AS [SA SozialzentrumCode],
	SA.OrgUnitID AS [SA OrgUnitID],
    SA.SozialzentrumKurz AS [SA Sozialzentrum],
    SA.OrgEinheitName AS [SA OrgEinheit],
    SA.LogonName + ' ' + SA.OrgEinheitName AS [SA NameOrg],
    SB.NameVorname AS [SB Name],
	SB.SozialzentrumCode AS [SB SozialzentrumCode],
	SB.OrgUnitID AS [SB OrgUnitID],                           -- Sachbearbeiter
    SB.SozialzentrumKurz AS [SB Sozialzentrum],
    SB.OrgEinheitName AS [SB OrgEinheit],
    SB.LogonName + ' ' + SB.OrgEinheitName AS [SB NameOrg]
FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
		INNER JOIN dbo.XModul MOD WITH (READUNCOMMITTED) on MOD.ModulID = LEI.ModulID
        LEFT OUTER JOIN dbo.XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.Code = LEI.FaProzessCode AND LOV.LOVName = 'FaProzess'
        INNER JOIN vwPerson  PRS on PRS.BaPersonID = LEI.BaPersonID
        INNER JOIN vwUser  SA on SA.UserID = LEI.UserID
        LEFT JOIN vwUser  SB on SB.UserID = LEI.SachbearbeiterID

GO
GRANT SELECT ON [dbo].[vwLeistungen] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwLeistungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwLeistungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwSparhafenNamenAbgleich.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwSparhafenNamenAbgleich.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwSparhafenNamenAbgleich
GO

CREATE VIEW [dbo].[vwSparhafenNamenAbgleich]
AS
  SELECT DISTINCT
    NameVorname = Klient,
    TeilKontoNr = TeilKtoNr,
    BaPersonID
  FROM dbo.kgSparhafenabschluss
  WHERE BaPersonID IS NOT NULL -- and ungueltig = 0 
  UNION
  SELECT DISTINCT
    NameVorname,
    TeilKontoNr = Substring(KontoNr, 2, 3) + '.' + Substring(KontoNr, 5, 3),
    BaPersonID
  FROM dbo.kgSparhafenSaldo
  WHERE BaPersonID IS NOT NULL


GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwSparhafenNamenAbgleich.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\vwSparhafenNamenAbgleich.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstOroBarbelegeTotal.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstOroBarbelegeTotal.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwSstOroBarbelegeTotal
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Im Rahmen der Anpassung AERIS-Schnittstelle wurden die beiden bestehenden AERIS-Views
           für jeweil K- und W-Belege zu einer View zusammengefasst. Mittels UNION ALL
           Diese View wurde durch Frank Bestebreurtje erstellt
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/
CREATE VIEW dbo.vwSstOroBarbelegeTotal
AS


-- K-Barbelege
SELECT DISTINCT
  Quelle             = 'K-Barbelege',
  BelegNr            = BUC.PscdBelegNr,
  PersonNr           = PLT.BaPersonID,
  PersonName         = PLT.Name,
  PersonVorname      = PLT.Vorname,
  PersonGeburtsdatum = PLT.Geburtsdatum,
  PersonGeschlecht   = PLT.GeschlechtCode,
  AusbezahlenAn      = COALESCE(BUC.MitteilungZeile1 +
                                ISNULL(', ' + BUC.MitteilungZeile2, '') +
                                ISNULL(', ' + BUC.MitteilungZeile3, '') +
                                ISNULL(', ' + BUC.MitteilungZeile4, ''),
                                
                                BUC.BeguenstigtName + ', ' +
                                ISNULL(BUC.BeguenstigtStrasse + ', ','') +
                                ISNULL(BUC.BeguenstigtPLZ + ' ','') +
                                ISNULL(BUC.BeguenstigtOrt,''),
                                
                                ISNULL(PLT.Vorname + ' ', '') + PLT.Name + ', ' +
                                ISNULL(ADR1.Zusatz + ', ', '') +
                                ISNULL(ADR1.Postfach + ', ', '') +
                                ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                                ISNULL(ADR1.PLZ + ' ', '') + 
                                ISNULL(ADR1.Ort, '')),
  Betrag             = BUC.Betrag,
  GueltigAb          = COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum),
  GueltigBis         = DATEADD(DAY, 
                               CASE DATEPART(WEEKDAY, COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum))
                                 WHEN 1 THEN 9 -- So
                                 WHEN 2 THEN 9 -- Mo
                                 WHEN 3 THEN 9 -- Di
                                 WHEN 4 THEN 9 -- Mi
                                 WHEN 5 THEN 11 -- Do
                                 WHEN 6 THEN 11 -- Fr
                                 WHEN 7 THEN 10 -- Sa
                               END,
                               COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum)),
  VerbuchtDatum      = BUC.BarbelegAuszahlDatum
FROM dbo.KgBuchung          BUC  WITH(READUNCOMMITTED)
  INNER JOIN dbo.KgPeriode  PER  WITH(READUNCOMMITTED) ON PER.KgPeriodeID = BUC.KgPeriodeID
  INNER JOIN dbo.FaLeistung LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = PER.FaLeistungID
  INNER JOIN dbo.BaPerson   PLT  WITH(READUNCOMMITTED) ON PLT.BaPersonID = LEI.BaPersonID
  LEFT  JOIN dbo.BaAdresse  ADR1 WITH(READUNCOMMITTED) ON ADR1.BaPersonID = PLT.BaPersonID 
                                                      AND ADR1.AdresseCode = 1
                                                      AND GETDATE() BETWEEN ISNULL(ADR1.DatumVon, GETDATE()) AND ISNULL(ADR1.DatumBis, GETDATE())
WHERE BUC.KgAuszahlungsArtCode = 103 --Cash / Barauszahlung
  AND BUC.BarbelegDatum IS NOT NULL 
  AND BUC.KgBuchungStatusCode IN (3,4,5) -- Zahlauftrag erstellt, ausgedruckt oder fehlerhafter Zahlauftrag


UNION ALL

-- W-Barbelege
SELECT DISTINCT 
  Quelle             = 'W-Barbelege',
  BelegNr            = BUC.BelegNr,
  PersonNr           = PLT.BaPersonID,
  PersonName         = PLT.Name,
  PersonVorname      = PLT.Vorname,
  PersonGeburtsdatum = PLT.Geburtsdatum,
  PersonGeschlecht   = PLT.GeschlechtCode,
  AusbezahlenAn      = ISNULL(BUC.BeguenstigtName + ', ' + 
                              ISNULL(BUC.BeguenstigtStrasse + ', ','') +
                              ISNULL(BUC.BeguenstigtPLZ + ' ','') +
                              ISNULL(BUC.BeguenstigtOrt,''),
                              
                              ISNULL(PLT.Vorname + ' ', '') + PLT.Name + ', ' +
                              ISNULL(ADR1.Zusatz + ', ', '') +
                              ISNULL(ADR1.Postfach + ', ', '') +
                              ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                              ISNULL(ADR1.PLZ + ' ', '') + 
                              ISNULL(ADR1.Ort, '')),
  Betrag             = BUC.Betrag,
  GueltigAb          = COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum),
  GueltigBis         =  DATEADD(DAY, 
                                CASE DATEPART(WEEKDAY, COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum))
                                  WHEN 1 THEN 2 -- So
                                  WHEN 2 THEN 2 -- Mo
                                  WHEN 3 THEN 2 -- Di
                                  WHEN 4 THEN 2 -- Mi
                                  WHEN 5 THEN 4 -- Do
                                  WHEN 6 THEN 4 -- Fr
                                  WHEN 7 THEN 3 -- Sa
                                END,
                                COALESCE(BUC.BarbelegGueltigVon, BUC.BarbelegDatum, BUC.ValutaDatum)),
  VerbuchtDatum      = BUC.BarbelegAuszahlDatum
FROM dbo.KbBuchung          BUC  WITH(READUNCOMMITTED)
  INNER JOIN dbo.FaLeistung LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = BUC.FaLeistungID
  INNER JOIN dbo.BaPerson   PLT  WITH(READUNCOMMITTED) ON PLT.BaPersonID = LEI.BaPersonID
  LEFT  JOIN dbo.BaAdresse  ADR1 WITH(READUNCOMMITTED) ON ADR1.BaPersonID = PLT.BaPersonID 
                                                      AND ADR1.AdresseCode = 1
                                                      AND GETDATE() BETWEEN ISNULL(ADR1.DatumVon, GETDATE()) AND ISNULL(ADR1.DatumBis, GETDATE())
WHERE BUC.KbAuszahlungsArtCode = 103 --Cash / Barauszahlung
  AND BUC.BarbelegDatum IS NOT NULL
  AND BUC.KbBuchungStatusCode IN (3,4,5) -- Zahlauftrag erstellt, ausgedruckt oder fehlerhafter Zahlauftrag 



GO
IF EXISTS(SELECT TOP 1 1 FROM sysusers WHERE name = 'soz_user_r_kiss')
BEGIN
  GRANT SELECT ON [dbo].[vwSstOroBarbelegeTotal] TO [soz_user_r_kiss];
END;

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstOroBarbelegeTotal.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Schnittstellen\ZH\vwSstOroBarbelegeTotal.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbklaerung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbklaerung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAbklaerung;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbklaerung
AS

SELECT
  FaAbklaerungID,
  NameVorname              = CASE WHEN PRS.Name IS NULL OR PRS.Name = '' THEN '' ELSE PRS.Name END
                             + CASE WHEN PRS.Vorname IS NULL OR PRS.Vorname = '' THEN '' ELSE ', ' + PRS.Vorname END
                             + CASE WHEN PRS.Vorname2 IS NULL OR PRS.Vorname2 = '' THEN '' ELSE ' ' + PRS.Vorname2 END,
  [BeginnAbklaerung]       = CONVERT(varchar, ABK.AuftragDatum, 104),
  [Ausloeser]              = dbo.fnLOVText('FaAbklaerungAusloeser', ABK.AusloeserCode),
  [Abklaerungsbericht]     = CONVERT(varchar, ABK.AbklaerungsberichtBeendetDatum, 104),
  [Fallverantwortlicher]   = CASE WHEN USR.FirstName IS NULL OR USR.FirstName = '' THEN '' ELSE USR.FirstName END 
                             + CASE WHEN USR.LastName IS NULL OR USR.LastName = '' THEN '' ELSE ' ' + USR.LastName END,
  [QTFallverantwortlicher] = CASE WHEN OUN.ItemName IS NULL OR OUN.ItemName = '' THEN '' ELSE OUN.ItemName END,
  [CoFallfuehrung]         = CASE WHEN USR2.FirstName IS NULL OR USR2.FirstName = '' THEN '' ELSE USR2.FirstName END
                             + CASE WHEN USR2.LastName IS NULL OR USR2.LastName = '' THEN '' ELSE ' ' + USR2.LastName END,
  [QTCOFallfuehrung]       = CASE WHEN OUN2.ItemName IS NULL OR OUN2.ItemName = '' THEN '' ELSE OUN2.ItemName END
FROM dbo.FaAbklaerung ABK WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.XUser USR  WITH (READUNCOMMITTED) ON USR.UserID = ABK.UserID
  LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
  LEFT OUTER JOIN dbo.XOrgUnit OUN WITH (READUNCOMMITTED) ON OUN.OrgUnitID = OUU.OrgUnitID
  LEFT OUTER JOIN dbo.XUser USR2 WITH (READUNCOMMITTED) ON USR2.UserID = ABK.CoUserID
  LEFT OUTER JOIN dbo.XOrgUnit_User OUU2 WITH (READUNCOMMITTED) ON OUU2.UserID = USR2.UserID AND OUU2.OrgUnitMemberCode = 2
  LEFT OUTER JOIN dbo.XOrgUnit OUN2 WITH (READUNCOMMITTED) ON OUN2.OrgUnitID = OUU2.OrgUnitID
  LEFT OUTER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ABK.BaPersonID
WHERE ABK.AusloeserCode <> -1 --Platzhalter für Tree soll nicht angezeigt werden.
GO
GRANT SELECT ON [dbo].[vwTmAbklaerung] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbklaerung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbklaerung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbmachungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbmachungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAbmachungen
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAbmachungen.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAbmachungen.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmAbmachungen]
AS

SELECT
	ABM.FaAbmachungID,
	Klient1 = IsNull(PRS1.Vorname, '') + IsNull(' ' + PRS1.Name, ''),
	Klient2 = IsNull(PRS2.Vorname, '') + IsNull(' ' + PRS2.Name, ''),
	KlientBeide = IsNull(PRS1.Vorname, '') + IsNull(' ' + PRS1.Name, '') + IsNull(' und ' + PRS2.Vorname + IsNull(' ' + PRS2.Name, ''), ''),
	Betreff,
	ErfasstAm = CONVERT(varchar, ABM.ErstelltDatum , 104),
	Sozialarbeiter = IsNull(USR.FirstName, '') + IsNull(' ' + USR.LastName, ''),
	SozialarbeiterInFunktion = IsNull(USR.Funktion, ''),
	Ausgangslage,
	AuflageVon = CONVERT(varchar, ABM.AuflageVon, 104),
    Auflagentext,
	AngedrohteSanktion = dbo.fnLOVText('FaAbmachungSanktionen', ABM.AngedrohtFaAbmachungSanktionenCode),
	Sanktion = dbo.fnLOVText('FaAbmachungSanktionen', ABM.FaAbmachungSanktionenCode),
	Frist = CONVERT(varchar, ABM.ErfuellenBis, 104),
	StellenleiterVornameName = IsNull(STL.FirstName + ' ','') + STL.LastName,
	FrauHerr1 =
		CASE PRS1.GeschlechtCode
			WHEN 1 THEN 'Herr'
			WHEN 2 THEN 'Frau'
		ELSE ''
		END,
	GeehrteFrauHerrVornameName1 =
		CASE PRS1.GeschlechtCode
			WHEN 1 THEN 'Sehr geehrter Herr '
			WHEN 2 THEN 'Sehr geehrte Frau '
			ELSE ''
		END + PRS1.Name,
	WohnsitzAdresseMehrzOhneName = (
		IsNull(ADR1.Zusatz + char(13) + char(10),'') +
		IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
		IsNull(ADR1.PLZ + ' ','') + ADR1.Ort )
FROM   dbo.FaAbmachung ABM WITH (READUNCOMMITTED)
	LEFT OUTER JOIN dbo.BaPerson PRS1 WITH (READUNCOMMITTED) ON PRS1.BaPersonID = ABM.Klient1ID
	LEFT OUTER JOIN dbo.BaPerson PRS2 WITH (READUNCOMMITTED) ON PRS2.BaPersonID = ABM.Klient2ID
    LEFT OUTER JOIN dbo.XUser USR WITH (READUNCOMMITTED) on USR.UserID = ABM.ErstelltUserID
	LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
    LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
	LEFT OUTER JOIN dbo.XUser STL WITH (READUNCOMMITTED) ON STL.UserID = ORG.ChiefID
	LEFT OUTER JOIN dbo.BaAdresse ADR1 WITH (READUNCOMMITTED) ON ADR1.BaPersonID = PRS1.BaPersonID AND ADR1.AdresseCode = 1 -- Wohnsitz
                                  AND GetDate() BETWEEN IsNull(ADR1.DatumVon, GetDate()) AND IsNull(ADR1.DatumBis, GetDate())

GO
GRANT SELECT ON [dbo].[vwTmAbmachungen] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbmachungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbmachungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject vwTmAbrechnung
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnung
AS

SELECT 
  ABR.WhAbrechnungID, 
  ABR.DatumBis, 
  ABR.DatumVon
FROM dbo.WhAbrechnung ABR WITH (READUNCOMMITTED);
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungErgaenzungen.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungErgaenzungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmAbrechnungErgaenzungen;
GO
/*===============================================================================================
  $Revision: 3$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: <ZH Klientenkontoabrechnung Ergänzungen>
    Im Detailblatt (Worddokument) der Klientenkontoabrechnung werden die Ergänzungen
    aufgelistet. Die Ergänzungen können im Reiter Ergänzungen in der Maske  
    Klientenkontoabrechung eingegeben werden.
  RETURNS: <ZH Klientenkontoabrechnung Ergänzungen>
=================================================================================================
  TEST:    SELECT TOP 10 <Columns> FROM dbo.vwTmAbrechnungErgaenzungen;
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnungErgaenzungen
AS
SELECT
  WhDetailblattID,
  Korrekturtext, 
  Betrag = CASE 
             WHEN WhDetailblattKorrekturVorzeichenCode = 1 -- 1: Reduktion, 2: Erhöhung
               THEN -Betrag
             ELSE Betrag
           END
  FROM dbo.whDetailblattKorrekturPosition WITH (READUNCOMMITTED);
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungErgaenzungen.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungErgaenzungen.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungDetail.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungDetail.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject vwTmAbrechnungDetail;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnungDetail
AS

SELECT 
  WhAbrechnungID,
  WhDetailblattID,
  DatumVon,
  DatumBis,
  KlientName,
  Grund,
  TotalAusgabenKlient,
  TotalAusgabenDritte,
  TotalEinnahmenKlient,
  TotalEinnahmenSD,
  TotalEinnahmenSDInklErgaenzungen,
  TotalVerrechnungRueckerstattung,
  TotalZahlungenKlient,
  TotalAusgaben,
  SaldoZugunstenKlientEffektiv = SaldoZugunstenKlient,
  TotalKorrekturen
FROM (SELECT
        DET.WhAbrechnungID,
        DET.WhDetailblattID,
        DET.DatumVon,
        DET.DatumBis,
        KlientName = PER.NameVorname,
        DET.Grund,
        TotalAusgabenKlient = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient, 1), ',', ''''),
        TotalAusgabenDritte  = Replace(CONVERT(varchar(20), DET.TotalAusgabenDritte, 1), ',', ''''),
        TotalEinnahmenKlient  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenKlient, 1), ',', ''''),
        TotalEinnahmenSD  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenSD, 1), ',', ''''),
        TotalEinnahmenSDInklErgaenzungen  = Replace(CONVERT(varchar(20), DET.TotalEinnahmenSD + ISNULL(ERG.TotalErgaenzungen, 0), 1), ',', ''''),
        TotalVerrechnungRueckerstattung  = Replace(CONVERT(varchar(20), DET.TotalVerrechnungRueckerstattung, 1), ',', ''''),
        TotalZahlungenKlient = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient, 1), ',', ''''),
        TotalAusgaben = Replace(CONVERT(varchar(20), DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient + DET.TotalAusgabenDritte, 1), ',', ''''),
        TotalKorrekturen = ISNULL(ERG.TotalErgaenzungen, 0),
        SaldoZugunstenKlient = DET.TotalEinnahmenSD - (DET.TotalAusgabenKlient - DET.TotalVerrechnungRueckerstattung - DET.TotalEinnahmenKlient + DET.TotalAusgabenDritte) + ISNULL(ERG.TotalErgaenzungen, 0)
      FROM dbo.WhDetailblatt          DET WITH (READUNCOMMITTED)
        INNER JOIN dbo.WhAbrechnung   ABR WITH (READUNCOMMITTED) ON ABR.WhAbrechnungID = DET.WhAbrechnungID
        INNER JOIN dbo.FaFall         FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = ABR.FaFallID
        LEFT  JOIN dbo.vwPersonSimple PER WITH (READUNCOMMITTED) ON PER.BaPersonID = FAL.BaPersonID
        LEFT  JOIN (SELECT WhDetailblattID, 
                           TotalErgaenzungen = SUM(Betrag)
                    FROM dbo.vwTmAbrechnungErgaenzungen
                    GROUP BY WhDetailblattID) ERG ON DET.WhDetailblattID = ERG.WhDetailblattID
      ) SubAbrechnungDetail;
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Effektiver Saldo zu Gunsten des Klients, d.h. Negativbetrag wird ausgewiesen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwTmAbrechnungDetail', @level2type=N'COLUMN',@level2name=N'SaldoZugunstenKlientEffektiv'
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungDetail.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAbrechnungDetail.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmAnspruchsberechnung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmAnspruchsberechnung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAmAnspruchsberechnung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAmAnspruchsberechnung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAmAnspruchsberechnung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 15.11.2007
Description: Textmarke für Anspruchsberechnung
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmAmAnspruchsberechnung
===================================================================================================
History:
--------
15.11.2007 : sozheo : neu erstellt
25.03.2008 : sozheo : Korrekturen für Verfügung
===================================================================================================
*/

CREATE VIEW [dbo].[vwTmAmAnspruchsberechnung]
AS
SELECT
  B.AmAnspruchsberechnungID,
  B.Bezeichnung,
  BerechnungDatumAb = CONVERT(varchar, B.BerechnungDatumAb, 104),
  BerechnungsTyp = bt.Text,
  BerechnungsStatus = bs.Text,
  Einkommensvariante = ev.Text,
  EntscheidDatum = CONVERT(varchar, V.EntscheidDatum, 104),
  Username = us.LastName + IsNull(us.FirstName, ''),
  UserLogon = us.LogonName
FROM dbo.AmAnspruchsberechnung B WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.AmVerfuegung V WITH (READUNCOMMITTED) ON V.AmVerfuegungID = B.AmVerfuegungID
  LEFT OUTER JOIN dbo.XLOVCode bt WITH (READUNCOMMITTED) ON bt.LOVName = 'AmBerechnungTyp' AND bt.Code = B.AmBerechnungTypCode
  LEFT OUTER JOIN dbo.XLOVCode bs WITH (READUNCOMMITTED) ON bs.LOVName = 'AmBerechnungsStatus' AND bs.Code = V.AmVerfuegungStatusCode
  LEFT OUTER JOIN dbo.XLOVCode ev WITH (READUNCOMMITTED) ON ev.LOVName = 'AmEinkommensvariante' AND ev.Code = B.AmEinkommensvarianteCode
  LEFT OUTER JOIN dbo.XUser us WITH (READUNCOMMITTED) ON us.UserID = B.UserID

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmAnspruchsberechnung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmAnspruchsberechnung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmVerfuegung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmVerfuegung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAmVerfuegung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAmVerfuegung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAmVerfuegung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 19.03.2008
Description: Textmarke für Anspruchsberechnung
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmAmVerfuegung
===================================================================================================
History:
--------
19.03.2008 : sozheo : neu erstellt
===================================================================================================
*/

CREATE VIEW [dbo].[vwTmAmVerfuegung]
AS

SELECT
  V.AmVerfuegungID,
  V.Bezeichnung,
  V.AmVerfuegungStatusCode,
  Status = VS.Text,
  EntscheidDatum = CONVERT(varchar, V.EntscheidDatum, 104),
  Username = U.NameVornameOhneKomma,
  UserLogon = U.LogonName
FROM dbo.AmVerfuegung V WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.XLOVCode VS WITH (READUNCOMMITTED) ON VS.LOVName = 'AmBerechnungsStatus' AND VS.Code = V.AmVerfuegungStatusCode
  LEFT OUTER JOIN vwUser U ON U.UserID = V.UserID

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmVerfuegung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAmVerfuegung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmArbeit.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmArbeit.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmArbeit
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmArbeit.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmArbeit.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmArbeit]
AS

SELECT
  BaPersonID,
  InstitutionName = I.Name,
  ArbeitgeberEinzeilig = CASE
    WHEN A.BaInstitutionID IS NULL THEN replace(CONVERT(varchar(500), A.Adresse),char(13) + char(10) ,', ')
    ELSE I.Name + IsNull(', ' + I.Adresse, '')
  END,
  Arbeitgeber = CASE
    WHEN A.BaInstitutionID IS NULL THEN CAST(A.Adresse AS varchar)
    ELSE I.Name
  END,
  Pensum = CONVERT(varchar, A.Pensum) + '%',
  Seit = CONVERT(varchar, A.DatumVon, 104),
  VonBis = CONVERT(varchar, A.DatumVon, 104) + ' - ' + CONVERT(varchar, A.DatumBis, 104),
  DatumVon = A.DatumVon,
  DatumBis = A.DatumBis
FROM dbo.BaArbeit A WITH (READUNCOMMITTED)
	LEFT OUTER JOIN dbo.vwInstitution I ON I.BaInstitutionID = A.BaInstitutionID

GO
GRANT SELECT ON [dbo].[vwTmArbeit] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmArbeit.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmArbeit.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAssessment.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAssessment.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAssessment
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAssessment.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAssessment.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
CREATE VIEW [dbo].[vwTmAssessment]
AS

SELECT
    FaAssessmentID,
	FaLeistungID,
	Sozialarbeiter = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, ''),
	Eroeffnung = CONVERT(varchar, ASS.EroeffnungDatum, 104),
	EroeffnungUser = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, ''),
	EroeffnungOrgUnit = IsNull(USRero.Vorname, '') + IsNull(' ' + USRero.Name, '') + IsNull(', ' + USRero.OrgEinheitName, ''),
	DatumBericht = CONVERT(varchar, ASS.DatumBericht, 104),
	Abschluss = CONVERT(varchar, ASS.AbschlussDatum, 104),
	AbschlussUser = IsNull(USRabs.Vorname, '') + IsNull(' ' + USRabs.Name, ''),
	Grund = dbo.fnLOVText('FaAssessmentAbschlussgrund', ASS.FaAssessmentAbschlussGrundCode),
	IsUeBv = CASE WHEN ASS.FaAssessmentAbschlussGrundCode IN (2,3) THEN 'Ja' ELSE 'Nein' END,
	GrundUeBv = dbo.fnLOVText('FaUeberbrueckungBevorschussungGrund', ASS.FaUeberbrueckungGrundCode),
	EmpfehlungRP = dbo.fnLOVText('FaRessourcenpaket', ASS.FaRessourcenPaketCode),
	Kriterium = dbo.fnLOVText('FaKriterium', ASS.FaKriteriumCode),
	QTUebergabeAm = CONVERT(varchar, ASS.QTUebergabeDatum, 104),
	QTUebergabeOrgUnit = OrgQtu.ItemName,
	Anlass,
	Situation,
	Thema1,
	Thema2,
	Thema1Zustaendig,
	Thema2Zustaendig,
	ThemaAnpacken,
	KeinInteresseGrund = ThemaAnpackenKeinInteresseGrund,
	KeinInteresse = CONVERT(bit, IsNull(ASS.ThemaAnpackenKeinInteresse, 0)),
	KeinSoD = CONVERT(bit, IsNull(ASS.KeinSoDThema, 0)),
	AndereStellen,
	BestehenAuflagen = dbo.fnLOVText('FaJaNein', ASS.FaAuflageCode),
	ZuweisungRP = dbo.fnLOVText('FaRessourcenPaket', ASS.RPBedarfCode),
	Muttersprache,
	DeutschGenuegend = CASE WHEN ASS.DeutschUngenuegend = 1 THEN 'Ja' ELSE 'Nein' END,
	Uebersetzer = CASE WHEN ASS.Uebersetzer = 1 THEN 'Ja' ELSE 'Nein' END,
	Bemerkung,
	Mitarbeiter = IsNull(USRmit.Vorname, '') + IsNull(' ' + USRmit.Name, ''),
	UnterschriebenDurchKlient = CONVERT(varchar, ASS.UnterschriebenDurchKlient, 104)
FROM dbo.FaAssessment ASS WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.vwUser USRero ON USRero.UserID = ASS.EroeffnungUserID
  LEFT OUTER JOIN dbo.vwUser USRabs ON USRabs.UserID = ASS.AbschlussUserID
  LEFT OUTER JOIN dbo.vwUser USRmit ON USRmit.UserID = ASS.BerichtUserID
  LEFT OUTER JOIN dbo.XOrgUnit OrgEro WITH (READUNCOMMITTED) ON OrgEro.OrgUnitID = ASS.EroeffnungOrgUnitID
  LEFT OUTER JOIN dbo.XOrgUnit OrgQtu WITH (READUNCOMMITTED) ON OrgQtu.OrgUnitID = ASS.QTUebergabeOrgUnitID

GO
GRANT SELECT ON [dbo].[vwTmAssessment] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAssessment.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmAssessment.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmBriefkopf.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmBriefkopf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmBriefkopf
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmBriefkopf.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmBriefkopf.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmBriefkopf]
AS

SELECT
  BenutzerNr			= USR.UserID,
  BriefkopfAdresse		= ORG.Adresse,
  BriefkopfLogoMitFMT	= ORG.Logo,
  BriefkopfTelFaxWWW    = IsNull(ORG.Phone, '') + IsNull(', ' + ORG.Fax, '') + IsNull(', ' + ORG.WWW, '')
FROM dbo.XUser USR WITH (READUNCOMMITTED)
     LEFT OUTER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID AND
                                    OUU.OrgUnitMemberCode = 2
     LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID

GO
GRANT SELECT ON [dbo].[vwTmBriefkopf] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmBriefkopf.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmBriefkopf.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmCheckIn.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmCheckIn.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmCheckIn
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmCheckIn.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmCheckIn.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 23.01.2008
Description: Textmarke für FaCheckin
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmCheckIn
===================================================================================================
History:
--------
23.01.2008 : sozheo : neu erstellt
===================================================================================================
*/


CREATE VIEW [dbo].[vwTmCheckIn]
AS

SELECT
  CHK.FaCheckinID,
  CHK.FaLeistungID,
  ErstkontaktDatum = CONVERT(varchar, CHK.ErstkontaktDatum, 104),
  ErstKontaktUser = USRek.VornameName,
  ErstKontaktOrganisation = ORGek.ItemName,
  Kontaktart = dbo.fnLOVText('FaCheckinKontaktart', CHK.KontaktartCode),
  CHK.KontaktPerson,
  KontaktGrund = dbo.fnLOVText('FaCheckinEroeffnungsgrund', CHK.KontaktgrundCode),
  -- TODO: welche LOV-Liste?
  -- FallartZAV = dbo.fnLOVText('???', CHK.FallartZAVCode),
  ZustaendigkeitGeprueftDatum = CONVERT(varchar, CHK.ZustaendigkeitGeprueftDatum, 104),
  ZustaendigkeitUser = USRzs.VornameName,
  ZustaendigkeitOrganisation = ORGzs.ItemName,
  Situationsbeschrieb,

  AntragAbgegebenDatum = CONVERT(varchar, CHK.AntragAbgegebenDatum, 104),
  AntragAbgegebenUser = USRaa.VornameName,

  AntragEingegangenDatum = CONVERT(varchar, CHK.AntragEingegangenDatum, 104),
  AntragEingegangenUser = USRae.VornameName,

  AntragVollstaendigDatum = CONVERT(varchar, CHK.AntragVollstaendigDatum, 104),
  AntragVollstaendigUser = USRav.VornameName,

  AbschlussDatum = CONVERT(varchar, CHK.AbschlussDatum, 104),
  AbschlussUser = USRab.VornameName,

  FallabschlussGrund = dbo.fnLOVText('FaCheckinAbschlussgrund', CHK.FallabschlussGrundCode),
  GespraecheGemacht = CASE WHEN CHK.GespraecheGemacht = 1 THEN 'Ja' ELSE 'Nein' END,
  RessourcenPaket = dbo.fnLOVText('FaRessourcenpaket', CHK.FaRessourcenPaketCode),
  Kriterium = dbo.fnLOVText('FaKriterium', CHK.FaKriteriumCode),

  QuartierTeam = ORGqt.ItemName,
  UebergabeDatum = CONVERT(varchar, CHK.QTUebergabeDatum, 104)
FROM dbo.FaCheckin CHK WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwUser USRek ON USRek.UserID = CHK.ErstkontaktUserID
  LEFT JOIN dbo.vwUser USRzs ON USRzs.UserID = CHK.ZustaendigUserID
  LEFT JOIN dbo.vwUser USRaa ON USRaa.UserID = CHK.AntragAbgegebenUserID
  LEFT JOIN dbo.vwUser USRae ON USRae.UserID = CHK.AntragEingegangenUserID
  LEFT JOIN dbo.vwUser USRav ON USRav.UserID = CHK.AntragVollstaendigUserID
  LEFT JOIN dbo.vwUser USRab ON USRab.UserID = CHK.AbschlussUserID
  LEFT JOIN dbo.XOrgUnit ORGek WITH (READUNCOMMITTED) ON ORGek.OrgUnitID = CHK.ErstKontaktOrgUnitID
  LEFT JOIN dbo.XOrgUnit ORGzs WITH (READUNCOMMITTED) ON ORGzs.OrgUnitID = CHK.ZustaendigOrgUnitID
  LEFT JOIN dbo.XOrgUnit ORGqt WITH (READUNCOMMITTED) ON ORGqt.OrgUnitID = CHK.QuartierTeamID

GO
GRANT SELECT ON [dbo].[vwTmCheckIn] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmCheckIn.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmCheckIn.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmFall.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFall;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW [dbo].[vwTmFall]
AS
SELECT 
  Fallnummer = F.FaFallID,
  FallaufnDat = CONVERT(VARCHAR,F.DatumVon,104),
  -- TODO: Unterstützungsdatum Beginn
  FaUnterstuetzungBeginnDat = CONVERT(VARCHAR, F.DatumVon, 104),
  FaPersonenAnzahl = ( SELECT COUNT(*) FROM dbo.FaFallPerson A WITH (READUNCOMMITTED) WHERE A.FaFallID = F.FaFallID ),
  AnzAktivePersMitLeistung = (	SELECT count(*) FROM dbo.FaFallPerson FPers WITH (READUNCOMMITTED)
								INNER JOIN dbo.vwPerson P ON FPers.BaPersonID = P. BaPersonID 
								WHERE P.PersonOhneLeistung = 0 AND (FPers.DatumBis IS Null OR FPers.DatumBis > GetDate()) AND FPers.FaFallID = F.FaFallID),
  AnzAktiveKinderMitLeistung = (SELECT count(*) FROM dbo.FaFallPerson FPers WITH (READUNCOMMITTED)
								INNER JOIN dbo.vwPerson P ON FPers.BaPersonID = P. BaPersonID 
								WHERE P.PersonOhneLeistung = 0 AND P.[Alter] < 18 AND (FPers.DatumBis IS Null OR FPers.DatumBis > GetDate()) AND FPers.FaFallID = F.FaFallID)

FROM dbo.FaFall F WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmFall] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmFall.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmInstitution.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmInstitution
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmInstitution.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:57 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmInstitution.sql $
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmInstitution]
AS

  SELECT
    InstitutionNr   = INS.BaInstitutionID,
    InstitutionName = INS.Name,
    Typ             = TYP.Text,
    Telefon         = INS.Telefon,
    Fax             = INS.Fax,
    EMail           = INS.EMail,
    Homepage        = INS.Homepage,
    OrtStrasse      = IsNull(ADR.Ort,'') + IsNull(', ' + ADR.Strasse + IsNull(' ' + ADR.HausNr,''), ''),
    AdressZusatz    = ADR.Zusatz,
    Strasse         = ADR.Strasse,
    HausNr          = ADR.HausNr,
    StrasseHausNr   = ADR.Strasse + IsNull(' ' + ADR.HausNr, ''),
    Postfach        = ADR.Postfach,
    PLZ             = ADR.PLZ,
    Ort             = ADR.Ort,
    PLZOrt          = IsNull(ADR.PLZ + ' ', '') + IsNull(ADR.Ort, ''),
    Kanton          = ADR.Kanton,
    Land            = LAN.Text,
    OrtschaftCode   = ADR.OrtschaftCode,
    LandCode        = LAN.BaLandID,
    AdresseEinzeilig = (
      INS.Name + ', ' +
      IsNull(ADR.Zusatz + ', ','') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + ', ','') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseEinzOhneName = (
      IsNull(ADR.Zusatz + ', ','') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + ', ','') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseMehrzeilig = (
      INS.Name + char(13) + char(10) +
      IsNull(ADR.Zusatz + char(13) + char(10),'') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + char(13) + char(10),'') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort ),
    AdresseMehrzOhneName = (
      IsNull(ADR.Zusatz + char(13) + char(10),'') +
      IsNull(ADR.Strasse + IsNull(' ' + ADR.HausNr,'') + char(13) + char(10),'') +
      IsNull(ADR.PLZ + ' ','') + ADR.Ort )

  FROM   dbo.BaInstitution INS WITH (READUNCOMMITTED)
         LEFT OUTER JOIN dbo.BaAdresse      ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = INS.BaInstitutionID AND
                                          ADR.BaPersonID IS NULL
         LEFT OUTER JOIN dbo.BaLand					LAN WITH (READUNCOMMITTED) ON LAN.BaLandID = ADR.BaLandID
         LEFT OUTER JOIN dbo.XLOVCode       TYP WITH (READUNCOMMITTED) ON TYP.LOVName = 'BaInstitutionTyp' AND TYP.Code = INS.InstitutionTypCode

GO
GRANT SELECT ON [dbo].[vwTmInstitution] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmInstitution.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmInstitution.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmPerson.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmPerson
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmPerson.sql $
  $Author: Rstahel $
  $Modtime: 23.04.10 18:37 $
  $Revision: 6 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmPerson.sql $
 * 
 * 6     23.04.10 18:37 Rstahel
 * FrauHerrnVornameName wieder hinzugefügt (sozstu wollte dies so).
 * 
 * 5     26.01.10 11:45 Mmarghitola
 * #5616: unnötige Joins entfernt
 * 
 * 4     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 3     6.08.09 14:16 Spsota
 * Views aktualisiert für Tabelle BaLand
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: ??.??.????
Description: Textmarke für betroffene Person
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmPerson
===================================================================================================
History:
--------
??.??.???? : ????? : neu erstellt
30.07.2008 : sozheo : Wohnsitzadresse soll in jedem Fall nur ein Datensatz zurückliefern
01.08.2008 : sozheo : BaPerson.Bemerkung hinzugefügt
===================================================================================================
*/
CREATE VIEW [dbo].[vwTmPerson]
AS

SELECT PRS.BaPersonID,
  PersonenNr = PRS.BaPersonID,
  Titel = PRS.Titel,
  Name = PRS.Name,
  [FrühererName] = PRS.FruehererName,
  Vorname = PRS.Vorname,
  Vorname2 = PRS.Vorname2,
  Geburtsdatum = CONVERT(varchar,PRS.Geburtsdatum,104),
  Sterbedatum = CONVERT(varchar,PRS.Sterbedatum,104),
  AHVNummer = PRS.AHVNummer,
  Versichertennummer = PRS.Versichertennummer,
  ZIPNr = PRS.ZIPNr,
  KantonRefNr = PRS.KantonaleReferenznummer,
  SKZNr = NULL, --PRS.SKZNr,
  ZivilstandDatum = CONVERT(varchar,PRS.ZivilstandDatum ,104),
  Aufenthaltsstatus = LOVAS.Text,
  AufenthaltGueltigBis = CONVERT(varchar,PRS.AuslaenderStatusGueltigBis,104),
  TelefonP = PRS.Telefon_P,
  TelefonG = PRS.Telefon_G,
  MobilTel1 = PRS.MobilTel1,
  MobilTel2 = PRS.MobilTel2,
  EMail = PRS.EMail,
  -- Original: BemerkungNORTF = PRS.Bemerkung, -- bgr: Nicht gut da der RTF Algorithmus der Textmarken Fehler erzeugt, wenn kein RTF da ist
  BemerkungNORTF = CASE
    WHEN PRS.Bemerkung IS NOT NULL AND PRS.Bemerkung NOT like '{\rtf%' THEN '{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}\viewkind4\uc1\pard\fs20 ' + replace(CONVERT(varchar(8000),PRS.Bemerkung), char(13)+char(10), '\par ') + '}'
    ELSE PRS.Bemerkung
  END,
  Sprache = LOVSP.Text,
  EinwohnerregisterAktiv,
  DeutschKenntnis = LOVDK.Text,
  WichtigerHinweis = LOVWH.Text,

  FrauHerrVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Herr '
    WHEN 2 THEN 'Frau '
    ELSE ''
  END + IsNull(PRS.Vorname + ' ', '') + PRS.Name,
  FrauHerrnVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Herrn '
    WHEN 2 THEN 'Frau '
    ELSE ''
  END + IsNull(PRS.Vorname + ' ', '') + PRS.Name,
  GeehrteFrauHerrVornameName = CASE PRS.GeschlechtCode
    WHEN 1 THEN 'Sehr geehrter Herr '
    WHEN 2 THEN 'Sehr geehrte Frau '
    ELSE ''
  END + PRS.Vorname + ' ' + PRS.Name,

 AufenthaltsadresseEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   IsNull(ADR3.Zusatz + ', ','') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseEinzOhneName = (
   IsNull(ADR3.Zusatz + ', ','') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   IsNull(ADR3.Zusatz + char(13) + char(10),'') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortAdresseMehrzOhneName = (
   IsNull(ADR3.Zusatz + char(13) + char(10),'') +
   IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR3.PLZ + ' ','') + ADR3.Ort ),
 AufenthaltsortStrasseNr = ADR3.Strasse + IsNull(' ' + ADR3.HausNr,''),
 AufenthaltsortPLZOrt    = IsNull(ADR3.PLZ + ' ','') + ADR3.Ort,

 AufenthaltWohnortAdrEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   CASE WHEN ADR3.BaAdresseID IS NULL
    THEN IsNull(ADR1.Zusatz + ', ','') +
         IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
         IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
    ELSE IsNull(ADR3.Zusatz + ', ','') +
         IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
         IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
    END ),
 AufenthaltWohnortAdrEinzOhneName = (
   CASE WHEN ADR3.BaAdresseID IS NULL
    THEN IsNull(ADR1.Zusatz + ', ','') +
         IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
         IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
    ELSE IsNull(ADR3.Zusatz + ', ','') +
         IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + ', ','') +
         IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
    END ),
 AufenthaltWohnortAdrMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.Zusatz + char(13) + char(10),'') +
            IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.Zusatz + char(13) + char(10),'') +
            IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END ),
 AufenthaltWohnortAdrMehrzOhneName = (
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.Zusatz + char(13) + char(10),'') +
            IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.Zusatz + char(13) + char(10),'') +
            IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'') + char(13) + char(10),'') +
            IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END ),
 AufenthaltWohnsitzStrasseNr =
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'')
       ELSE ADR3.Strasse + IsNull(' ' + ADR3.HausNr,'')
       END,
 AufenthaltWohnsitzPLZOrt =
   CASE WHEN ADR3.BaAdresseID IS NULL
       THEN IsNull(ADR1.PLZ + ' ','') + ADR1.Ort
       ELSE IsNull(ADR3.PLZ + ' ','') + ADR3.Ort
       END,

 WohnsitzAdresseEinzeilig = (
   PRS.Vorname + ' ' + PRS.Name + ', ' +
   IsNull(ADR1.Zusatz + ', ','') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseEinzOhneKomma = (
   PRS.Vorname + ' ' + PRS.Name + ' ' +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ' ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseEinzOhneName = (
   IsNull(ADR1.Zusatz + ', ','') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + ', ','') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseMehrzeilig = (
   PRS.Vorname + ' ' + PRS.Name + char(13) + char(10) +
   IsNull(ADR1.Zusatz + char(13) + char(10),'') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzAdresseMehrzOhneName = (
   IsNull(ADR1.Zusatz + char(13) + char(10),'') +
   IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr,'') + char(13) + char(10),'') +
   IsNull(ADR1.PLZ + ' ','') + ADR1.Ort ),
 WohnsitzStrasseNr = ADR1.Strasse + IsNull(' ' + ADR1.HausNr,''),
 WohnsitzPLZOrt = IsNull(ADR1.PLZ + ' ','') + ADR1.Ort,

 Beruf = CASE PRS.GeschlechtCode WHEN 1 THEN BERB.BezeichnungM WHEN 2 THEN BERB.BezeichnungW ELSE BERB.Beruf END,
 BerufLetzteTaetigkeit = CASE WHEN NOT PRS.BerufCode IS NULL
    -- Letzte Taetigkeit, wenn diese erfasst wurde ...
    THEN CASE PRS.GeschlechtCode WHEN 1 THEN BERB.BezeichnungM WHEN 2 THEN BERB.BezeichnungW ELSE BERB.Beruf END
    -- ... sonst den erlernten Beruf ausgeben
    ELSE CASE PRS.GeschlechtCode WHEN 1 THEN BERE.BezeichnungM WHEN 2 THEN BERE.BezeichnungW ELSE BERE.Beruf END
  END,
 ErlernterBeruf = CASE PRS.GeschlechtCode WHEN 1 THEN BERE.BezeichnungM WHEN 2 THEN BERE.BezeichnungW ELSE BERE.Beruf END,
 Erwerbssituation = dbo.fnLOVText('BaErwerbssituation', PRS.ErwerbssituationCode),
 SpezFaehigkeiten = PRS.ArbeitSpezFaehigkeiten,

 Geschlecht = LOVG.Text,
 Heimatort = GDE.Name,
 HeimatortNationalitaet = IsNull(GDE.Name,NAT.Text),
 Religion = LOVK.Text,
 KVGAdresseEinzOhneName = (
   IsNull(ADRK.Zusatz + ', ','') +
   IsNull(ADRK.Strasse + IsNull(' ' + ADRK.HausNr,'') + ', ','') +
   IsNull(ADRK.PLZ + ' ','') + ADRK.Ort ),
 KVGMitgliedNr = KVG.MitgliedNr,
 KVGName = INSK.Name,
 NameVorname = PRS.[Name] + IsNull(', ' + PRS.Vorname, ''),
 NameVornameOhneKomma = PRS.[Name] + IsNull(' ' + PRS.Vorname, ''),
 Nationalitaet = CASE WHEN NAT.Text IS NULL AND GDE.Name IS NOT NULL  -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                 THEN 'Schweiz'
                 ELSE NAT.Text
                 END,
 Schulbildung = LOVS.Text,
 PLZHeimatort = IsNull(CAST( GDE.PLZ AS varchar ) + ' ','') + GDE.Name,
 VermieterAdresseEinzOhneName = (
   IsNull(ADRM.Zusatz + ', ','') +
   IsNull(ADRM.Strasse + IsNull(' ' + ADRM.HausNr,'') + ', ','') +
   IsNull(ADRM.PLZ + ' ','') + ADRM.Ort ),
 VermieterName = INSM.Name,
 VornameName = IsNull(PRS.Vorname + ' ','') + PRS.[Name],
 VVGAdresseEinzOhneName = (
   IsNull(ADRV.Zusatz + ', ','') +
   IsNull(ADRV.Strasse + IsNull(' ' + ADRV.HausNr,'') + ', ','') +
   IsNull(ADRV.PLZ + ' ','') + ADRV.Ort ),
 VVGMitgliedNr = VVG.MitgliedNr,
 VVGName = INSV.Name,
 WegzugDatum,-- = PRS.WegzugDatum
 WegzugOrt,
 WegzugPLZ,
 Wohnsituation = LOVW.Text,
 Wohnungsgroesse = LOVGR.Text,
 Zivilstand = LOVZ.Text,
 ZuzugDatum = PRS.ZuzugGdeDatum,
 ZuzugOrt   = PRS.ZuzugGdeOrt,
 ZuzugPLZ   = PRS.ZuzugGdePLZ,
 ZuzugStZhDat = PRS.ZuzugGdeDatum,

 InCHSeit = CONVERT(varchar, PRS.InCHSeit, 104),
 InCHSeitGeburt = CONVERT(bit, IsNull(PRS.InCHSeitGeburt, 0)),
 BFFNr = PRS.BFFNummer

FROM         dbo.BaPerson PRS WITH (READUNCOMMITTED)
-- 30.07.2008 : sozheo : Wohnsitzadresse soll in jedem Fall nur ein Datensatz zurückliefern
--    LEFT  JOIN BaAdresse             ADR1 ON ADR1.BaPersonID = PRS.BaPersonID AND ADR1.AdresseCode = 1 -- Wohnsitz
--                                  AND GetDate() BETWEEN IsNull(ADR1.DatumVon, GetDate()) AND IsNull(ADR1.DatumBis, GetDate())
    LEFT  JOIN dbo.BaAdresse             ADR1 WITH (READUNCOMMITTED) ON ADR1.BaAdresseID = (
      SELECT TOP 1 BaAdresseID FROM dbo.BaAdresse  WITH (READUNCOMMITTED)
      WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 1 /* Wohnsitz */
        AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY DatumVon DESC )

--    LEFT  JOIN BaAdresse             ADR3 ON ADR3.BaPersonID = PRS.BaPersonID AND ADR3.AdresseCode = 2 -- Aufenthalt
--                                  AND GetDate() BETWEEN IsNull(ADR3.DatumVon, GetDate()) AND IsNull(ADR3.DatumBis, GetDate())
    LEFT  JOIN BaAdresse             ADR3 ON ADR3.BaAdresseID = (
      SELECT TOP 1 BaAdresseID FROM dbo.BaAdresse  WITH (READUNCOMMITTED)
      WHERE BaPersonID = PRS.BaPersonID AND AdresseCode = 2 /* Aufenthalt */
        AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INS3 WITH (READUNCOMMITTED) ON INS3.BaInstitutionID = ADR3.BaInstitutionID
    LEFT OUTER JOIN dbo.BaBeruf               BERB WITH (READUNCOMMITTED) ON BERB.BaBerufID = PRS.BerufCode
    LEFT OUTER JOIN dbo.BaBeruf               BERE WITH (READUNCOMMITTED) ON BERE.BaBerufID = PRS.ErlernterBerufCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVG WITH (READUNCOMMITTED) ON LOVG.LOVName = 'BaGeschlecht' AND LOVG.Code = PRS.GeschlechtCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVK WITH (READUNCOMMITTED) ON LOVK.LOVName = 'BaReligion'   AND LOVK.Code = PRS.ReligionCode
    LEFT OUTER JOIN dbo.BaGemeinde            GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeCode
    LEFT OUTER JOIN dbo.BaKrankenversicherung KVG  WITH (READUNCOMMITTED) ON KVG.BaKrankenversicherungID IN ( SELECT TOP 1 BaKrankenversicherungID FROM BaKrankenversicherung WHERE BaPersonID = PRS.BaPersonID AND GesetzesGrundlageCode = 1 /* KVG */ AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate()) ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INSK WITH (READUNCOMMITTED) ON KVG.BaInstitutionID = INSK.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRK WITH (READUNCOMMITTED) ON ADRK.BaInstitutionID = KVG.BaInstitutionID
    LEFT OUTER JOIN dbo.BaKrankenversicherung VVG  WITH (READUNCOMMITTED) ON VVG.BaKrankenversicherungID IN ( SELECT TOP 1 BaKrankenversicherungID FROM BaKrankenversicherung WHERE BaPersonID = PRS.BaPersonID AND GesetzesGrundlageCode = 2 /* VVG */ AND GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate()) ORDER BY DatumVon DESC )
    LEFT OUTER JOIN dbo.BaInstitution         INSV WITH (READUNCOMMITTED) ON VVG.BaInstitutionID  = INSV.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRV WITH (READUNCOMMITTED) ON ADRV.BaInstitutionID = VVG.BaInstitutionID
    LEFT OUTER JOIN dbo.BaLand								NAT  WITH (READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVS WITH (READUNCOMMITTED) ON LOVS.LOVName = 'BaAusbildungstyp'    AND LOVS.Code = PRS.HoechsteAusbildungCode
    --LEFT  JOIN BaWohnsituationPerson BWP  ON BWP.BaPersonID = PRS.BaPersonID
    LEFT OUTER JOIN dbo.BaWohnsituation       BWO  WITH (READUNCOMMITTED) ON BWO.BaWohnsituationID IN (SELECT TOP 1 BWO.BaWohnsituationID
                                                                       FROM dbo.BaWohnsituationPerson  BWR WITH (READUNCOMMITTED)
                                                                         LEFT OUTER JOIN dbo.BaWohnsituation BWO WITH (READUNCOMMITTED) ON BWO.BaWohnsituationID = BWR.BaWohnsituationID
                                                                       WHERE BWR.BaPersonID = PRS.BaPersonID AND GetDate() BETWEEN IsNull(BWO.DatumVon, GetDate()) AND IsNull(BWO.DatumBis, GetDate()) )

    LEFT OUTER JOIN dbo.BaInstitution         INSM  WITH (READUNCOMMITTED) ON INSM.BaInstitutionID = BWO.BaInstitutionID
    LEFT OUTER JOIN dbo.BaAdresse             ADRM  WITH (READUNCOMMITTED) ON ADRM.BaInstitutionID = INSM.BaInstitutionID
    LEFT OUTER JOIN dbo.XLOVCode              LOVW  WITH (READUNCOMMITTED) ON LOVW.LOVName   = 'BaWohnstatus'             AND LOVW.Code = BWO.WohnsituationCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVGR WITH (READUNCOMMITTED) ON LOVGR.LOVName  = 'BaWohnungsgroesse'        AND LOVGR.Code = BWO.WohnungsgroesseCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVZ  WITH (READUNCOMMITTED) ON LOVZ.LOVName   = 'BaZivilstand'             AND LOVZ.Code = PRS.ZivilstandCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVAS WITH (READUNCOMMITTED) ON LOVAS.LOVName  = 'BaAufenthaltsstatus'      AND LOVAS.Code = PRS.AuslaenderStatusCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVSP WITH (READUNCOMMITTED) ON LOVSP.LOVName  = 'BaPersonSprache'          AND LOVSP.Code = PRS.SprachCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVDK WITH (READUNCOMMITTED) ON LOVDK.LOVName  = 'BaDeutschkenntnis'        AND LOVDK.Code = PRS.DeutschVerstehenCode
    LEFT OUTER JOIN dbo.XLOVCode              LOVWH WITH (READUNCOMMITTED) ON LOVWH.LOVName  = 'BaPersonWichtigerHinweis' AND LOVWH.Code = PRS.WichtigerHinweisCode

GO
GRANT SELECT ON [dbo].[vwTmPerson] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmPerson.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmPerson.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmRessourcenkarte.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmRessourcenkarte.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmRessourcenkarte
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmRessourcenkarte.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmRessourcenkarte.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmRessourcenkarte]
AS

SELECT
  FAR.FaRessourcenkarteID,
  Sozialarbeiter			= IsNull(USR.FirstName, '') + IsNull(' ' + USR.LastName, ''),
  PersoenlicheRessourcen	= FAR.RessourcenPersoenlich,
  SozialeRessourcen			= RessourcenSozial,
  MaterielleRessourcen		= RessourcenMateriell,
  InfrastrukturelleRessourcen = RessourcenInfrastrukturell
FROM dbo.FaRessourcenkarte FAR WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.FaLeistung	LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FAR.FaLeistungID
  LEFT OUTER JOIN dbo.XUser		USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID

GO
GRANT SELECT ON [dbo].[vwTmRessourcenkarte] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmRessourcenkarte.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmRessourcenkarte.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmWVCode.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmWVCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmWVCode
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmWVCode.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmWVCode.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmWVCode]
AS

SELECT	BaPersonID,
		Seit = CONVERT(varchar, DatumVon, 104),
		[Status] = dbo.fnLOVText('BaWVStatus', BaWVStatusCode),
		SKZNummer,
		DatumVon
FROM	dbo.BaWVCode WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmWVCode] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmWVCode.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmWVCode.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmZielvereinbarung.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmZielvereinbarung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmZielvereinbarung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmZielvereinbarung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:58 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmZielvereinbarung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE VIEW [dbo].[vwTmZielvereinbarung]
AS

SELECT
	FaZielvereinbarungID,
	Thema,
	Ziel1,
	Ziel2,
	Ziel3,
	Handlungsschritt1Wer,
	Handlungsschritt1Was,
	Handlungsschritt1Wann = CONVERT(varchar, Handlungsschritt1Wann, 104),
	Handlungsschritt2Wer,
	Handlungsschritt2Was,
	Handlungsschritt2Wann = CONVERT(varchar, Handlungsschritt2Wann, 104),
	Handlungsschritt3Wer,
	Handlungsschritt3Was,
	Handlungsschritt3Wann = CONVERT(varchar, Handlungsschritt3Wann, 104),
	AuftragAnKlient1Was,
	AuftragAnKlient1Wann = CONVERT(varchar, AuftragAnKlient1Wann, 104),
    AuftragAnKlient2Was,
	AuftragAnKlient2Wann = CONVERT(varchar, AuftragAnKlient2Wann, 104),
	VorgeseheneGespraeche = GespraecheGeplant,
	AuswertungGeplant = CONVERT(varchar, DatumAuswertungGeplant, 104),
	SituationThema = dbo.fnLOVText('FaZielSituationAuswertung', SituationAuswertungCode),
	Zielauswertung1 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel1AuswertungCode),
	Zielauswertung2 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel2AuswertungCode),
	Zielauswertung3 = dbo.fnLOVText('FaZielerreichungsgrad', Ziel3AuswertungCode),
	Durchgef1 = CONVERT(bit, IsNull(Handlungsschritt1Durchgefuehrt, 0)),
	Hilfreich1 = CONVERT(bit, IsNull(Handlungsschritt1Hilfreich, 0)),
	Durchgef2 = CONVERT(bit, IsNull(Handlungsschritt2Durchgefuehrt, 0)),
	Hilfreich2 = CONVERT(bit, IsNull(Handlungsschritt2Hilfreich, 0)),
	Durchgef3 = CONVERT(bit, IsNull(Handlungsschritt3Durchgefuehrt, 0)),
	Hilfreich3 = CONVERT(bit, IsNull(Handlungsschritt3Hilfreich, 0)),
	AuftragErledigt1 = CONVERT(bit, IsNull(AuftragAnKlient1Erledigt, 0)),
	AuftragHilfreich1 = CONVERT(bit, IsNull(AuftragAnKlient1Hilfreich, 0)),
	AuftragErledigt2 = CONVERT(bit, IsNull(AuftragAnKlient2Erledigt, 0)),
	AuftragHilfreich2 = CONVERT(bit, IsNull(AuftragAnKlient2Hilfreich, 0)),
	DurchgefGespraeche = GespraecheDurchgefuehrt,
	AuswertungDurchgef = CONVERT(varchar, DatumAuswertungDurchgefuehrt, 104)
FROM dbo.FaZielvereinbarung  WITH (READUNCOMMITTED)

GO
GRANT SELECT ON [dbo].[vwTmZielvereinbarung] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmZielvereinbarung.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Textmarken\ZH\vwTmZielvereinbarung.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\WhPositionsart.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\WhPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject WhPositionsart
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/WhPositionsart.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:59 $
  $Revision: 3 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/WhPositionsart.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/


CREATE VIEW [dbo].[WhPositionsart]
AS

SELECT
		BgPositionsartID, ModulID, BgKategorieCode, BgGruppeCode, Name, SortKey, BgKostenartID,
		VerwaltungSD_Default, Spezkonto, ProPerson, ProUE, Verrechenbar, Bemerkung, Masterbudget_EditMask,
		Monatsbudget_EditMask, sqlRichtlinie, VarName, BgPositionsartTS, SpezHauptvorgang, SpezTeilvorgang
FROM
		dbo.BgPositionsart WITH (READUNCOMMITTED)
WHERE
		ModulID = 3

GO
GRANT SELECT ON [dbo].[WhPositionsart] TO [tools_access]
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\WhPositionsart.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Views\Modul\ZH\WhPositionsart.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\ZH\CreateViews.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\Testing\CreateTestDB\ZH\CreateViews.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_RebuildAllViewsDispatcher.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXValidateDBO.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXValidateDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXValidateDBO;
GO
/*===============================================================================================
  $Revision: 17 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this stored procedure to validate database object such as table, view, function,
            store procedure.
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: (not used yet)
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Print out messages of validated parts and result and returns 0 on success, 1 on failure
  -
  REMARKS: Get system types from SELECT * FROM sys.types;
=================================================================================================
  TEST:    EXEC dbo.spXValidateDBO BaPerson;
           EXEC dbo.spXValidateDBO BaAdresse;
           EXEC dbo.spXValidateDBO BaPerson_Relation;
           EXEC dbo.spXValidateDBO KbBuchung;
           EXEC dbo.spXValidateDBO XArchiv;
           EXEC dbo.spXValidateDBO XMenuItem;
           EXEC dbo.spXValidateDBO XTask;
           EXEC dbo.spXValidateDBO VmBewertung;
           EXEC dbo.spXValidateDBO XProfile;
=================================================================================================*/

CREATE PROCEDURE dbo.spXValidateDBO
(
  @DBOName VARCHAR(255),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  PRINT ('---- Script version: $Revision: 16 $ ----');
  PRINT ('Info: Database "' + DB_NAME() + '"');
  
  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  DECLARE @ErrorCounter INT;
  DECLARE @FinalOutput VARCHAR(1000);
  --
  DECLARE @TableColName VARCHAR(255);
  DECLARE @TableColID INT;
  DECLARE @TableColSystemTypeID INT;
  DECLARE @TableColCollationName VARCHAR(255);
  DECLARE @TableColIsNullable BIT; 
  DECLARE @TableColIsIdentity BIT;
  DECLARE @TableColDefaultObjectID INT;
  
  -- constants
  DECLARE @COLLATION VARCHAR(255);
  DECLARE @DEBUGLEVEL INT;
  
  SET @COLLATION = 'Latin1_General_CI_AS';
  SET @DEBUGLEVEL = 0;
  
  -- set other vars
  SET @ErrorCounter = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE:
  -- ==========================================================================
  IF (@DBOType = 'U')
  BEGIN
    PRINT ('Info: Table "' + @DBOName + '"');
    PRINT ('');

    ---------------------------------------------------------------------------
    -- validate table naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate table prefix
    ---------------------------------------------------------------------------
    IF (@DBOName NOT LIKE 'Ka%' AND 
        @DBOName NOT LIKE 'Ay%' AND 
        @DBOName NOT LIKE 'Ba%' AND 
        @DBOName NOT LIKE 'Bde%' AND 
        @DBOName NOT LIKE 'Bw%' AND 
        @DBOName NOT LIKE 'Bg%' AND 
        @DBOName NOT LIKE 'Cm%' AND 
        @DBOName NOT LIKE 'Ed%' AND 
        @DBOName NOT LIKE 'Fa%' AND 
        @DBOName NOT LIKE 'Fb%' AND 
        @DBOName NOT LIKE 'Fs%' AND 
        @DBOName NOT LIKE 'Gv%' AND 
        @DBOName NOT LIKE 'Ik%' AND 
        @DBOName NOT LIKE 'In%' AND 
        @DBOName NOT LIKE 'Kb%' AND 
        @DBOName NOT LIKE 'Kbu%' AND 
        @DBOName NOT LIKE 'Kes%' AND 
        @DBOName NOT LIKE 'Kg%' AND 
        @DBOName NOT LIKE 'Qry%' AND 
        @DBOName NOT LIKE 'Sst%' AND 
        @DBOName NOT LIKE 'Bfs%' AND 
        @DBOName NOT LIKE 'Sb%' AND 
        @DBOName NOT LIKE 'Wh%' AND 
        @DBOName NOT LIKE 'Wsh%' AND 
        @DBOName NOT LIKE 'Vm%' AND 
        @DBOName NOT LIKE 'X%')
    BEGIN
      PRINT ('>>> Error: The table prefix for table "' + @DBOName + '" is not valid');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate PK
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'ID';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The primary key column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the first column
      IF (@TableColID > 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" should be the first column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be INT
      IF (@TableColSystemTypeID <> 56)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must be typeof INT');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be identity
      IF (@TableColIsIdentity = 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" is not an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate TS
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'TS';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The timestamp column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the last column
      IF (@TableColID <> (SELECT MAX(column_id) 
                          FROM sys.columns
                          WHERE object_id = @DBOObjectID))
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" should be the last column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be TIMESTAMP
      IF (@TableColSystemTypeID <> 189)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must be typeof TIMESTAMP');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be identity
      IF (@TableColIsIdentity = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns existing: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Creator'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Creator" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- created
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Created'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Created" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modifier'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modified
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modified'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Modified" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns defaults: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Creator'))
    BEGIN
      PRINT ('>>> Error: The column "Creator" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Creator'
    END;
    
    -- created (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Created'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Created" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Modifier'))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Modifier'
    END;
    
    -- modified (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Modified'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Modified" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(
                            name, 'a', ''), 'b', ''), 'c', ''), 'd', ''), 'e', ''), 'f', ''), 'g', ''),
                                  'h', ''), 'i', ''), 'j', ''), 'k', ''), 'l', ''), 'm', ''), 'n', ''),
                                  'o', ''), 'p', ''), 'q', ''), 'r', ''), 's', ''), 't', ''), 'u', ''),
                                  'v', ''), 'w', ''), 'x', ''), 'y', ''), 'z', ''),
                                  '0', ''), '1', ''), '2', ''), '3', ''), '4', ''), '5', ''), '6', ''),
                                  '7', ''), '8', ''), '9', ''),
                                  '_', ''))
                            > 0))
    BEGIN
      PRINT ('>>> Error: There is at least one column name with wrong chars (not in [a-z],[A-Z],[0-9],[_])');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming same as tablename
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE name = @DBOName))
    BEGIN
      PRINT ('>>> Error: There is a column with the same name as the table. This will be a problem with its C# class and property.');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND system_type_id = 104 -- BIT
                  AND default_object_id = 0))
    BEGIN
      PRINT ('>>> Error: There is at least one BIT column without a default value');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithoutBITDefault = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND system_type_id = 104 -- BIT
        AND default_object_id = 0
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT defaults (0)
    ---------------------------------------------------------------------------
    -- TODO

    ---------------------------------------------------------------------------
    -- validate defaulted not null columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND default_object_id > 0
                  AND is_nullable = 1))
    BEGIN
      PRINT ('>>> Error: There is at least one column with default value that is nullable');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithDefaultNullable = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND default_object_id > 0
        AND is_nullable = 1
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Code
    ---------------------------------------------------------------------------
    -- INT
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND COL.system_type_id <> 56))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column not typeof INT');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeNotTypeOfINT = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND COL.system_type_id <> 56
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Codes
    ---------------------------------------------------------------------------
    -- VARCHAR
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND (COL.system_type_id <> 167 OR COL.max_length <> 255)))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column not typeof VARCHAR(255)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesNotTypeOfVARCHAR255 = COL.name,
             ColumnDataType                     = (SELECT TYP.NAME
                                                   FROM sys.types TYP
                                                   WHERE TYP.system_type_id = COL.system_type_id),
             ColumnDataLength                   = COL.max_length
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND (COL.system_type_id <> 167 OR COL.max_length <> 255)
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate clustered index for PK
    ---------------------------------------------------------------------------
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.indexes IDX
                    WHERE IDX.object_id = @DBOObjectID
                      AND IDX.name = 'PK_' + @DBOName
                      AND IDX.type = 1                -- CLUSTERED
                      AND IDX.is_primary_key = 1
                      AND IDX.is_disabled = 0))
    BEGIN
      PRINT ('>>> Error: The primary key does not have a corresponding CLUSTERED index "PK_' + @DBOName + '"');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate FK columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_key_columns FKC
                  INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                                AND COL.column_id = FKC.parent_column_id
                WHERE FKC.parent_object_id = @DBOObjectID
                  AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
                  AND COL.name NOT IN (SELECT SCOL.name
                                       FROM sys.columns SCOL
                                       WHERE SCOL.object_id = FKC.referenced_object_id
                                         AND SCOL.column_id = FKC.referenced_column_id)))
    BEGIN
      PRINT ('>>> Error: There is at least one FK column with different naming compared to corresponding PK column');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKColumnName = COL.name
      FROM sys.foreign_key_columns FKC
        INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                      AND COL.column_id = FKC.parent_column_id
      WHERE FKC.parent_object_id = @DBOObjectID
        AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
        AND COL.name NOT IN (SELECT SCOL.name
                             FROM sys.columns SCOL
                             WHERE SCOL.object_id = FKC.referenced_object_id
                               AND SCOL.column_id = FKC.referenced_column_id);
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys naming
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND (-- FK name
                       FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
                       -- PK table without description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
                    AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                              FROM sys.tables TBL))
                       -- PK table with description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
                    AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                  CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                                         FROM sys.tables TBL)))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKName = FKS.name
      FROM sys.foreign_keys FKS
      WHERE FKS.parent_object_id = @DBOObjectID
        AND (-- FK name
             FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
             -- PK table without description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
          AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                    FROM sys.tables TBL))
             -- PK table with description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
          AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                        CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                               FROM sys.tables TBL)));
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys having at least one index that starts with column
    -- --> valid are IX or UK
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                  INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                                        AND FKC.constraint_object_id = FKS.object_id
                  INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                                        AND COL.column_id = FKC.parent_column_id
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM sys.indexes IDX
                                  WHERE IDX.object_id = @DBOObjectID
                                    AND IDX.type = 2            -- only NONCLUSTERED
                                    AND IDX.is_primary_key = 0  -- only FKs
                                    AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                                         IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not have an index assigned (each FK should have its IX or UK)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT MissingIXOrUKForFKCol = COL.name,
             MissingIXOrUKForFK    = FKS.name
      FROM sys.foreign_keys FKS
        INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                              AND FKC.constraint_object_id = FKS.object_id
        INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                              AND COL.column_id = FKC.parent_column_id
      WHERE FKS.parent_object_id = @DBOObjectID
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM sys.indexes IDX
                        WHERE IDX.object_id = @DBOObjectID
                          AND IDX.type = 2            -- only NONCLUSTERED
                          AND IDX.is_primary_key = 0  -- only FKs
                          AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                               IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'));
    END;
    
    ---------------------------------------------------------------------------
    -- foreignkeys sorting just after PK in table
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate collation of columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE COL.object_id = @DBOObjectID
                  AND COL.collation_name IS NOT NULL
                  AND COL.collation_name <> @COLLATION))
    BEGIN
      PRINT ('>>> Error: There is at least one column with non-standard collation ("' + @COLLATION + '")');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidCollationColumnName = COL.name,
             CollationNameOfColumn      = COL.collation_name
      FROM sys.columns COL
      WHERE COL.object_id = @DBOObjectID
        AND COL.collation_name IS NOT NULL
        AND COL.collation_name <> @COLLATION
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming IX_<TableName>
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 0  -- no UKs
                  AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one IX which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidIXName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 0  -- no UKs
        AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming (IX, UK) IX_<TableName>[<_ColumnName]+
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- unique-key naming (UK) UK_<TableName>...
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 1  -- UKs
                  AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one UK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidUKName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 1  -- UKs
        AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- unique-key type (UK) UK_<TableName>... >> no unique indexes
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate IX/UK having same filegroup as table
    ---------------------------------------------------------------------------
    IF ((SELECT COUNT(DISTINCT IDX.groupid)
         FROM sys.tables        TBL WITH (NOLOCK)
           LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                                 AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
         WHERE TBL.object_id = @DBOObjectID) > 1)
    BEGIN
      PRINT ('>>> Error: There is at least one IX/UK with different filegroup (each of them should have same as table)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT TableName    = TBL.name,
             IndexName    = ISNULL(IDX.[name], 'NA'),
             IndexType    = CASE 
                              WHEN IDX.indid = 0 THEN 'Table Row Data (table has no clustered index)'
                              WHEN IDX.indid = 1 THEN 'Clustered Index (and table row data)'
                              WHEN IDX.indid = 255 THEN 'TEXT/NTEXT/IMAGE/XML Column Data'
                              ELSE 'NonClustered Index'
                            END,
              IndexID     = ISNULL(IDX.indid, -1),
              FileGroup   = FILEGROUP_NAME(IDX.groupid),
              FileGroupID = IDX.groupid
      FROM sys.tables        TBL WITH (NOLOCK)
        LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                              AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
      WHERE TBL.object_id = @DBOObjectID
      ORDER BY IndexID;
    END;
    
    ---------------------------------------------------------------------------
    -- validating default constraints DF
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.objects OBJ
                WHERE OBJ.parent_object_id = @DBOObjectID
                  AND type = 'D'
                  AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
                    OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                             FROM sys.columns COL
                                                                             WHERE COL.object_id = @DBOObjectID))))
    BEGIN
      PRINT ('>>> Error: There is at least one DF which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidDefaultConstraintName = OBJ.name
      FROM sys.objects OBJ
      WHERE OBJ.parent_object_id = @DBOObjectID
        AND type = 'D'
        AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
          OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                   FROM sys.columns COL
                                                                   WHERE COL.object_id = @DBOObjectID))
    END;
    
    ---------------------------------------------------------------------------
    -- constraints CK
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- trigger
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- extended properties for table
    ---------------------------------------------------------------------------
    -- table description
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND EXT.name = 'MS_Description'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have a description assigned (extended property "MS_Description")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- table author
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND name = 'Author'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have an author assigned (extended property "Author")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- error?
    ---------------------------------------------------------------------------
    IF (@ErrorCounter = 0)
    BEGIN
      SET @FinalOutput = 'Info: The table "' + @DBOName + '" survived the basic checks without any remarks!';
    END
    ELSE
    BEGIN
      SET @FinalOutput = 'Info: The script detected <' + CONVERT(VARCHAR(50), @ErrorCounter) + '> problem(s) for table "' + @DBOName + '"!';
    END;
    
    -- done
    GOTO DONE;
  END;
  -- ==========================================================================
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported for validation yet')
  RETURN 1;
  -- ==========================================================================

-- ****************************************************************************
-- FINAL STUFF
-- ****************************************************************************
DONE:
  IF (@ErrorCounter > 0)
  BEGIN
    PRINT ('');
  END;

  PRINT ('--------------------------------------------------------------------------------');
  PRINT @FinalOutput;
  PRINT ('--------------------------------------------------------------------------------');

  IF (@ErrorCounter = 0)
  BEGIN
    -- no problems
    PRINT ('                        boing         boing         boing');
    PRINT ('          e-e           . - .         . - .         . - .');
    PRINT ('         (\_/)\       ''       `.   ,''       `.   ,''       .');
    PRINT ('          `-''\ `--.___,         . .           . .          .');
    PRINT ('             ''\( ,_.-''''');
    PRINT ('                \\               "             "            a:f');
  END
  ELSE
  BEGIN
    -- found problems
    PRINT ('          \|||/');
    PRINT ('          (o o)');
    PRINT ('  ,~~~ooO~~(_)~~~~~~~~~~,');
    PRINT ('  |       Please        |');
    PRINT ('  |  fix the problems!  |');
    PRINT ('  |       Thanks!       |');
    PRINT ('  ''~~~~~~~~~~~~~~ooO~~~~''');
    PRINT ('         |__|__|');
    PRINT ('          || ||');
    PRINT ('         ooO Ooo');
  END;
  
  PRINT ('--------------------------------------------------------------------------------');
  
  -- return value
  RETURN CASE
           WHEN @ErrorCounter = 0 THEN 0    -- ok
           ELSE 1                           -- failure
         END;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXValidateDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXValidateDBO.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXExtendedProperty;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  (Re)create or delete extended properties for database objects
    @DBOName:                 The name of the main database object (e.g. table "BaPerson")
    @ChildDBOName:            The name of the sub database object (e.g. column "BaPersonID")
    @ExtendedPropertyName:    The name of the extended property (e.g. "MS_Description")
    @ExtendedPropertyContent: The value of the extended property (e.g. description)
    @ErrorIfExisting:         Flag: 0=if extended property already exists, it will be dropped first
                                    1=if extended property already exists, an error will raise
    @DeleteOnly:              Flag: 0=a new extended property will be added
                                    1=no new extended property will be added - dropping only
  -
  RETURNS: No resultset will be returned - only printed messages
=================================================================================================
  TEST:    EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', 'ModulID', 'MS_Description', 'TestMe', 0, 0;
           --
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'MS_Description', 'TestMe', 0, 0;
           -- expecting errors
           EXEC dbo.spXExtendedProperty 'XClass', 'abc', 'MS_Description', 'TestMe', 1, 0;
           EXEC dbo.spXExtendedProperty 'XClasse', NULL, 'MS_Description', 'TestMe', 0, 1;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, NULL, 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty 'XClass', NULL, 'Abc', NULL, 0, 0;
           EXEC dbo.spXExtendedProperty NULL, NULL, 'Abc', 'TestMe', 0, 0;
           EXEC dbo.spXExtendedProperty '', NULL, 'Abc', 'TestMe', 0, 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spXExtendedProperty
(
  @DBOName VARCHAR(255),
  @ChildDBOName VARCHAR(255),
  @ExtendedPropertyName VARCHAR(255),
  @ExtendedPropertyContent VARCHAR(2000),
  @ErrorIfExisting BIT = 0,
  @DeleteOnly BIT = 0
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @DBOType VARCHAR(255);
  DECLARE @ChildDBOType VARCHAR(255);
  DECLARE @ExtendedPropertyExistsAlready BIT;
  DECLARE @ErrorMessage VARCHAR(2000);
  DECLARE @Schema VARCHAR(200);
  
  SET @DBOType = NULL;
  SET @ChildDBOType = NULL;
  SET @ExtendedPropertyExistsAlready = NULL;
  
  -----------------------------------------------------------------------------
  -- get types
  -----------------------------------------------------------------------------
  -- tables (with optional columns)
  IF (EXISTS (SELECT TOP 1 1
              FROM sys.tables
              WHERE name = @DBOName))
  BEGIN
    SET @DBOType = 'TABLE';
    SET @Schema = ( SELECT DISTINCT TABLE_SCHEMA
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = @DBOName );
    
    IF (@ChildDBOName IS NOT NULL)
    BEGIN
      SET @ChildDBOType = 'COLUMN';
    END;
  END;
  
  -- todo: if required, add further type handling...
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DBOName, '') = '' OR ISNULL(@ExtendedPropertyName, '') = '' OR ISNULL(@ExtendedPropertyContent, '') = '')
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Invalid database object "' + ISNULL(@DBOName, '??') + '" or extended property name/content "' + ISNULL(@ExtendedPropertyName, '') + '".';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  IF (@DBOType IS NULL OR (@ChildDBOName IS NOT NULL AND @ChildDBOType IS NULL))
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: Could not get known type of database object "' + ISNULL(@DBOName, '??') + '". Either name is not valid or type "' + ISNULL(@DBOType, '') + '" is not supported.';
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- check existing handling (type specific)
  -----------------------------------------------------------------------------
  IF (@DBOType = 'TABLE')
  BEGIN
    -- check if existing
    IF (EXISTS (SELECT TableName     = OBJECT_NAME(EXT.major_id), 
                       ColumnName    = COL.name, 
                       PropertyName  = EXT.name, 
                       PropertyValue = EXT.value
                FROM sys.extended_properties EXT
                  LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id
                                                AND COL.column_id = EXT.minor_id
                WHERE EXT.class_desc = 'OBJECT_OR_COLUMN'
                  AND OBJECT_NAME(EXT.major_id) = @DBOName
                  AND EXT.name = @ExtendedPropertyName
                  AND ((@ChildDBOName IS NULL AND EXT.minor_id = 0) 
                    OR (@ChildDBOName IS NOT NULL AND COL.name = @ChildDBOName))
               ))
    BEGIN
      SET @ExtendedPropertyExistsAlready = 1;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- general extended property handling
  -----------------------------------------------------------------------------  
  -- check if can delete if existing
  IF (@ErrorIfExisting = 1 AND @ExtendedPropertyExistsAlready = 1)
  BEGIN
    -- do not continue
    SET @ErrorMessage = 'Error: The extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" already exists for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', '');
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END;
  
  -- check if need to delete
  IF (@ExtendedPropertyExistsAlready = 1)
  BEGIN
    BEGIN TRANSACTION;
    
    BEGIN TRY
      -- delete extended property
      EXEC sys.sp_dropextendedproperty @name = @ExtendedPropertyName, 
                                       @level0type = N'SCHEMA', @level0name = @Schema, 
                                       @level1type = @DBOType, @level1name = @DBOName, 
                                       @level2type = @ChildDBOType, @level2name = @ChildDBOName;
      
      COMMIT;
      
      -- show info
      PRINT ('Info: Dropped extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
    END TRY
    BEGIN CATCH
      -- rollback any action
      ROLLBACK TRANSACTION;
      
      -- set error part
      SET @ErrorMessage = ERROR_MESSAGE()
      
      -- do not continue
      RAISERROR ('Error: Could not drop extended property. Database error was: %s.', 18, 1, @ErrorMessage);
      RETURN;
    END CATCH;
  END;
  
  -- check if need to continue
  IF (@DeleteOnly = 1)
  BEGIN
    -- no more to do
    RETURN;
  END;
  
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to create extended property
    EXEC sys.sp_addextendedproperty @name = @ExtendedPropertyName, @value = @ExtendedPropertyContent, 
                                    @level0type = N'SCHEMA', @level0name = @Schema, 
                                    @level1type = @DBOType, @level1name = @DBOName, 
                                    @level2type = @ChildDBOType, @level2name = @ChildDBOName;
    
    COMMIT;
    
    -- show info
    PRINT ('Info: Added extended property "' + ISNULL(@ExtendedPropertyName, '??') + '" for ' + ISNULL(@DBOType, '??') + ' "' + ISNULL(@DBOName, '??') + '"' + ISNULL(' and ' + @ChildDBOType + ' "' + @ChildDBOName + '"', ''));
  END TRY
  BEGIN CATCH
    -- rollback any action
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()
    
    -- do not continue
    RAISERROR ('Error: Could not add extended property. Database error was: %s.', 18, 1, @ErrorMessage);
    RETURN;
  END CATCH;
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spXExtendedProperty.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaInsertFaFall;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Führt INSERT in FaFall aus, falls FaFall eine Tabelle ist, sonst wird ein 
            erfolgreiches INSERT vorgegaukelt
=================================================================================================
  TEST:    EXEC dbo.spFaInsertFaFall …;
=================================================================================================*/

CREATE PROCEDURE dbo.spFaInsertFaFall
(
  @UserID     int,
  @BaPersonID int,
  @DatumVon   datetime,
  @DatumBis   datetime
)
AS
BEGIN
  -- nur in Tabelle inserten
  IF EXISTS(SELECT TOP 1 1
            FROM sysobjects
            WHERE Name = 'FaFall' and xtype = 'U') BEGIN

    DECLARE @SQLString nvarchar(500);
    DECLARE @ParmDefinition nvarchar(500);

    SET @SQLString = N'INSERT INTO dbo.FaFall(UserID, BaPersonID, DatumVon, DatumBis)
                       VALUES (@UserID_, @BaPersonID_, @DatumVon_, @DatumBis_)
                       
                       SELECT FaFallID = SCOPE_IDENTITY()';
    SET @ParmDefinition = N'@UserID_ int, @BaPersonID_ int, @DatumVon_ datetime, @DatumBis_ datetime';

    EXECUTE sp_executesql @SQLString, @ParmDefinition,
                          @UserID_ = @UserID, @BaPersonID_ = @BaPersonID, @DatumVon_ = @DatumVon, @DatumBis_ = @DatumBis;
  END
  ELSE BEGIN
    SELECT FaFallID = @BaPersonID -- fake
  END
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\Fallführung\spFaInsertFaFall.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDBO.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spDBO;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the dbo definition (columns, additional data, code) for given dbo name
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables/Views: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
                   - 3 = print columns as DECLARE for vars instead of description content
                 - Others:
                   - 0 = default (print output)
                   - 1 = output of definition as select
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Shows the definition of the object and returns 0 on success, 1 on failure
=================================================================================================
  TEST:    EXEC dbo.spDBO 'BaPerson';
           EXEC dbo.spDBO 'BaPerson', NULL, 'U';
           EXEC dbo.spDBO 'XUser', NULL;
           EXEC dbo.spDBO 'XProfileTag', NULL;
           --
           EXEC dbo.spDBO 'fnDateOf', 1;
           EXEC dbo.spDBO 'fnDateOf', 0;
           --
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 1;
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spDBO
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  
  -- constants
  DECLARE @DEBUGLEVEL INT;
  SET @DEBUGLEVEL = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE/VIEW:
  -- ==========================================================================
  IF (@DBOType IN ('U', 'V'))
  BEGIN
    ---------------------------------------------------------------------------
    -- init temporary table for description
    ---------------------------------------------------------------------------
    DECLARE @TmpDescription TABLE
    (
      TableName VARCHAR(255) NOT NULL,
      ColumnName VARCHAR(255),
      PropertyName VARCHAR(255),
      PropertyValue VARCHAR(2000)
    );
    
    -----------------------------------------------------------------------------
    -- get description for given table
    -----------------------------------------------------------------------------
    -- fill data
    INSERT INTO @TmpDescription (TableName, ColumnName, PropertyName, PropertyValue)
      SELECT TableName     = OBJECT_NAME(EXT.major_id),
             ColumnName    = COL.Name,
             PropertyName  = EXT.Name,
             PropertyValue = CONVERT(VARCHAR(2000), EXT.value)
      FROM sys.extended_properties EXT
        LEFT JOIN sys.columns      COL ON COL.OBJECT_ID = EXT.major_id 
                                      AND COL.column_id = EXT.minor_id
      WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
        AND EXT.major_id = @DBOObjectID                                 -- only for current dbo
        AND EXT.Name IN ('MS_Description', 'Author', 'Used_In', 'NamespaceExtension');
    
    -----------------------------------------------------------------------------
    -- show table information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 1) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT [TableName]           = @DBOName,
             [Author]              = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Author'),
             [UsedIn]              = (SELECT TMP.PropertyValue
                                     FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Used_In'),
             [Description]         = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'MS_Description'),
             [ColumnsCount]        = (SELECT COUNT(1)
                                      FROM sys.columns
                                      WHERE object_id = @DBOObjectID),
             [NamespaceExtension]  = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'NamespaceExtension');
    END;
    
    -----------------------------------------------------------------------------
    -- show table-column information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 2) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT ColumnName           = COL.name,
             DataType             = UPPER(TYP.name),
             [Length]             = CASE
                                      WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                      ELSE CONVERT(VARCHAR(20), COL.max_length)
                                    END,
             NotNull              = CASE COL.is_nullable 
                                      WHEN 1 THEN ''
                                      ELSE 'x'
                                    END,
             DefaultValue         = REPLACE(REPLACE(ISNULL((DEF.Text), ''), '((0))', '0'), '(0)', '0'),
             PrimaryKey           = ISNULL((SELECT CASE SKEY.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.key_constraints       SKEY
                                              INNER JOIN sys.index_columns SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                                               AND SIXC.index_id = SKEY.unique_index_id
                                                                               AND SIXC.column_id = COL.column_id
                                            WHERE SKEY.type = 'PK'
                                              AND SKEY.parent_object_id = COL.object_id), ''), 
             [Identity]           = CASE COL.is_identity
                                      WHEN 1 THEN 'x'
                                      ELSE ''
                                    END,
             ForeignKey           = ISNULL((SELECT DISTINCT -- used for multiple FKs
                                                   CASE SCOL.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.foreign_key_columns SFKC
                                              INNER JOIN sys.columns     SCOL ON SCOL.object_id = COL.object_id
                                                                             AND SCOL.column_id = COL.column_id
                                                                             AND SCOL.column_id = SFKC.parent_column_id
                                            WHERE SFKC.parent_object_id = COL.object_id), ''),
             [Description]        = CASE @OutputMode
                                      WHEN 3 THEN -- output as var declaration
                                                  'DECLARE @' + COL.name + ' ' + 
                                                  CASE
                                                    WHEN TYP.name IN ('DECIMAL', 'NUMERIC')
                                                      THEN UPPER(TYP.name) + '(x, y);  -- TODO: set x, y'
                                                    WHEN TYP.name IN ('FLOAT', 'VARCHAR', 'CHAR', 'NVARCHAR', 'NCHAR', 'BINARY', 'VARBINARY')
                                                      THEN UPPER(TYP.name) + '(' + CASE
                                                                                     WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                                                                     ELSE CONVERT(VARCHAR(20), COL.max_length)
                                                                                   END + ');'
                                                    WHEN TYP.name = 'TEXT'      THEN 'VARCHAR(MAX);'  + '  -- original as "TEXT"'
                                                    WHEN TYP.name = 'NTEXT'     THEN 'NVARCHAR(MAX);' + '  -- original as "NTEXT"'
                                                    WHEN TYP.name = 'TIMESTAMP' THEN 'BINARY(8);'     + '  -- original as "TIMESTAMP"'
                                                    ELSE UPPER(TYP.name) + ';'
                                                  END
                                      ELSE (SELECT TMP.PropertyValue
                                            FROM @TmpDescription TMP
                                            WHERE TMP.ColumnName = COL.[Name] 
                                              AND TMP.PropertyName = 'MS_Description')
                                    END,
             [NamespaceExtension] = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName = COL.[Name] 
                                        AND TMP.PropertyName = 'NamespaceExtension')
      FROM sys.columns         COL
        INNER JOIN sys.types   TYP ON TYP.system_type_id = COL.system_type_id
        LEFT  JOIN syscomments DEF ON DEF.id = COL.default_object_id
      WHERE COL.object_id = @DBOObjectID
      ORDER BY COL.column_id;
    END;

    -- return value
    RETURN CASE @@ROWCOUNT 
             WHEN 0 THEN 1 
             ELSE 0 
           END;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- FUNCTION/STOREDPROCEDURE/TRIGGER/CONSTRAINT:
  -- ==========================================================================
  IF (@DBOType IN ('FN', 'IF', 'TF', 'P', 'TR', 'C', 'D'))
  BEGIN
    -- init vars
    DECLARE @DBODefinition VARCHAR(MAX);
    
    -- get definition
    SET @DBODefinition = ISNULL(OBJECT_DEFINITION(OBJECT_ID(@DBOName)), '>>> Error: Could not get object definition of "' + @DBOName + '" with type "' + @DBOType + '"');
    
    IF (@OutputMode = 1)
    BEGIN
      -- output definiton within SELECT statement
      SELECT [DBOName]    = @DBOName,
             [Length]     = LEN(@DBODefinition),
             [Definition] = @DBODefinition;
    END
    ELSE
    BEGIN
      -- init vars
      DECLARE @DBODefLength BIGINT;
      DECLARE @DBODefCharAtNewLine BIGINT;
            
      -- print can handle only 8000 chars, so we need to check that
      IF (LEN(@DBODefinition) < 8000)
      BEGIN
        -- print out directly
        PRINT (@DBODefinition);
      END
      ELSE
      BEGIN
        -- print out in multiple steps
        WHILE (LEN(@DBODefinition) > 0)
        BEGIN
          -- get position of next newline to have proper text output
          SET @DBODefCharAtNewLine = CHARINDEX(CHAR(10), SUBSTRING(@DBODefinition, 1, 8000), 6000);
         
          IF (@DBODefCharAtNewLine < 1)
          BEGIN
            -- no newline, take max output
            SET @DBODefCharAtNewLine = 8000;
          END;
          
          -- print out first part of chars
          PRINT (SUBSTRING(@DBODefinition, 1, @DBODefCharAtNewLine));
          SET @DBODefLength = LEN(@DBODefinition);
          
          -- cut first part of chars
          IF (@DBODefLength > @DBODefCharAtNewLine)
          BEGIN
            SET @DBODefinition = SUBSTRING(@DBODefinition, @DBODefCharAtNewLine, @DBODefLength - @DBODefCharAtNewLine);
          END
          ELSE
          BEGIN
            SET @DBODefinition = '';
          END;
        END;
      END;
    END;
    
    -- success
    RETURN 0;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported')
  
  -- failure
  RETURN 1;
  -- ==========================================================================
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDBO.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\spDBO.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\TBL.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\TBL.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject TBL;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the table-definition (columns, additional data) for given table
    @DBOName:    The name of table to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
  -
  RETURNS: Shows the definition of the table
=================================================================================================
  TEST:    EXEC dbo.TBL 'BaPerson';
           EXEC dbo.TBL 'BaPerson', 0;
           EXEC dbo.TBL 'BaPerson', 1;
           EXEC dbo.TBL 'BaPerson', 2;
           --
           TBL BaPerson;
           TBL BaPerson, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.TBL
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL
)
AS
BEGIN
  EXEC dbo.spDBO @DBOName, @OutputMode, 'U';
END;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\TBL.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\TBL.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\LOV.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\LOV.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject LOV;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show LOVCode entries for LIKE matching search value
    @LOVSerachValue: The search name for any LOVName containing the name
  -
  RETURNS: Table of matching entries within table LOVCode
=================================================================================================
  TEST:    LOV Modul
=================================================================================================*/

CREATE PROCEDURE dbo.LOV
(
  @SearchLOVName VARCHAR(50)
)
AS
BEGIN
  SELECT LOVName, 
         Code, 
         Text, 
         TextTID, 
         SortKey, 
         ShortText, 
         ShortTextTID, 
         BFSCode, 
         Value1, 
         Value1TID, 
         Value2, 
         Value2TID, 
         Value3, 
         Value3TID, 
         Description,
         LOVCodeName,
         IsActive,
         System, 
         XLOVCodeTS
  FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
  WHERE LOVName LIKE '%' + @SearchLOVName + '%'
  ORDER BY LOVName, SortKey;
END;

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\LOV.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\LOV.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\USR.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\USR.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject USR
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Search for users using either name, login name or ID
    @UserSearchValue: .
  -
  RETURNS: .
=================================================================================================
  TEST: USR biag
=================================================================================================*/
CREATE PROCEDURE [dbo].[USR]
(
  @UserSearchValue VARCHAR(50)
)
AS
BEGIN
  SELECT *
  FROM dbo.XUser
  WHERE LastName LIKE '%' + @UserSearchValue + '%'
     OR FirstName LIKE '%' + @UserSearchValue + '%'
     OR LogonName LIKE  '%' + @UserSearchValue + '%'
     OR ShortName LIKE  '%' + @UserSearchValue + '%'
     OR CONVERT(VARCHAR, UserID) LIKE '%' + @UserSearchValue + '%'
  ORDER BY LastName, FirstName;
END;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\USR.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\DBOs\Stored Procedures\System\USR.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to add server-version to table XDBServerVersion. With this, we can
           always proof which version was installed at a given time.
=================================================================================================
I wrote about versioning of old software recently and how I had to restore an old version of
SQL Server in response to a lawsuit. We had some challenges because the backup file that we
had was from years before and we weren't sure which version of SQL Server we needed. I forget
how we finally determined which service pack was needed, perhaps we read master somehow to
get a build.

In any case, when you apply patches or change how SQL Server functions, you can change the
way that code is executed or even the results that might be returned to an application.
You would hope that code would break and error out rather than return different results
than you expect.
Since many of us patch servers when Service Packs come out, or when we find a hot fix we
need, and we are constantly deploying and changing code, do we pay enough attention to
the server version as we make these deployments? I started thinking about this after the
last editorial and I think that we often take it for granted that we can easily recreate
our environments.

Consider what would happen in the event of a disaster. Suppose that one of your server
instances, any particular instance, died and you had to go back to a backup of the database,
would you know what version of SQL Server is needed? Do you know what version each of your
instances is using right now?

In some ways this makes me think that only installing RTM and Service Pack versions in
your production environment is a good idea. It's easier to track things if you keep all
your instances within a very narrow band of versions, and the worst case would be attempting
a restore on RTM, then SP1, then SP2, etc. until you hit the correct version. Imagine now
if you had to work through the various builds on my build list.

I used to think that I'd want to keep current on my patches. In one large environment, we
were actually pretty good about deploying patches to hundreds of instances inside a month,
so we always had a large percentage of our servers, and usually all the critical servers,
at the same patch level. However if a disaster had occurred within the month, we wouldn't
necessarily have been sure of what versions were installed.

I really don't have a great recommendation on how to handle this other than build some
automated system that tracks the current build number on a daily basis, perhaps even
putting it in each database. At least then you'll have it handy in the event of a disaster.

Steve Jones from SQLServerCentral.com

See: http://www.sqlservercentral.com/articles/Administration/2960/
=================================================================================================*/

-------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

------------------------------------------------------------------------------
-- init vars
------------------------------------------------------------------------------
DECLARE @LastServerVersion VARCHAR(255);

------------------------------------------------------------------------------
-- get last server version stored in table
------------------------------------------------------------------------------
SELECT TOP 1
       @LastServerVersion = DBS.ServerVersion
FROM dbo.XDBServerVersion DBS WITH (READUNCOMMITTED)
ORDER BY XDBServerVersionID DESC;

------------------------------------------------------------------------------
-- compare with current version
------------------------------------------------------------------------------
IF (ISNULL(@LastServerVersion, '') <> ISNULL(@@VERSION, '??'))
BEGIN
  -- automatically insert new version if last entry does not match first entry
  INSERT INTO dbo.XDBServerVersion (Creator)
  VALUES ('ReleaseScript')
  
  -- info
  PRINT ('Info: New database-server-version was detected and inserted in table XDBServerVersion: ' + ISNULL(@@VERSION, '??'));
END
ELSE
BEGIN
  -- still having the same version as in previous release
  -- info
  PRINT ('Info: Database-server-version did not change since last release: ' + ISNULL(@@VERSION, '??'));
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Update_XDBServerVersion.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply KiSS database default settings on every release.
           
           Excluded settings:
           - recovery model
           - database owner
           - autogrowth >> depending on current database size and name, see comment in code
           - TODO: what else??
           
           See: /Database/Scripts/Automation/ApplySettingsToDatabases.sql
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- compatibility level (first)
-------------------------------------------------------------------------------------------------
-- set and validate server version
DECLARE @SQLSERVER2005 INT;
DECLARE @SQLSERVER2008 INT;
DECLARE @SQLSERVER2012 INT;
DECLARE @SQLSERVER2014 INT;

SET @SQLSERVER2005 = 2005;
SET @SQLSERVER2008 = 2008;
SET @SQLSERVER2012 = 2012;
SET @SQLSERVER2014 = 2014;

DECLARE @ServerVersion INT;
DECLARE @NewCompatibilityLevel INT;

SET @ServerVersion = CASE
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2005%' THEN @SQLSERVER2005
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2008%' THEN @SQLSERVER2008
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2012%' THEN @SQLSERVER2012
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2014%' THEN @SQLSERVER2014
                       ELSE NULL
                     END;

SET @NewCompatibilityLevel = CASE @ServerVersion
                               WHEN @SQLSERVER2005 THEN 90
                               WHEN @SQLSERVER2008 THEN 100
                               WHEN @SQLSERVER2012 THEN 110
                               WHEN @SQLSERVER2014 THEN 120
                               ELSE NULL
                             END;

IF (@ServerVersion IS NULL OR @NewCompatibilityLevel IS NULL)
BEGIN
  -- do not continue
  RAISERROR ('Error: Current SQL-Server version is not supported: Version=(''%s'')!', 18, 1, @@Version);
  RETURN;
END;

-- setup vars
DECLARE @DBName NVARCHAR(255);
DECLARE @CompatibilityLevel INT;

SELECT @DBName = DBS.name, 
       @CompatibilityLevel = DBS.compatibility_level
FROM sys.databases DBS
WHERE DBS.name = DB_NAME()
  AND DBS.is_read_only = 0;  -- prevent modifying readonly databases

-- check if need to switch compatibility level
IF (@CompatibilityLevel <> @NewCompatibilityLevel)
BEGIN
  -- info
  PRINT ('Info: Change compatibility level from "' + CONVERT(VARCHAR(5), @CompatibilityLevel) + '" to "' + CONVERT(VARCHAR(5), @NewCompatibilityLevel) + '" on database "' + @DBName + '"');
  
  -- set compatibility
  EXEC dbo.sp_dbcmptlevel @dbname = @DBName, @new_cmptlevel = @NewCompatibilityLevel;
END;
GO

PRINT ('Info: Handled compatibility level for current database');
GO


-------------------------------------------------------------------------------------------------
-- options
-------------------------------------------------------------------------------------------------
DECLARE @SqlStatement NVARCHAR(MAX);
DECLARE @DBName NVARCHAR(255);

SET @DBName = DB_NAME();

SET @SqlStatement = N'
-- automatic
ALTER DATABASE [' + @DBName + N'] SET AUTO_CLOSE OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_SHRINK OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS_ASYNC ON;
  
-- cursor
ALTER DATABASE [' + @DBName + N'] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [' + @DBName + N'] SET CURSOR_DEFAULT GLOBAL;

-- miscellaneous
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULLS ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_PADDING ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_WARNINGS ON;
ALTER DATABASE [' + @DBName + N'] SET ARITHABORT ON;
ALTER DATABASE [' + @DBName + N'] SET CONCAT_NULL_YIELDS_NULL ON;
ALTER DATABASE [' + @DBName + N'] SET DB_CHAINING OFF;
ALTER DATABASE [' + @DBName + N'] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [' + @DBName + N'] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [' + @DBName + N'] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [' + @DBName + N'] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [' + @DBName + N'] SET TRUSTWORTHY OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_date_correlation_on = 0))
BEGIN
  PRINT (''Info: DATE_CORRELATION_OPTIMIZATION is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;
  END;  
END;

-- recovery
ALTER DATABASE [' + @DBName + N'] SET PAGE_VERIFY CHECKSUM;

-------------------------------------------------------------------------------------------------
-- other advanced options
-------------------------------------------------------------------------------------------------
ALTER DATABASE [' + @DBName + N'] SET ALLOW_SNAPSHOT_ISOLATION OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_read_committed_snapshot_on = 0))
BEGIN
  PRINT (''Info: READ_COMMITTED_SNAPSHOT is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;
  END;  
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases DBS
           WHERE DBS.name = ''' + @DBName + N''' 
             AND DBS.is_broker_enabled = 1))
BEGIN
  -- info
  PRINT (''Info: Disable broker setting on database'');
  
  -- change broker settings
  ALTER DATABASE [' + @DBName + N'] SET DISABLE_BROKER;
END;

PRINT (''Info: Handled common settings for current database'');
';

-- execute it
EXEC (@SqlStatement)
GO

-------------------------------------------------------------------------------------------------
-- db files
-------------------------------------------------------------------------------------------------
-- setup vars
DECLARE @DBName NVARCHAR(255);
SET @DBName = DB_NAME();

DECLARE @SQLLogicalName NVARCHAR(1000);
DECLARE @SQLLogicalName_EXEC NVARCHAR(1000);

DECLARE @SQLDataSize NVARCHAR(1000);
DECLARE @SQLDataSize_EXEC NVARCHAR(1000);

DECLARE @SQLLogSize NVARCHAR(1000);
DECLARE @SQLLogSize_EXEC NVARCHAR(1000);

-- flag if size shall be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
DECLARE @ChangeSizes BIT;
SET @ChangeSizes = 0;

-- sql: change logical name
SET @SQLLogicalName = N'
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<CurrentLogicalName>'', NEWNAME = N''<NewLogicalName>'');
  
  PRINT (''Info: Rename executed'');';

-- sql: change autogrowth of data file (256MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLDataSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 262144KB);
  
  PRINT (''Info: Set data size executed'');
  
  USE [' + @DBName + N'];';

-- sql: change autogrowth of log file (32MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLLogSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 32768KB);
  
  PRINT (''Info: Set log size executed'');
  
  USE [' + @DBName + N'];';

-- get db-size
DECLARE @dbsize BIGINT;
DECLARE @logsize BIGINT;
DECLARE @DBWholeSize INT;

SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 = 0 THEN size
                                        ELSE 0
                                      END)),
       @logsize = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 <> 0 THEN size
                                        ELSE 0
                                      END))
FROM dbo.sysfiles;

-- get size in MB
SET @DBWholeSize = CONVERT(INT, CONVERT(MONEY, LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2))));

-- log
PRINT ('Info: Current db-size is "' + CONVERT(VARCHAR(50), @DBWholeSize) + 'MB"');

-- set if size needs to be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
-- Info: we change size if database size is 200MB...20GB or database customer is PI. 
--       in any other case, the customer's IT is responsible for the autogrowth behaviour on its own.
IF ((@DBWholeSize > 200 AND @DBWholeSize < 20480) OR ((';' + 'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + ';') LIKE '%;PI;%'))
BEGIN
  -- do change size
  SET @ChangeSizes = 1;
  PRINT ('Info: Autogrowth behaviour sizes will be changed for current database');
END
ELSE
BEGIN
  PRINT ('Info: No changes to autogrowth behaviour - database does not match size definitions or explicit namespace extensions');
END;

-----------------------------------------------------------------------------
-- loop all database files and set proper logical name of files
-- 
-- apply optionally autogrowth behaviour
-----------------------------------------------------------------------------
-- setup vars
DECLARE @NewLogicalName VARCHAR(255);
DECLARE @CurrentLogicalName VARCHAR(255);
DECLARE @FileType INT;

-- setup cursor
DECLARE curDBFiles CURSOR FAST_FORWARD FOR
  SELECT LogicalName = CASE
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%.mdf' THEN @DBName + '_Primary'
                         WHEN DBF.type = 1 AND DBF.physical_name LIKE '%.ldf' THEN @DBName + '_Log'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten1.ndf'  THEN @DBName + '_Daten1'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten2.ndf'  THEN @DBName + '_Daten2'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten3.ndf'  THEN @DBName + '_Daten3'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%System.ndf'  THEN @DBName + '_System'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%History.ndf'  THEN @DBName + '_History'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Logging.ndf'  THEN @DBName + '_Logging'
                         ELSE CASE
                                WHEN DBF.name LIKE (@DBName + '%') THEN DBF.name                    -- we leave it the way it was (specially for ZH, where we have multiple filegroups: for each year on doc-database)
                                ELSE @DBName + '_Data_' + CONVERT(VARCHAR(10), DBF.data_space_id)   -- we rename it depending on its id
                              END
                       END,
         CurrentName = DBF.name,
         FileType    = DBF.type
  FROM sys.database_files DBF;

-- iterate through cursor
OPEN curDBFiles;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT 
  FROM curDBFiles 
  INTO @NewLogicalName, @CurrentLogicalName, @FileType;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;
  
  -- check if localname should be changed
  IF (@NewLogicalName <> @CurrentLogicalName)
  BEGIN
    -- info
    PRINT ('Info: Rename logical name from "' + @CurrentLogicalName + '" to "' + @NewLogicalName + '"');
  
    -- setup sql-scripts
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName, '<CurrentLogicalName>', @CurrentLogicalName);
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName_EXEC, '<NewLogicalName>', @NewLogicalName);
    
    -- search in database
    EXEC sp_executesql @SQLLogicalName_EXEC;
  END
  ELSE
  BEGIN
    PRINT ('Info: Logical name is already correct "' + @CurrentLogicalName + '"');
  END;
  
  -- set autogrowth settings
  IF (@FileType = 0 AND @ChangeSizes = 1)
  BEGIN
    -- data file: 256MB unlimited, setup sql-scripts
    SET @SQLDataSize_EXEC = REPLACE(@SQLDataSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set data autogrowth behaviour for "' + @NewLogicalName + '" to "256MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLDataSize_EXEC;
  END
  ELSE IF (@FileType = 1 AND @ChangeSizes = 1)
  BEGIN
    -- log file: 32MB unlimited, setup sql-scripts
    SET @SQLLogSize_EXEC = REPLACE(@SQLLogSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set log autogrowth behaviour for "' + @NewLogicalName + '" to "32MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLLogSize_EXEC;
  END
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curDBFiles;
DEALLOCATE curDBFiles;
GO

PRINT ('Info: Handled file corrections for current database');
GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
PRINT ('');
GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix default language of server-user "kiss3" and "kiss_bm"
           to "us_english" to prevent language specific errors such as datetime-convert.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- switch to master database
-------------------------------------------------------------------------------
USE [master];
GO

-------------------------------------------------------------------------------
-- try to fix kiss user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'kiss3'))
BEGIN
  -- fix language
  ALTER LOGIN [kiss3] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "kiss3" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "kiss3" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- try to fix kiss_bm user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'kiss_bm'))
BEGIN
  -- fix language
  ALTER LOGIN [kiss_bm] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "kiss_bm" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "kiss_bm" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- switch back to origin database
-------------------------------------------------------------------------------

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_KissUsersDefaultLanguage.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select optional document database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939_DOC') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939_DOC'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
-- use document database (name must be given all the time, if no document database exists, use default database)
USE [KiSS_ZH_DEV_R4939_DOC];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_DocDatabase.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup empty extended properties (no content in value or '(null)')
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnName VARCHAR(255);
DECLARE @PropertyName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(255) NOT NULL,
  ColumnName VARCHAR(255),
  PropertyName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ColumnName, PropertyName)
  SELECT TableName     = OBJECT_NAME(EXT.major_id), 
         ColumnName    = COL.name,
         PropertyName  = EXT.name
  FROM sys.extended_properties EXT
    LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                  AND COL.column_id = EXT.minor_id
  WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
    AND EXT.name <> 'microsoft_database_tools_support'
    AND ISNULL(EXT.value, '') IN ('', '(null)')
  ORDER BY TableName, 
           ColumnName, 
           CASE 
             WHEN EXT.name = 'MS_Description' THEN 0 
             ELSE 1 
           END, 
           PropertyName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName    = TMP.TableName,
         @ColumnName   = TMP.ColumnName,
         @PropertyName = TMP.PropertyName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- drop extended property
  -----------------------------------------------------------------------------
  EXEC dbo.spXExtendedProperty @TableName, @ColumnName, @PropertyName, '_delete_', 0, 1;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_CleanUp_EmptyExtendedProperties.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix constrainst created WITH NOCHECK to WITH CHECK.
           Reason:
           Constraints defined WITH NOCHECK are not considered by the query optimizer. These 
           constraints are ignored until all such constraints are re-enabled.
           
           See: http://msdn.microsoft.com/en-us/library/aa275462(v=sql.80).aspx
           
           Hint: Use "DBCC CHECKCONSTRAINTS (table_name)" to validate only
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(1000);
DECLARE @ConstraintName VARCHAR(1000);
DECLARE @SQLStatement NVARCHAR(4000);
DECLARE @ErrorMessage VARCHAR(8000);
DECLARE @ErrorCount INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(1000) NOT NULL,
  ConstraintName VARCHAR(1000) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ConstraintName)
  SELECT TableName      = OBJECT_NAME(parent_object_id),
         ConstraintName = name
  FROM sys.foreign_keys
  WHERE is_not_trusted = 1
    AND is_disabled = 0
  ORDER BY TableName, ConstraintName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table
SET @ErrorCount = 0;

-- info
PRINT ('Info: Found "' + CONVERT(VARCHAR(50), @EntriesCount) + '" invalid constraints');

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName      = TMP.TableName,
         @ConstraintName = TMP.ConstraintName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- try to fix constraint
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to fix constraint here
    SET @SQLStatement = 'ALTER TABLE [dbo].[' + @TableName + '] WITH CHECK CHECK CONSTRAINT [' + @ConstraintName + '];';
    EXECUTE sp_executesql @SQLStatement;
    
    -- save
    COMMIT TRANSACTION;
    
    -- done
    PRINT ('Info: Successfully fixed table "' + @TableName + '" and constraint "' + @ConstraintName + '".');
  END TRY
  BEGIN CATCH
    -- undo
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = 'Warning: Could not fix table "' + @TableName + '" and constraint "' + @ConstraintName + '". Database error was: ' + ISNULL(ERROR_MESSAGE(), '<error?>');
    SET @ErrorCount = @ErrorCount + 1;

    -- show message and continue
    PRINT (@ErrorMessage);
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- info
PRINT ('Info: Having now "' + CONVERT(VARCHAR(50), @ErrorCount) + '" invalid constraints after fixing');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Fix_ConstraintsNewWITHCHECK.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to apply KiSS database default settings on every release.
           
           Excluded settings:
           - recovery model
           - database owner
           - autogrowth >> depending on current database size and name, see comment in code
           - TODO: what else??
           
           See: /Database/Scripts/Automation/ApplySettingsToDatabases.sql
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 6 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------------------------
-- compatibility level (first)
-------------------------------------------------------------------------------------------------
-- set and validate server version
DECLARE @SQLSERVER2005 INT;
DECLARE @SQLSERVER2008 INT;
DECLARE @SQLSERVER2012 INT;
DECLARE @SQLSERVER2014 INT;

SET @SQLSERVER2005 = 2005;
SET @SQLSERVER2008 = 2008;
SET @SQLSERVER2012 = 2012;
SET @SQLSERVER2014 = 2014;

DECLARE @ServerVersion INT;
DECLARE @NewCompatibilityLevel INT;

SET @ServerVersion = CASE
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2005%' THEN @SQLSERVER2005
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2008%' THEN @SQLSERVER2008
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2012%' THEN @SQLSERVER2012
                       WHEN @@VERSION LIKE '%Microsoft SQL Server 2014%' THEN @SQLSERVER2014
                       ELSE NULL
                     END;

SET @NewCompatibilityLevel = CASE @ServerVersion
                               WHEN @SQLSERVER2005 THEN 90
                               WHEN @SQLSERVER2008 THEN 100
                               WHEN @SQLSERVER2012 THEN 110
                               WHEN @SQLSERVER2014 THEN 120
                               ELSE NULL
                             END;

IF (@ServerVersion IS NULL OR @NewCompatibilityLevel IS NULL)
BEGIN
  -- do not continue
  RAISERROR ('Error: Current SQL-Server version is not supported: Version=(''%s'')!', 18, 1, @@Version);
  RETURN;
END;

-- setup vars
DECLARE @DBName NVARCHAR(255);
DECLARE @CompatibilityLevel INT;

SELECT @DBName = DBS.name, 
       @CompatibilityLevel = DBS.compatibility_level
FROM sys.databases DBS
WHERE DBS.name = DB_NAME()
  AND DBS.is_read_only = 0;  -- prevent modifying readonly databases

-- check if need to switch compatibility level
IF (@CompatibilityLevel <> @NewCompatibilityLevel)
BEGIN
  -- info
  PRINT ('Info: Change compatibility level from "' + CONVERT(VARCHAR(5), @CompatibilityLevel) + '" to "' + CONVERT(VARCHAR(5), @NewCompatibilityLevel) + '" on database "' + @DBName + '"');
  
  -- set compatibility
  EXEC dbo.sp_dbcmptlevel @dbname = @DBName, @new_cmptlevel = @NewCompatibilityLevel;
END;
GO

PRINT ('Info: Handled compatibility level for current database');
GO


-------------------------------------------------------------------------------------------------
-- options
-------------------------------------------------------------------------------------------------
DECLARE @SqlStatement NVARCHAR(MAX);
DECLARE @DBName NVARCHAR(255);

SET @DBName = DB_NAME();

SET @SqlStatement = N'
-- automatic
ALTER DATABASE [' + @DBName + N'] SET AUTO_CLOSE OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_SHRINK OFF;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE [' + @DBName + N'] SET AUTO_UPDATE_STATISTICS_ASYNC ON;
  
-- cursor
ALTER DATABASE [' + @DBName + N'] SET CURSOR_CLOSE_ON_COMMIT OFF;
ALTER DATABASE [' + @DBName + N'] SET CURSOR_DEFAULT GLOBAL;

-- miscellaneous
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULL_DEFAULT OFF;
ALTER DATABASE [' + @DBName + N'] SET ANSI_NULLS ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_PADDING ON;
ALTER DATABASE [' + @DBName + N'] SET ANSI_WARNINGS ON;
ALTER DATABASE [' + @DBName + N'] SET ARITHABORT ON;
ALTER DATABASE [' + @DBName + N'] SET CONCAT_NULL_YIELDS_NULL ON;
ALTER DATABASE [' + @DBName + N'] SET DB_CHAINING OFF;
ALTER DATABASE [' + @DBName + N'] SET NUMERIC_ROUNDABORT OFF;
ALTER DATABASE [' + @DBName + N'] SET PARAMETERIZATION SIMPLE;
ALTER DATABASE [' + @DBName + N'] SET QUOTED_IDENTIFIER OFF;
ALTER DATABASE [' + @DBName + N'] SET RECURSIVE_TRIGGERS OFF;
ALTER DATABASE [' + @DBName + N'] SET TRUSTWORTHY OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_date_correlation_on = 0))
BEGIN
  PRINT (''Info: DATE_CORRELATION_OPTIMIZATION is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET DATE_CORRELATION_OPTIMIZATION OFF;
  END;  
END;

-- recovery
ALTER DATABASE [' + @DBName + N'] SET PAGE_VERIFY CHECKSUM;

-------------------------------------------------------------------------------------------------
-- other advanced options
-------------------------------------------------------------------------------------------------
ALTER DATABASE [' + @DBName + N'] SET ALLOW_SNAPSHOT_ISOLATION OFF;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases
           WHERE name = ''' + @DBName + N'''
             AND is_read_committed_snapshot_on = 0))
BEGIN
  PRINT (''Info: READ_COMMITTED_SNAPSHOT is already disabled'');
END
ELSE
BEGIN
  IF ((SELECT COUNT(1)
       FROM sys.sysprocesses
       WHERE dbid = db_id(''' + @DBName + N''')) > 1)
  BEGIN
    PRINT (''Warning: too many connections to the DB. Please kill these connections and run the following statement: "ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;"'');
  END
  ELSE
  BEGIN
    ALTER DATABASE [' + @DBName + N'] SET READ_COMMITTED_SNAPSHOT OFF;
  END;  
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.databases DBS
           WHERE DBS.name = ''' + @DBName + N''' 
             AND DBS.is_broker_enabled = 1))
BEGIN
  -- info
  PRINT (''Info: Disable broker setting on database'');
  
  -- change broker settings
  ALTER DATABASE [' + @DBName + N'] SET DISABLE_BROKER;
END;

PRINT (''Info: Handled common settings for current database'');
';

-- execute it
EXEC (@SqlStatement)
GO

-------------------------------------------------------------------------------------------------
-- db files
-------------------------------------------------------------------------------------------------
-- setup vars
DECLARE @DBName NVARCHAR(255);
SET @DBName = DB_NAME();

DECLARE @SQLLogicalName NVARCHAR(1000);
DECLARE @SQLLogicalName_EXEC NVARCHAR(1000);

DECLARE @SQLDataSize NVARCHAR(1000);
DECLARE @SQLDataSize_EXEC NVARCHAR(1000);

DECLARE @SQLLogSize NVARCHAR(1000);
DECLARE @SQLLogSize_EXEC NVARCHAR(1000);

-- flag if size shall be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
DECLARE @ChangeSizes BIT;
SET @ChangeSizes = 0;

-- sql: change logical name
SET @SQLLogicalName = N'
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<CurrentLogicalName>'', NEWNAME = N''<NewLogicalName>'');
  
  PRINT (''Info: Rename executed'');';

-- sql: change autogrowth of data file (256MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLDataSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 262144KB);
  
  PRINT (''Info: Set data size executed'');
  
  USE [' + @DBName + N'];';

-- sql: change autogrowth of log file (32MB) > first set maxsize to prevent potential error with filegrowth>maxsize
SET @SQLLogSize = N'
  USE [master];
  
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', MAXSIZE = UNLIMITED);
  ALTER DATABASE [' + @DBName + N'] MODIFY FILE (NAME = N''<NewLogicalName>'', FILEGROWTH = 32768KB);
  
  PRINT (''Info: Set log size executed'');
  
  USE [' + @DBName + N'];';

-- get db-size
DECLARE @dbsize BIGINT;
DECLARE @logsize BIGINT;
DECLARE @DBWholeSize INT;

SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 = 0 THEN size
                                        ELSE 0
                                      END)),
       @logsize = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 <> 0 THEN size
                                        ELSE 0
                                      END))
FROM dbo.sysfiles;

-- get size in MB
SET @DBWholeSize = CONVERT(INT, CONVERT(MONEY, LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2))));

-- log
PRINT ('Info: Current db-size is "' + CONVERT(VARCHAR(50), @DBWholeSize) + 'MB"');

-- set if size needs to be changed (depending on current db-size and db-name, to prevent changing deliberate settings)
-- Info: we change size if database size is 200MB...20GB or database customer is PI. 
--       in any other case, the customer's IT is responsible for the autogrowth behaviour on its own.
IF ((@DBWholeSize > 200 AND @DBWholeSize < 20480) OR ((';' + 'RESTORE;OIZSERVER;SepDocDB;SRCPRODBAK;~PI;$ZH' + ';') LIKE '%;PI;%'))
BEGIN
  -- do change size
  SET @ChangeSizes = 1;
  PRINT ('Info: Autogrowth behaviour sizes will be changed for current database');
END
ELSE
BEGIN
  PRINT ('Info: No changes to autogrowth behaviour - database does not match size definitions or explicit namespace extensions');
END;

-----------------------------------------------------------------------------
-- loop all database files and set proper logical name of files
-- 
-- apply optionally autogrowth behaviour
-----------------------------------------------------------------------------
-- setup vars
DECLARE @NewLogicalName VARCHAR(255);
DECLARE @CurrentLogicalName VARCHAR(255);
DECLARE @FileType INT;

-- setup cursor
DECLARE curDBFiles CURSOR FAST_FORWARD FOR
  SELECT LogicalName = CASE
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%.mdf' THEN @DBName + '_Primary'
                         WHEN DBF.type = 1 AND DBF.physical_name LIKE '%.ldf' THEN @DBName + '_Log'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten1.ndf'  THEN @DBName + '_Daten1'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten2.ndf'  THEN @DBName + '_Daten2'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Daten3.ndf'  THEN @DBName + '_Daten3'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%System.ndf'  THEN @DBName + '_System'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%History.ndf'  THEN @DBName + '_History'
                         WHEN DBF.type = 0 AND DBF.physical_name LIKE '%Logging.ndf'  THEN @DBName + '_Logging'
                         ELSE CASE
                                WHEN DBF.name LIKE (@DBName + '%') THEN DBF.name                    -- we leave it the way it was (specially for ZH, where we have multiple filegroups: for each year on doc-database)
                                ELSE @DBName + '_Data_' + CONVERT(VARCHAR(10), DBF.data_space_id)   -- we rename it depending on its id
                              END
                       END,
         CurrentName = DBF.name,
         FileType    = DBF.type
  FROM sys.database_files DBF;

-- iterate through cursor
OPEN curDBFiles;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT 
  FROM curDBFiles 
  INTO @NewLogicalName, @CurrentLogicalName, @FileType;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;
  
  -- check if localname should be changed
  IF (@NewLogicalName <> @CurrentLogicalName)
  BEGIN
    -- info
    PRINT ('Info: Rename logical name from "' + @CurrentLogicalName + '" to "' + @NewLogicalName + '"');
  
    -- setup sql-scripts
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName, '<CurrentLogicalName>', @CurrentLogicalName);
    SET @SQLLogicalName_EXEC = REPLACE(@SQLLogicalName_EXEC, '<NewLogicalName>', @NewLogicalName);
    
    -- search in database
    EXEC sp_executesql @SQLLogicalName_EXEC;
  END
  ELSE
  BEGIN
    PRINT ('Info: Logical name is already correct "' + @CurrentLogicalName + '"');
  END;
  
  -- set autogrowth settings
  IF (@FileType = 0 AND @ChangeSizes = 1)
  BEGIN
    -- data file: 256MB unlimited, setup sql-scripts
    SET @SQLDataSize_EXEC = REPLACE(@SQLDataSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set data autogrowth behaviour for "' + @NewLogicalName + '" to "256MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLDataSize_EXEC;
  END
  ELSE IF (@FileType = 1 AND @ChangeSizes = 1)
  BEGIN
    -- log file: 32MB unlimited, setup sql-scripts
    SET @SQLLogSize_EXEC = REPLACE(@SQLLogSize, '<NewLogicalName>', @NewLogicalName);
    
    -- info 
    PRINT ('Info: Set log autogrowth behaviour for "' + @NewLogicalName + '" to "32MB unrestricted growth"');
    
    -- search in database
    EXEC sp_executesql @SQLLogSize_EXEC;
  END
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curDBFiles;
DEALLOCATE curDBFiles;
GO

PRINT ('Info: Handled file corrections for current database');
GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
PRINT ('');
GO 
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Apply_DatabaseSettings.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Create_KiSS_TeamUsers.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Create_KiSS_TeamUsers.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create new users for each member of GF SOZ.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO


/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */


-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT,
        @EntriesIterator INT;

DECLARE @FirstName VARCHAR(200),
        @LastName VARCHAR(200),
        @ShortName VARCHAR(10),
        @EMail VARCHAR(100),
        @LogonName VARCHAR(200),
        @UserID INT;

DECLARE @PasswordHash VARCHAR(200),
        @PermissionGroupID INT,
        @OrgUnitID INT,
        @UserGroupID INT,
        @UserGroupName VARCHAR(100),
        @CreatorModifier VARCHAR(50);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  FirstName VARCHAR(200),
  LastName VARCHAR(200),
  ShortName VARCHAR(10),
  EMail VARCHAR(100),
  LogonName VARCHAR(200),
  IsTeamleiter BIT,
  IsStellvertreter BIT
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (LastName, FirstName, ShortName, LogonName, EMail, IsTeamleiter, IsStellvertreter)
          SELECT 'Abegglen', 'Thomas', 'TAB', 'rcxp', 'thomas.abegglen@diartis.ch', 0, 0
UNION ALL SELECT 'Fuchs', 'Andreas', 'ANF', 'rcxo', 'andreas.fuchs@diartis.ch', 0, 0
UNION ALL SELECT 'Loreggia', 'Lucas', 'LUL', 'rcxs', 'lucas.loreggia@diartis.ch', 0, 0
UNION ALL SELECT 'Marino', 'Rahel', 'RAH', 'rcxj', 'rahel.marino@diartis.ch', 1, 0
UNION ALL SELECT 'Mathys', 'Wolfram', 'WMA', 'e247', 'wolfram.mathys@diartis.ch', 0, 1
UNION ALL SELECT 'Minder', 'Mathias', 'MMI', 'rcxr', 'mathias.minder@diartis.ch', 0, 0
UNION ALL SELECT 'Salajan', 'Peter', 'PSL', 'rbly', 'peter.salajan@diartis.ch', 0, 0
UNION ALL SELECT 'Stucki', 'Conny', 'COS', 'rb63', 'conny.stucki@diartis.ch', 0, 0
UNION ALL SELECT 'Weber', 'Nicolas', 'NWE', 'rcxv', 'nicolas.weber@diartis.ch', 0, 0
--UNION ALL SELECT '<LastName>', '<FirstName>', 'Shortname', '<LogonName>', '<Email>', <IsTeamleiter>, <IsStellvertreter>

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- determine common values: password, permissiongroupid, orgunit, ...
-------------------------------------------------------------------------------
SELECT @PasswordHash = '4P/dakfPi6MQqGVn7Tdelw==',
       @UserGroupName = 'KiSS kann alles',
       @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 

--Die Gruppe mit der höchsten Zus.Leistungs-Kompetenz ermitteln
SELECT TOP 1 @PermissionGroupID = PMV.PermissionGroupID
FROM dbo.XPermissionValue PMV WITH (READUNCOMMITTED)
WHERE PMV.BgPositionsartID IS NOT NULL
GROUP BY permissiongroupid
ORDER BY SUM(CONVERT(DECIMAL, value)) DESC

-------------------------------------------------------------------------------
-- Die oberste Abteilung (ParentID IS NULL) ermitteln
-------------------------------------------------------------------------------
SELECT @OrgUnitID = ORG.OrgUnitID
FROM dbo.XOrgUnit ORG
WHERE ORG.ParentID IS NULL;

-------------------------------------------------------------------------------
-- Benutzergruppe ermitteln oder ggf. erstellen
-------------------------------------------------------------------------------
SELECT @UserGroupID = UserGroupID FROM dbo.XUserGroup WHERE UserGroupName = @UserGroupName;

IF(@UserGroupID IS NULL)
BEGIN
    INSERT INTO [dbo].[XUserGroup]([UserGroupName],[OnlyAdminVisible],[Description],[Creator],[Created],[Modifier],[Modified])
    VALUES(@UserGroupName, 0 /*OnlyAdminVisible*/, 'Enthält alle Masken- und Spezialrechte', @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

    SET @UserGroupID = SCOPE_IDENTITY();
END;

-------------------------------------------------------------------------------
-- Sicherstellen dass alle Rechte darin enthalten sind
-------------------------------------------------------------------------------
INSERT INTO XUserGroup_Right (UserGroupID, RightID, XClassID, ClassName, QueryName, MaskName, MayInsert, MayUpdate, MayDelete)
SELECT TMP.UserGroupID, TMP.RightID, TMP.XClassID, TMP.ClassName, TMP.QueryName, TMP.MaskName, TMP.MayInsert, TMP.MayUpdate, TMP.MayDelete
FROM (--XRight
      SELECT UserGroupID = @UserGroupID,
             RightID = RGT.RightID,
             XClassID = RGT.XClassID,
             ClassName = RGT.ClassName,
             QueryName = NULL,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XRight RGT
      UNION ALL
      --XClass
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = CLS.XClassID,
             ClassName = CLS.ClassName,
             QueryName = NULL,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XClass CLS
      UNION ALL
      --XQuery
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = NULL,
             ClassName = NULL,
             QueryName = QRY.QueryName,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XQuery QRY
      WHERE QRY.ParentReportName IS NULL
      UNION ALL
      --DynaMask
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = NULL,
             ClassName = NULL,
             QueryName = NULL,
             MaskName = MSK.MaskName,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM DynaMask MSK
) TMP
WHERE NOT EXISTS (SELECT TOP 1 1 
                  FROM XUserGroup_Right UGR
                  WHERE UGR.UserGroupID = TMP.UserGroupID
                    AND ISNULL(UGR.RightID, -1) = ISNULL(TMP.RightID, -1)
                    AND ISNULL(UGR.XClassID, -1) = ISNULL(TMP.XClassID, -1)
                    AND ISNULL(UGR.QueryName, '') = ISNULL(TMP.QueryName, '')
                    AND ISNULL(UGR.MaskName, -1) = ISNULL(TMP.MaskName, -1))

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT  @FirstName = TMP.FirstName, 
          @LastName  = TMP.LastName, 
          @ShortName = TMP.ShortName, 
          @LogonName = TMP.LogonName, 
          @EMail     = TMP.Email
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- Create user if it doesn't exist yet
  -----------------------------------------------------------------------------
  IF(NOT EXISTS(SELECT TOP 1 1 FROM dbo.XUser WHERE LogonName = @LogonName))
  BEGIN
    INSERT INTO dbo.HistoryVersion(AppUser)
    VALUES  (@CreatorModifier);
    
    INSERT INTO [dbo].[XUser]([FirstName],[LastName],[ShortName],[EMail],[LogonName],[PasswordHash],[IsUserAdmin],[PermissionGroupID],[GrantPermGroupID],[Creator],[Created],[Modifier],[Modified])
    VALUES(@FirstName, @LastName, @ShortName, @EMail, @LogonName, @PasswordHash, 0 /*IsUserAdmin*/, @PermissionGroupID, @PermissionGroupID, @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

    SET @UserID = SCOPE_IDENTITY();

    --Benutzer zu Abteilung hinzufügen
    INSERT INTO [dbo].[XOrgUnit_User]([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete])
    VALUES  (@OrgUnitID, 
             @UserID, 
             2 /*2: Mitglied */,
             1, /* MayInsert */
             1, /* MayUpdate */
             1 /* MayDelete */
             )

    --Benutzer zu Benutzergruppe hinzufügen
    INSERT INTO [dbo].[XUser_UserGroup]([UserID], [UserGroupID])
    VALUES  (@UserID, 
             @UserGroupID
             )

    PRINT('XUser mit LogonName: ' + @LogonName + ' erstellt.');
  END
  ELSE
  BEGIN
    PRINT('XUser mit LogonName: ' + @LogonName + ' existiert bereits.');
  END
  -----------------------------------------------------------------------------

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

INSERT INTO dbo.HistoryVersion(AppUser)
VALUES  (@CreatorModifier);

--Sicherstellen, dass Abteilung nicht von einem inaktiven Benutzer geleitet wird
UPDATE ORG SET ORG.ChiefID = USR.UserID
FROM XOrgUnit ORG
  INNER JOIN XOrgUnit_User OUU ON OUU.OrgUnitID = ORG.OrgUnitID
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
  INNER JOIN @TempTable TMP ON TMP.LogonName = USR.LogonName
WHERE ORG.OrgUnitID = @OrgUnitID
  AND TMP.IsTeamleiter = 1;

--Sicherstellen, dass Abteilung nicht einen inaktiven Stellvertreter hat
UPDATE ORG SET ORG.RepresentativeID = USR.UserID
FROM XOrgUnit ORG
  INNER JOIN XOrgUnit_User OUU ON OUU.OrgUnitID = ORG.OrgUnitID
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
  INNER JOIN @TempTable TMP ON TMP.LogonName = USR.LogonName
WHERE ORG.OrgUnitID = @OrgUnitID
  AND TMP.IsStellvertreter = 1;

--Sicherstellen, dass Benutzer diag_admin Mitglied in gleicher Abteilung ist
--a) Bisherige Mitgliedschaft + allfällige Gastmitgliedschaft in Abteilung löschen
DELETE OUU 
FROM XOrgUnit_User OUU 
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
WHERE USR.LogonName = 'diag_admin'
  AND (OUU.OrgUnitMemberCode = 2 --2: Mitglied
       OR OUU.OrgUnitID = @OrgUnitID);

INSERT INTO [dbo].[XOrgUnit_User](OrgUnitID, UserID, OrgUnitMemberCode, MayInsert, MayUpdate, MayDelete)
SELECT @OrgUnitID, USR.UserID, 2 /*OrgUnitMemberCode*/, 1 /*MayInsert*/, 1 /*MayUpdate*/, 1 /*MayDelete*/
FROM XUser USR
WHERE USR.LogonName = 'diag_admin';

SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Create_KiSS_TeamUsers.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Create_KiSS_TeamUsers.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to perform security check after installing release script.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check 1: validate doc-db-name in view XDocument (if existing)
-------------------------------------------------------------------------------
-- check if table exists > in this case, we do not need to validate view
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables TBL
            WHERE TBL.name = 'XDocument'))
BEGIN
  -- info
  PRINT ('Security-Info: Table "dbo.XDocument" exists, we do not need to validate view content.');
END
ELSE
BEGIN
  -- init vars
  DECLARE @ErrorMessage VARCHAR(2000);
  DECLARE @XDocumentViewSQLCode VARCHAR(MAX);
  DECLARE @DocDBName VARCHAR(255);
  
  SET @ErrorMessage = NULL;
  SET @XDocumentViewSQLCode = NULL;
  SET @DocDBName = 'KiSS_ZH_DEV_R4939_DOC';
  
  -- get script content for view
  SELECT @XDocumentViewSQLCode = OBJECT_DEFINITION(VIE.object_id)
  FROM sys.views VIE
  WHERE OBJECT_NAME(VIE.object_id) = 'XDocument';
  
  -- validate sql-definition
  IF (@XDocumentViewSQLCode IS NULL)
  BEGIN
    -- invalid program code, missing view definition
    SET @ErrorMessage = 'Expected view "dbo.XDocument" is either missing or has no definition code.';
  END;
  -- validate sql-code for proper database name (code must match with view definition)
  ELSE IF (@XDocumentViewSQLCode NOT LIKE ('%FROM ' + @DocDBName + '.dbo.XDocument%'))
  BEGIN
    -- invalid program code, invalid view definition
    SET @ErrorMessage = 'View "dbo.XDocument" contains invalid DocDBName. Expected value is "' + @DocDBName + '".';
  END;
  
  -- check error message
  IF (@ErrorMessage IS NOT NULL)
  BEGIN
    -- setup error message
    SET @ErrorMessage = 'Security-Error: ' + @ErrorMessage;
    
    -- show error message
    RAISERROR (@ErrorMessage, 18, 1);
    RETURN;
  END
  ELSE
  BEGIN
    -- info
    PRINT ('Security-Info: View "dbo.XDocument" exists and contains expected DocDBName "' + @DocDBName + '".');
  END;
END;
GO

-------------------------------------------------------------------------------
-- check 2: Validate spXDocument_Lock, spXDocument_UnLock
-------------------------------------------------------------------------------
-- TODO...
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_SecurityChecks.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_ZH_SecurityChecks.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_ZH_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to perform security check after installing release script.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check 1: check that current identity for BaPerson ist < 500'000
-------------------------------------------------------------------------------
DECLARE @NextBaPersonID INT;
DECLARE @ErrorMessage VARCHAR(MAX);

SET @NextBaPersonID = IDENT_CURRENT('BaPerson');
IF (@NextBaPersonID >= 499000)
BEGIN
  -- setup error message
  SET @ErrorMessage = 'Security-Error: PSCD akzeptiert nur Personen mit ID < 500''000, die nächste Person erhält ID ' + CONVERT(VARCHAR,@NextBaPersonID);
  
  -- show error message
  RAISERROR (@ErrorMessage, 18, 1);
END

GO

-------------------------------------------------------------------------------
-- check 2: validate VIS-server-name and VIS-db-name in VIS-views
--           - vwVIS_DOSSIER
--           - vwVIS_MANDATSTRAEGER
--           - vwVIS_MASSNAHMEN
--           - vwVIS_MASSNAHMEN_HIST
--           - vwVIS_ABTEILUNG
--           - vwVIS_BERICHT
--           - vwVIS_OPERATION
-------------------------------------------------------------------------------
-- init vars
DECLARE @ErrorMessage VARCHAR(2000);
DECLARE @VisViewSqlCode VARCHAR(MAX);
DECLARE @VisServerName VARCHAR(255);
DECLARE @VisDBName VARCHAR(255);
  
SET @VisServerName = 'SZHM24946\SOZ_KISS_D';
SET @VisDBName = 'KiSS_ZH_VIS_Test';
  
-----------------------------------
-- init vars and table
-----------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @ViewName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  ViewName VARCHAR(255)
);

-----------------------------------
-- insert entries into temp table
-----------------------------------
INSERT INTO @TempTable (ViewName)
  SELECT 'vwVIS_DOSSIER' UNION ALL
  SELECT 'vwVIS_MANDATSTRAEGER' UNION ALL
  SELECT 'vwVIS_MANDATSTRAEGER_SIMPLE' UNION ALL
  SELECT 'vwVIS_MASSNAHMEN' UNION ALL
  SELECT 'vwVIS_MASSNAHMEN_HIST' UNION ALL
  SELECT 'vwVIS_ABTEILUNG' UNION ALL
  SELECT 'vwVIS_BERICHT' UNION ALL
  SELECT 'vwVIS_OPERATION'

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-----------------------------------
-- loop all entries
-----------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ViewName = TMP.ViewName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  SET @ErrorMessage = NULL;
  SET @VisViewSqlCode = NULL;

  -----------------------------------
    -- get script content for view
  -----------------------------------
  SELECT @VisViewSqlCode = OBJECT_DEFINITION(VIE.object_id)
  FROM sys.views VIE
  WHERE OBJECT_NAME(VIE.object_id) = @ViewName;
    
  -----------------------------------
    -- validate sql-definition
  -----------------------------------
  IF (@VisViewSqlCode IS NULL)
  BEGIN
    -- invalid program code, missing view definition
    SET @ErrorMessage = 'Expected view "dbo.' + @ViewName + '" is either missing or has no definition code.';
  END;
  -- validate sql-code for proper database name (code must match with view definition)
  ELSE IF (@VisViewSqlCode NOT LIKE '%' + @VisServerName + '%' OR @VisViewSqlCode NOT LIKE  + '%' + @VisDBName + '%')
  BEGIN
    -- invalid program code, invalid view definition
    SET @ErrorMessage = 'View "dbo.' + @ViewName + '" contains invalid VisServerName or VisDBName. Expected values are "' + @VisServerName + '", "' + @VisDBName + '".';
  END;
    
  -----------------------------------
    -- check error message
  -----------------------------------
  IF (@ErrorMessage IS NOT NULL)
  BEGIN
    -- setup error message
    SET @ErrorMessage = 'Security-Error: ' + @ErrorMessage;
      
    -- show error message
    RAISERROR (@ErrorMessage, 18, 1);
  END
  ELSE
  BEGIN
    -- info
    PRINT ('Security-Info: View "dbo.' + @ViewName + '" exists and contains expected VisServerName "' + @VisServerName + '" and VisDBName "' + @VisDBName + '".');
  END;
  -----------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_ZH_SecurityChecks.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_ZH_SecurityChecks.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Update_XConfig_Omega.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Update_XConfig_Omega.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  SUMMARY: Use this script to update config values for DEV databases.
=================================================================================================*/

SET NOCOUNT ON;
GO

UPDATE dbo.XConfig
SET ValueBit = 0
WHERE KeyPath = 'System\Schnittstellen\Omega\DeleteEventFiles';

UPDATE dbo.XConfig
SET ValueVarchar = 'ftp://sapdrehscheibe-dev.stzh.ch/eCH0020_V2.3/O212_S02_Ereignisse/SAPOUT/'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpUrl';

UPDATE dbo.XConfig
SET ValueVarchar = 'kiss_sstxi7'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpUser';

UPDATE dbo.XConfig
SET ValueVarchar = 'KISSeCH14'
WHERE KeyPath = 'System\Schnittstellen\Omega\FtpPassword';

UPDATE dbo.XConfig
SET ValueVarchar = 'http://localhost:8090/KissEinwohnerregisterService.svc'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\KissWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O101_S01e_PAnfrage:CC_O101_S01e_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O101_S01e_PAnfrage&amp;Interface=http%3A%2F%2Fstzh.ch%2FO101%2FeCH-0020%2F2.3%5ESI_O101_L_Anfrage_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\AnfrageWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O102_S07_PSuche:CC_O102_S07_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O102_S07_PSuche&amp;Interface=http%3A%2F%2Fstzh.ch%2FO102%2FeCH-0020%2F2.3%5ESI_O102_Suche_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\SucheWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O13_S03_Regist:CC_O13_S03_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O13_S03_Regist&amp;Interface=http%3A%2F%2Fstzh.ch%2FO13%2FeCH-0020%2F2.3%5ESI_O13_Regist_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\RegistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O13_S03_Regist:CC_O13_S03b_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O13_S03_Regist&amp;Interface=http%3A%2F%2Fstzh.ch%2FO13%2FeCH-0020%2F2.3%5ESI_O13_deRegist_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\DeRegistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'https://szhm2404.stzh.ch:443/XISOAPAdapter/MessageServlet?channel=KISS:BC_O103_S05_Person_Adr:CC_O103_S05b_WS_OUT&amp;version=3.0&amp;Sender.Party=http%3A%2F%2Fsap.com%2Fxi%2FXI%3AXIParty%3AKISS&amp;Sender.Service=BC_O103_S05_Person_Adr&amp;Interface=http%3A%2F%2Fstzh.ch%2FO103%2FeCH-0020%2F2.3%5ESI_O103_histAdr_sync_ob'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\AdresseHistWebserviceURL'

UPDATE dbo.XConfig
SET ValueVarchar = 'S_SD_KISS_I_AA'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesUsername'

UPDATE dbo.XConfig
SET ValueVarchar = 'KISS_if_14i'
WHERE KeyPath = 'System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesPassword'

SET NOCOUNT OFF;
GO

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Update_XConfig_Omega.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\ZH\Rxxxx_Update_XConfig_Omega.sql' -------- */

/* -------- INFO: Start of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */
PRINT ('=== start of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select proper database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('KiSS_ZH_DEV_R4939') IS NULL)
BEGIN
  RAISERROR('The Database ''KiSS_ZH_DEV_R4939'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
USE [KiSS_ZH_DEV_R4939];
GO
GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_Use_Database.sql' -------- */

GO
PRINT ('=== end of file [E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql]: ' + CONVERT(VARCHAR, GETDATE(), 113) + ' ===')
GO
/* -------- INFO: End of file 'E:\dtvs0034\kiss4_agent1\_work\24\s\_Releases\Recurring\ChangeScripts\Rxxxx_2_PostReleaseDispatcher.sql' -------- */


/*
************************************************************
  PROCESSED 134 FILES IN 00:00:09.1887956
************************************************************
*/
PRINT ('
************************************************************
');
PRINT ('  Info: End of script: [' + CONVERT(VARCHAR, GETDATE(), 113) + ']');
PRINT ('
************************************************************
');
