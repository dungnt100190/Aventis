/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to back up the database to R5000 after running the release.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
-- init vars
DECLARE @BackupFolder VARCHAR(500);
--
DECLARE @TFSDirectory VARCHAR(MAX);
DECLARE @IsZH BIT;
DECLARE @IsZH_SZHM5200 BIT;
--
DECLARE @SQL NVARCHAR(500);
DECLARE @DBName VARCHAR(128);

-- zh-handling
SET @IsZH = CASE 
              WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;ZH;%') OR
                   (N';' + N'{NSExt}' + N';' LIKE N'%;$ZH;%') THEN 1 
              ELSE 0
            END;

SET @IsZH_SZHM5200 = CASE 
                       WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;SZHM5200;%') OR
                            (N';' + N'{NSExt}' + N';' LIKE N'%;$SZHM5200;%') THEN 1 
                       ELSE 0
                     END;

SET @BackupFolder = CASE 
                      WHEN @IsZH_SZHM5200 = 1 THEN N'I:\SQL_Backup\TeamCityDBs\'    -- SZHM5200
                      WHEN @IsZH = 1          THEN N'E:\SQL_Backup\TeamCityDBs\'    -- SOZM9500
                      ELSE '\\CHBEHVS005\KiSSDatabases\TeamCityDBs\'                -- CHBEHVS005
                    END;

-------------------------------------------------------------------------------
-- create backup
-------------------------------------------------------------------------------
-- replace current release number with R5000
SET @DBName = SUBSTRING(REPLACE('{DBName}', 'R4', 'R5000'), 0, LEN('{DBName}') + 1);

PRINT ('creating backup to "' + @DBName + '"');

SET @SQL = N'
  BACKUP DATABASE [{DBName}]
  TO DISK = N''' + @BackupFolder + @DBName + N'.bak''
  WITH NOFORMAT, INIT, NAME = N''{DBName}-Full Database Backup'', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
  ';

EXECUTE sys.sp_executesql @SQL;

PRINT ('---- done creating backup to "' + @BackupFolder + @DBName + '.bak" ----');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO