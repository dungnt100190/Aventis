USE [master]
GO

-- Set single user mode to close all open connections
IF (EXISTS (SELECT TOP 1 1 FROM sys.databases WITH (READUNCOMMITTED) WHERE name = N'{DBName}')) BEGIN
  ALTER DATABASE [{DBName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END;
GO

DECLARE @DBName       NVARCHAR(100),
        @BackupFile   NVARCHAR(500),
        @PrefFileName NVARCHAR(500),
        @DBPath       NVARCHAR(500),
        @IsDoc        BIT,
        @NL           NVARCHAR(2);

SET @NL = CHAR(13) + CHAR(10); -- New line

-------------------------------------------------------------------------------
--- Settings ------------------------------------------------------------------
-------------------------------------------------------------------------------
SET @DBName     = N'{DBName}';
SET @BackupFile = N'';
SET @IsDoc      = 0;
SET @DBPath     = N'{DBRootDirectory}\{DBName}';
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------

SET NOCOUNT ON

-- drop temp tables
IF (EXISTS(SELECT TOP 1 1 FROM tempdb.sys.tables WITH (READUNCOMMITTED) WHERE name LIKE '#DBFiles%')) BEGIN
  DROP TABLE #DBFiles;
END;
IF (EXISTS(SELECT TOP 1 1 FROM tempdb.sys.tables WITH (READUNCOMMITTED) WHERE name LIKE '#BackupHeaderOnly%')) BEGIN
  DROP TABLE #BackupHeaderOnly;
END;
IF (EXISTS(SELECT TOP 1 1 FROM tempdb.sys.tables WITH (READUNCOMMITTED) WHERE name LIKE '#BackupFileListOnly%')) BEGIN
  DROP TABLE #BackupFileListOnly;
END;

DECLARE @sql           NVARCHAR(4000);

DECLARE @OldDBName     NVARCHAR(100),
        @FileGroup     NVARCHAR(1000),
        @FileNr        NVARCHAR(10),
        @MaxFileNr     NVARCHAR(10);

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

IF (@@VERSION LIKE '%Microsoft SQL Server 2005%') BEGIN
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
END;

IF (@@VERSION LIKE '%Microsoft SQL Server 2008%') BEGIN
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
END;


CREATE TABLE #BackupFileListOnly (
  [LogicalName]   NVARCHAR(128),
  [PhysicalName]  NVARCHAR(260),
  [Type]          CHAR(1),
  [FileGroupName] NVARCHAR(128),
  [Size]          NUMERIC(20,0),
  [MaxSize]       NUMERIC(20,0)
);

IF (@@VERSION LIKE '%Microsoft SQL Server 2005%') BEGIN
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

IF (@@VERSION LIKE '%Microsoft SQL Server 2008%') BEGIN
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
IF (@DBName = '') BEGIN
  SET @DBName = SUBSTRING(@BackupFile, LEN(@BackupFile) + 2 - CHARINDEX('\', REVERSE(@BackupFile), 1), 1000);
  SET @DBName = SUBSTRING(@DBName, 1, LEN(@DBName) - CHARINDEX('.', REVERSE(@DBName), 1));
END;


-- Get DB path
IF (ISNULL(@DBPath, '') = '') BEGIN
  IF (EXISTS (SELECT name FROM sysdatabases WITH (READUNCOMMITTED) WHERE name = @DBName)) BEGIN
    -- if the DB already exists, set the db path to it's data folder
    SET @sql = N'
      USE [' + @DBName + ']
      EXEC sp_helpfile';
    INSERT INTO #DBFiles
      EXECUTE sp_executesql @sql;

    SELECT @DBPath = MAX(RTRIM(FileName)) FROM #DBFiles WHERE Usage = 'data only' AND FileGroup = 'PRIMARY';
  END
  ELSE BEGIN
    -- set the db path to the master database's data folder
    SET @sql = N'
      USE [master]
      EXEC sp_helpfile';
    INSERT INTO #DBFiles
      EXECUTE sp_executesql @sql;

    SELECT @DBPath = MAX(RTRIM(FileName)) FROM #DBFiles WHERE Usage = 'data only' AND FileGroup = 'PRIMARY';
  END;

  SET @DBPath = SUBSTRING(@DBPath, 1, LEN(@DBPath) + 1 - CHARINDEX('\', REVERSE(@DBPath), 1));
END;

DROP TABLE #DBFiles;

-- add backslash if missing
IF (SUBSTRING(@DBPath, LEN(@DBPath), 1) <> '\') BEGIN
  SET @DBPath = @DBPath + '\';
END;

-- set file name prefix (path & db name)
SET @PrefFileName = @DBPath + @DBName + '_';


-- Read Backupset
SET @sql = N'
RESTORE HEADERONLY
  FROM DISK = ''' + @BackupFile + N'''';
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

SET @sql = N'
RESTORE FILELISTONLY
  FROM DISK = ''' + @BackupFile + N'''
  WITH FILE = ' + @FileNr;
INSERT INTO #BackupFileListOnly
  EXECUTE sp_executesql @sql;

SET @sql = '';
DECLARE cFileList CURSOR FAST_FORWARD FOR
  SELECT N'  MOVE ''' + [LogicalName] + N''' TO ''' + @PrefFileName +
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


-- Restore Database
SET @sql = N'
RESTORE DATABASE [' + @DBName + ']
  FROM DISK = ''' + @BackupFile + N'''
  WITH FILE = ' + @FileNr + N', ' + @sql + N'
  '
IF (@MaxFileNr IS NULL) BEGIN
  SET @sql = @sql + N'REPLACE'
END
ELSE BEGIN
  SET @sql = @sql + N'NOUNLOAD, NORECOVERY, REPLACE'
END
PRINT @sql
EXECUTE sp_executesql @sql


-- Restore Transaction Log
DECLARE cur_LogBackup CURSOR FOR
  SELECT Position
  FROM #BackupHeaderOnly
  WHERE BackupType = 2 AND Position > @FileNr
  ORDER BY Position

OPEN cur_LogBackup

FETCH NEXT FROM cur_LogBackup
  INTO @FileNr

WHILE @@FETCH_STATUS = 0
BEGIN
  SET @sql = N'
    RESTORE LOG [' + @DBName + ']
      FROM DISK = ''' + @BackupFile + N'''
      WITH FILE = ' + @FileNr + N',
      ';

  IF (@MaxFileNr = @FileNr) BEGIN
    SET @sql = @sql + N'RECOVERY'
  END
  ELSE BEGIN
    SET @sql = @sql + N'NOUNLOAD, NORECOVERY'
  END;

  PRINT @sql;
  EXECUTE sp_executesql @sql;

  -- Get the next author.
  FETCH NEXT FROM cur_LogBackup
    INTO @FileNr;
END;

CLOSE cur_LogBackup;
DEALLOCATE cur_LogBackup;

DROP TABLE #BackupHeaderOnly;


-- Resync SQL Logins
SET @sql = N'
DECLARE cSQL CURSOR FAST_FORWARD FOR
  SELECT N''USE [' + @DBName + ']'' + CHAR(13) + CHAR(10) +
         N''EXEC sp_change_users_login ''''Auto_Fix'''', '''''' + name + ''''''''
  FROM [' + @DBName + ']..sysusers USR WITH (READUNCOMMITTED)
  WHERE EXISTS (SELECT TOP 1 1 FROM master..syslogins WITH (READUNCOMMITTED) WHERE name COLLATE DATABASE_DEFAULT = USR.name COLLATE DATABASE_DEFAULT)'
EXECUTE (@sql)

OPEN cSQL
WHILE 1 = 1 BEGIN
  FETCH NEXT FROM cSQL INTO @sql
  IF (@@FETCH_STATUS != 0) BREAK

  EXECUTE sp_executesql @sql
END
CLOSE cSQL
DEALLOCATE cSQL

-- add missing file groups for main db
IF (@IsDoc = 0) BEGIN
  SET @sql = '';
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN1')) BEGIN
    SET @sql = N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN1]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten1'', FILENAME = N''' + @PrefFileName + N'Daten1.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN1]';
  END;

  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN2')) BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN2]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten2'', FILENAME = N''' + @PrefFileName + N'Daten2.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN2]';
  END;

  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN3')) BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN3]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten3'', FILENAME = N''' + @PrefFileName + N'Daten3.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN3]';
  END;

  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'SYSTEM')) BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [SYSTEM]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_System'', FILENAME = N''' + @PrefFileName + N'System.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [SYSTEM]';
  END;

  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'LOGGING')) BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [LOGGING]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Logging'', FILENAME = N''' + @PrefFileName + N'Logging.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [LOGGING]';
  END;

  IF (@sql <> '') BEGIN
    PRINT @sql;
    EXECUTE sp_executesql @sql;
  END;
END;

DROP TABLE #BackupFileListOnly;
GO


-- set to multi-user 
ALTER DATABASE [{DBName}] SET MULTI_USER WITH NO_WAIT;
GO

USE [{DBName}]
GO
