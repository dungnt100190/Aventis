-------------------------------------------------------------------------------
-- See: http://www.sqlservercentral.com/scripts/Miscellaneous/30262/
-------------------------------------------------------------------------------

-- init vars
DECLARE @DbName VARCHAR(255)
SET @DbName = DB_NAME()

-- show current database
SELECT 'CurrentDataBase' = @DbName

-- get data
SELECT Orig_DBName = bus.database_name,
       Restored_To_DBName,
       Last_Date_Restored
FROM msdb..backupset bus
  INNER JOIN (SELECT backup_set_id,
                     Restored_To_DBName,
                     Last_Date_Restored
              FROM msdb..restorehistory
                INNER JOIN (SELECT rh.destination_database_name Restored_To_DBName,
                                   Max(rh.restore_date) Last_Date_Restored
                            FROM msdb..restorehistory rh
                            GROUP BY rh.destination_database_name
                           ) AS InnerRest ON destination_database_name = Restored_To_DBName 
                                         AND restore_date = Last_Date_Restored) AS RestData ON bus.backup_set_id = RestData.backup_set_id
ORDER BY CASE 
           WHEN bus.database_name = @DbName THEN 0
           ELSE 1
         END,
         CASE 
           WHEN Restored_To_DBName = @DbName THEN 0
           ELSE 1
         END,
         bus.database_name,
         Last_Date_Restored;
GO

-------------------------------------------------------------------------------
-- other approach
--
-- see: http://www.mssqltips.com/tip.asp?tip=1860
-------------------------------------------------------------------------------
/*
SELECT [rs].[destination_database_name],
       [rs].[restore_date],
       [bs].[backup_start_date],
       [bs].[backup_finish_date],
       [bs].[database_name] AS [source_database_name],
       [bmf].[physical_device_name] AS [backup_file_used_for_restore]
FROM msdb..restorehistory rs
  INNER JOIN msdb..backupset bs ON [rs].[backup_set_id] = [bs].[backup_set_id]
  INNER JOIN msdb..backupmediafamily bmf ON [bs].[media_set_id] = [bmf].[media_set_id]
ORDER BY [rs].[restore_date] DESC
*/
