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
IF ((@DBWholeSize > 200 AND @DBWholeSize < 20480) OR ((';' + '{NSExt}' + ';') LIKE '%;PI;%'))
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