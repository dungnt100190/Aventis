/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to automatically create a new backup for next release if not 
           existing yet (or restored of prod). 
           AND
           The backup will only be created if releasefile is in branch folder.
=================================================================================================*/

-------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 8 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- init and switch to master database
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

USE [master];
GO

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
-- init vars
DECLARE @BackupFolder VARCHAR(500);
--
DECLARE @TFSDirectory VARCHAR(MAX);
DECLARE @IsZH BIT;
DECLARE @IsZH_OIZSERVER BIT;
DECLARE @IsZH_SCHINTI BIT;
DECLARE @IsZH_TakeBakProdVortag BIT;
--
DECLARE @DBName VARCHAR(255);
DECLARE @DocDBName VARCHAR(255);
--
DECLARE @ReleaseNumber VARCHAR(4);
DECLARE @ReleaseNumberMajor VARCHAR(1);
DECLARE @ReleaseNumberMinor VARCHAR(1);
DECLARE @ReleaseNumberRevision VARCHAR(2);
--
DECLARE @NextReleaseNumber VARCHAR(4);
--
DECLARE @NextDBBackupName VARCHAR(1000);
DECLARE @NextDocDBBackupName VARCHAR(1000);
DECLARE @PerformBackupDB BIT;
DECLARE @PerformBackupDocDB BIT;
--
DECLARE @SQLStatement NVARCHAR(MAX);
DECLARE @SQLStatementExec NVARCHAR(MAX);

DECLARE @File_CheckResult TABLE 
(
  File_Exists INT,
  File_is_a_Directory INT,
  Parent_Directory_Exists INT
);

-- set vars
SET @TFSDirectory = '{TFSDirectory}';     -- e.g. "$/KiSS-Branches/KiSS4320/Database/_Releases/Release 4320/3. Release/2. Scripts/"
SET @DBName = '{DBName}';
SET @DocDBName = '{DocDBName}';
SET @PerformBackupDB = 0;
SET @PerformBackupDocDB = 0;


-- zh-handling
SET @IsZH = CASE 
              WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;ZH;%') OR
                   (N';' + N'{NSExt}' + N';' LIKE N'%;$ZH;%') THEN 1 
              ELSE 0
            END;

SET @IsZH_OIZSERVER = CASE 
                        WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;OIZSERVER;%') OR
                             (N';' + N'{NSExt}' + N';' LIKE N'%;$OIZSERVER;%') THEN 1 -- OIZSERVER
                        ELSE 0
                      END;

SET @IsZH_SCHINTI = CASE 
                      WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;SCHINTI;%') OR
                           (N';' + N'{NSExt}' + N';' LIKE N'%;$SCHINTI;%') THEN 1    -- SCHINTI
                      ELSE 0
                    END;

SET @BackupFolder = CASE 
                      WHEN @IsZH_OIZSERVER = 1 THEN N'I:\BakTrc\mssql2008\Backup\TeamCityDBs\' -- OIZSERVER
                      ELSE 'E:\kiss_backups\BuildDBs\' -- Diartis: local drive on sql2014, etc. ('\\schinti\e$\kiss_backups\BuildDBs' does not work at the moment)
                    END;

SET @IsZH_TakeBakProdVortag = CASE 
                                WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;SRCPRODBAK;%') OR
                                     (N';' + N'{NSExt}' + N';' LIKE N'%;$SRCPRODBAK;%') THEN 1     -- SRCPRODBAK
                                ELSE 0
                              END;

-- info out:
PRINT ('Info: @TFSDirectory = "' + ISNULL(@TFSDirectory, '<NULL>') + '"');
PRINT ('Info: @DBName = "' + ISNULL(@DBName, '<NULL>') + '"');
PRINT ('Info: @DocDBName = "' + ISNULL(@DocDBName, '<NULL>') + '"');
PRINT ('Info: @BackupFolder = "' + ISNULL(@BackupFolder, '<NULL>') + '"');

-- validate
/* -- we do create a backup for next release as we do not have a prod backup so far
IF (@IsZH_TakeBakProdVortag = 1)
BEGIN
  PRINT ('Info: The current Database was restored from backup of Prod-Vortag and is expected for the next time, too - script canceled.');
  RETURN;
END;
--*/

