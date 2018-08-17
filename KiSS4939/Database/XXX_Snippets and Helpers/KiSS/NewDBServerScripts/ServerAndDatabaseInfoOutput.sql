/*===============================================================================================
  $Archive: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/ServerAndDatabaseInfoOutput.sql $
  $Author: Cjaeggi $
  $Modtime: 26.08.10 9:40 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to print some general server and database information
=================================================================================================
  $Log: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/ServerAndDatabaseInfoOutput.sql $
 * 
 * 1     26.08.10 9:43 Cjaeggi
 * Added server/datbase information and fixed scripts
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @ServerInformation TABLE
(
  ID INT,
  Name SYSNAME,
  Internal_Value INT,
  Value NVARCHAR(512)
);

DECLARE @SmoRoot NVARCHAR(512);
DECLARE @pages BIGINT;      -- Working variable for size calc.
DECLARE @dbsize BIGINT;
DECLARE @logsize BIGINT;
DECLARE @reservedpages BIGINT;
DECLARE @usedpages BIGINT;

DECLARE @TargetCollation VARCHAR(200);
DECLARE @ServerCollation VARCHAR(200);
DECLARE @DatabaseCollation VARCHAR(200);

-- init vars and table for output
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @ColumnName VARCHAR(255);
DECLARE @SQLStatement VARCHAR(MAX);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  ColumnName VARCHAR(255)
);

SET @TargetCollation = 'Latin1_General_CI_AS';

-------------------------------------------------------------------------------
-- set vars with information from server
-------------------------------------------------------------------------------
-- get server information
INSERT @ServerInformation EXEC master.dbo.xp_msver;

EXEC master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'SOFTWARE\Microsoft\MSSQLServer\Setup', N'SQLPath', @SmoRoot OUTPUT;

-- get database size information
SELECT @dbsize  = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 = 0 THEN size
                                        ELSE 0
                                      END)),
       @logsize = SUM(CONVERT(BIGINT, CASE
                                        WHEN status & 64 <> 0 THEN size
                                        ELSE 0
                                      END))
FROM dbo.sysfiles;

SELECT @reservedpages = SUM(A.total_pages),
       @usedpages     = SUM(A.used_pages),
       @pages         = SUM(CASE -- XML-Index and FT-Index-Docid is not considered 'data', but is part of 'index_size'
                              WHEN IT.internal_type IN (202, 204) THEN 0
                              WHEN A.type <> 1 THEN A.used_pages
                              WHEN P.index_id < 2 THEN a.data_pages
                              ELSE 0
                            END)
FROM sys.partitions              P
       JOIN sys.allocation_units A  ON P.partition_id = A.container_id
  LEFT JOIN sys.internal_tables  IT ON P.OBJECT_ID = IT.OBJECT_ID;

-- show output
SELECT -- server
       ServerName             = CAST(SERVERPROPERTY(N'Servername') AS SYSNAME),
       ServerProduct          = (SELECT [Value]
                                 FROM @ServerInformation
                                 WHERE [Name] = N'ProductName'),
       ServerOperatingSystem  = RIGHT(@@VERSION, LEN(@@VERSION) - 3 - CHARINDEX(' ON ', @@VERSION)),
       ServerPlatform         = (SELECT [Value]
                                 FROM @ServerInformation
                                 WHERE [Name] = N'Platform'),
       ServerEdition          = SERVERPROPERTY (N'Edition'),
       ServerVersion          = SERVERPROPERTY(N'ProductVersion'),
       ServerProductLevel     = SERVERPROPERTY(N'ProductLevel'),
       ServerLanguage         = (SELECT [Value]
                                 FROM @ServerInformation
                                 WHERE [Name] = N'Language'),
       ServerMemory           = (SELECT CONVERT(VARCHAR(50), [Internal_Value])  + ' (MB)'
                                 FROM @ServerInformation
                                 WHERE [Name] = N'PhysicalMemory'),
       ServerProcessors       = (SELECT [Internal_Value]
                                 FROM @ServerInformation
                                 WHERE [Name] = N'ProcessorCount'),
       ServerRootDirectory    = @SmoRoot,
       ServerCollation        = CONVERT(SYSNAME, SERVERPROPERTY(N'Collation')),
       ServerIsClustered      = CAST(SERVERPROPERTY('IsClustered') AS BIT),

       -- database
       DatabaseName           = DTB.name,
       DatabaseCollation      = DTB.collation_name,
       DatabaseRecoveryModel  = DTB.recovery_model_desc,
       DatabasseCompatibility = DTB.compatibility_level,
       DatabasePageVerify     = DTB.page_verify_option_desc,
       DatabaseReadOnly       = DTB.is_read_only,
       DatabaseRestrictAccess = DTB.user_access_desc,
       --
       DatabaseDateCreated    = DTB.create_date,
       DatabaseLastBackup     = (SELECT MAX(backup_finish_date)
                                 FROM msdb..backupset
                                 WHERE TYPE = 'D'
                                   AND database_name = DTB.name),
       DatabaseLastLogBackup  = (SELECT MAX(backup_finish_date)
                                 FROM msdb..backupset
                                 WHERE TYPE = 'L'
                                   AND database_name = DTB.name),
       DatabaseOwner          = SUSER_SNAME(DTB.owner_sid),
       DatabaseStatus         = DTB.state_desc,
       DatabaseNumberOfUsers  = (SELECT COUNT(1)
                                 FROM sys.database_principals U
                                 WHERE (U.type IN ('U', 'S', 'G', 'C', 'K'))),
       DatabaseActiveConn     = (SELECT COUNT(1)
                                 FROM master.dbo.sysprocesses p
                                 WHERE DTB.database_id = P.dbid),
       DatabaseSize           = LTRIM(STR((CONVERT (DEC(15, 2), @dbsize) + CONVERT (DEC(15, 2), @logsize)) * 8192 / 1048576, 15, 2) + ' MB'),
       DatabaseSpaceAvailable = LTRIM(STR((CASE
                                             WHEN @dbsize >= @reservedpages
                                               THEN (CONVERT(DEC(15, 2), @dbsize) - CONVERT(DEC(15, 2), @reservedpages)) * 8192 / 1048576
                                             ELSE 0
                                           END), 15, 2) + ' MB'),
       DatabasePrimaryFile    = DF.physical_name
INTO __TMP__TableToOutput__
FROM master.sys.databases                AS DTB
  LEFT JOIN sys.master_files             AS DF  ON df.database_id = dtb.database_id
                                               and 1 = df.data_space_id
                                               and 1 = df.file_id
  LEFT JOIN sys.database_recovery_status AS DRS ON DRS.database_id = DTB.database_id
  LEFT JOIN sys.database_mirroring       AS DMI ON DMI.database_id = DTB.database_id
  --LEFT JOIN #tmp_sp_db_vardecimal_storage_format as vardec ON dtb.name = vardec.dbname
WHERE DTB.name = DB_NAME();

-------------------------------------------------------------------------------
-- do output
-------------------------------------------------------------------------------
PRINT ('');
PRINT ('---- SERVER AND DATABASE INFORMATION ----');

-- insert entries into temp table
INSERT INTO @TempTable (ColumnName)
  SELECT COL.name
  FROM sys.columns COL
  WHERE OBJECT_NAME(COL.object_id) = '__TMP__TableToOutput__'
  ORDER BY COL.column_id;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ColumnName = TMP.ColumnName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- get data for current column (we show only first row)
  -----------------------------------------------------------------------------
  SET @SQLStatement = 'DECLARE @OutputValue VARCHAR(500);
  
                       SELECT TOP 1 
                       @OutputValue = REPLACE(REPLACE(CONVERT(VARCHAR(500), TBL.' + @ColumnName + '), CHAR(13), ''''), CHAR(10), '''')
                       FROM dbo.__TMP__TableToOutput__ TBL;
                       
                       PRINT (''Info: ' + ISNULL(@ColumnName, '??') + ' = "'' + ISNULL(@OutputValue, '''') + ''"'');'
  
  --PRINT (@SQLStatement);
  EXEC (@SQLStatement);
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- get values for collation
SELECT TOP 1
       @ServerCollation = TMP.ServerCollation,
       @DatabaseCollation = TMP.DatabaseCollation
FROM __TMP__TableToOutput__ TMP;

-- validate collations
PRINT ('');
PRINT ('---- COLLATION VALIDATION ----');

IF (ISNULL(@ServerCollation, '?') <> ISNULL(@TargetCollation, '??'))
BEGIN
  PRINT ('Warning: ServerCollation "' + ISNULL(@ServerCollation, '?') + '" is not matching with KiSS-DefaultCollation "' + ISNULL(@TargetCollation, '??') + '"!');
END
ELSE
BEGIN
  PRINT ('Info: ServerCollation is ok.');
END;

IF (ISNULL(@DatabaseCollation, '?') <> ISNULL(@TargetCollation, '??'))
BEGIN
  PRINT ('Warning: DatabaseCollation "' + ISNULL(@DatabaseCollation, '?') + '" is not matching with KiSS-DefaultCollation "' + ISNULL(@TargetCollation, '??') + '"!');
END
ELSE
BEGIN
  PRINT ('Info: DatabaseCollation is ok.');
END;

IF (ISNULL(@ServerCollation, '?') <> ISNULL(@DatabaseCollation, '??'))
BEGIN
  PRINT ('Warning: ServerCollation "' + ISNULL(@ServerCollation, '?') + '" is not matching with DatabaseCollation "' + ISNULL(@DatabaseCollation, '??') + '"!');
END
ELSE
BEGIN
  PRINT ('Info: ServerCollation and DatabaseCollation are matching.');
END;
GO

-- cleanup
PRINT ('');
DROP TABLE __TMP__TableToOutput__
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
