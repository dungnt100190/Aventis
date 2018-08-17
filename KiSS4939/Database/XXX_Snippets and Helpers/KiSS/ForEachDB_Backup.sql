DECLARE @cmd varchar(4000)

DECLARE @BackupDir  varchar(1000)
SET @BackupDir = 'C:\Backup\MSSQL\'

SET @cmd = '
IF ''?'' NOT IN (''Northwind'', ''tempdb'', ''pubs'') BEGIN
  BACKUP DATABASE [?]
    TO DISK = N''' + @BackupDir + '?.SQLBackup''
    WITH
      DESCRIPTION = N''Full Backup of ?'',
      NAME = N''? backup'',
      INIT, NOUNLOAD, SKIP, NOFORMAT

  IF DATABASEPROPERTYEX(N''?'', N''RECOVERY'') != ''SIMPLE'' BEGIN
    BACKUP LOG [?]
      TO DISK = N''' + @BackupDir + '?.SQLBackup''
      WITH
        DESCRIPTION = N''Log Backup of ?'',
        NAME = N''?_log backup'',
        NOINIT, NOUNLOAD, SKIP, NOFORMAT
  END
END
'

DECLARE @cmdDebug varchar(5000)

SET @cmdDebug = '
USE [?]

DECLARE @sql nvarchar (4000)

SET @sql = ''' + REPLACE(@cmd, '''', '''''') + ' ''
PRINT REPLICATE (''-'' , 80) + CHAR(13) + @sql + CHAR(13) + '' ''
EXEC sp_executesql @sql '

EXECUTE sp_msforeachdb @cmdDebug