IF (@TFSDirectory NOT LIKE '$/KiSS-Branches/KiSS4___/Database/\_Releases/Release 4___/%' ESCAPE '\')
BEGIN
  PRINT ('Info: The current TFSDirectory "' + @TFSDirectory + '" does not match the rules for branch-releases-check - script canceled.');
  RETURN;
END;

IF (@DBName NOT LIKE 'KiSS\_%\_%\_R____' ESCAPE '\')
BEGIN
  PRINT ('Info: The current database-name "' + @DBName + '" does not match the rules used to get release number - script canceled.');
  RETURN;
END;

IF (@DocDBName <> @DBName AND 
    ((@DBName + '_DOC' <> @DocDBName) OR 
     (@DocDBName NOT LIKE 'KiSS\_%\_%\_R____\_DOC' ESCAPE '\')))
BEGIN
  PRINT ('Info: The current document-database-name "' + @DocDBName + '" does not match the rules used to get release number - script canceled.');
  RETURN;
END;

-------------------------------------------------------------------------------
-- get release-number from db-name
-------------------------------------------------------------------------------
SET @ReleaseNumber = SUBSTRING(@DBName, CHARINDEX('_R', @DBName, 0) + 2, LEN(@DBName));

SELECT @ReleaseNumberMajor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 1, 1),
       @ReleaseNumberMinor    = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 2, 1),
       @ReleaseNumberRevision = SUBSTRING(CONVERT(VARCHAR, @ReleaseNumber), 3, 2);

PRINT ('Info: Detected version "' + @ReleaseNumberMajor + '.' 
                                  + @ReleaseNumberMinor + '.' 
                                  + @ReleaseNumberRevision + '" for current database "' + @DBName + '".');

-------------------------------------------------------------------------------
-- calc next release number for database
-------------------------------------------------------------------------------
SET @NextReleaseNumber = CASE @ReleaseNumber
                           WHEN '4632' THEN '4644'
                           WHEN '4644' THEN '4709'
                           WHEN '4709' THEN '4731'
                           WHEN '4731' THEN '4741'
                           WHEN '4741' THEN '4806'
                           WHEN '4806' THEN '4829'
                           WHEN '4829' THEN '4839'
                           WHEN '4839' THEN '4906'
                           WHEN '4906' THEN '4929'
                           WHEN '4929' THEN '4939'
                           ELSE '?'
                         END;

-- validate
IF (@NextReleaseNumber NOT LIKE '4___')
BEGIN
  PRINT ('Warning: The calculated comming version "' + @NextReleaseNumber + '" for next database backup does not match the expected value - script canceled.');
  RETURN;
END
ELSE
BEGIN
  PRINT ('Info: Calculated comming version "' + @NextReleaseNumber + '" for next database backup".');
END;

-------------------------------------------------------------------------------
-- create backup names
-------------------------------------------------------------------------------
SET @NextDBBackupName = @BackupFolder + REPLACE(@DBName, @ReleaseNumber, @NextReleaseNumber) + '.bak';
SET @NextDocDBBackupName = @BackupFolder + REPLACE(@DocDBName, @ReleaseNumber, @NextReleaseNumber) + '.bak';

-------------------------------------------------------------------------------
-- check path is valid and files exists
-------------------------------------------------------------------------------
-- main-database
INSERT INTO @File_CheckResult (File_Exists, File_is_a_Directory, Parent_Directory_Exists)
  EXEC master.dbo.xp_fileexist @NextDBBackupName;

IF (EXISTS (SELECT TOP 1 1 
            FROM @File_CheckResult
            WHERE Parent_Directory_Exists = 0))
BEGIN
  PRINT ('Warning: The path for the database backup "' + @NextDBBackupName + '" was not found - script canceled.');
  RETURN;
END;

IF (EXISTS (SELECT TOP 1 1 
            FROM @File_CheckResult
            WHERE Parent_Directory_Exists = 1
              AND File_Exists = 0))
BEGIN
  PRINT ('Info: The database backup "' + @NextDBBackupName + '" does not exist, backup will be created.');
  SET @PerformBackupDB = 1;
END
ELSE
BEGIN
  PRINT ('Info: The database backup "' + @NextDBBackupName + '" does already exist, backup will not be created.');
END;

-- doc-database
IF (@NextDBBackupName <> @NextDocDBBackupName)
BEGIN
  DELETE FROM @File_CheckResult;

  INSERT INTO @File_CheckResult (File_Exists, File_is_a_Directory, Parent_Directory_Exists)
    EXEC master.dbo.xp_fileexist @NextDocDBBackupName;

  IF (EXISTS (SELECT TOP 1 1 
              FROM @File_CheckResult
              WHERE Parent_Directory_Exists = 0))
  BEGIN
    PRINT ('Warning: The path for the doc-database backup "' + @NextDocDBBackupName + '" was not found - script canceled.');
    RETURN;
  END;

  IF (EXISTS (SELECT TOP 1 1 
              FROM @File_CheckResult
              WHERE Parent_Directory_Exists = 1
                AND File_Exists = 0))
  BEGIN
    PRINT ('Info: The doc-database backup "' + @NextDocDBBackupName + '" does not exist, backup will be created.');
    SET @PerformBackupDocDB = 1;
  END
  ELSE
  BEGIN
    PRINT ('Info: The doc-database backup "' + @NextDocDBBackupName + '" does already exist, backup will not be created.');
  END;
END;

-------------------------------------------------------------------------------
-- perform backups if required
-------------------------------------------------------------------------------
-- init backup script
SET @SQLStatement = N'
  BACKUP DATABASE [<SourceDBName>] 
  TO DISK = N''<TargetFile>'' 
  WITH NOFORMAT, INIT, NAME = N''<SourceDBName>-Full Database Backup'', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
  
  PRINT (''---- done creating backup of "<SourceDBName>" ----'');';

-- main-database
IF (@PerformBackupDB = 1)
BEGIN
  SET @SQLStatementExec = REPLACE(@SQLStatement, '<SourceDBName>', @DBName);
  SET @SQLStatementExec = REPLACE(@SQLStatementExec, '<TargetFile>', @NextDBBackupName);
  
  --PRINT (@SQLStatementExec);
  EXEC sys.sp_executesql @SQLStatementExec;
END;

-- doc-database
IF (@PerformBackupDocDB = 1)
BEGIN
  SET @SQLStatementExec = REPLACE(@SQLStatement, '<SourceDBName>', @DocDBName);
  SET @SQLStatementExec = REPLACE(@SQLStatementExec, '<TargetFile>', @NextDocDBBackupName);
  
  --PRINT (@SQLStatementExec);
  EXEC sys.sp_executesql @SQLStatementExec;
END;
GO

-------------------------------------------------------------------------------
-- switch back to main database
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

{Include:Rxxxx_Use_Database}
GO