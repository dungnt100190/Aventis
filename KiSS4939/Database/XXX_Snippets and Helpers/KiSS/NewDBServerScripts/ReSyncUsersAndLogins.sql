/*===============================================================================================
  $Archive: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/ReSyncUsersAndLogins.sql $
  $Author: Cjaeggi $
  $Modtime: 26.08.10 8:59 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to resync sql logins as good as possible
=================================================================================================
  $Log: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/NewDBServerScripts/ReSyncUsersAndLogins.sql $
 * 
 * 3     26.08.10 9:43 Cjaeggi
 * Added server/datbase information and fixed scripts
=================================================================================================*/

-------------------------------------------------------------------------------
-- Resync SQL Logins
-------------------------------------------------------------------------------
DECLARE @Sql NVARCHAR(4000);
DECLARE @DBName NVARCHAR(255);

SET @DBName = DB_NAME();

-- Resync SQL Logins
SET @sql = N'
DECLARE cSQL CURSOR FAST_FORWARD FOR
  SELECT N''USE [' + @DBName + ']'' + CHAR(13) + CHAR(10) +
         N''EXEC sp_change_users_login ''''Auto_Fix'''', '''''' + name + ''''''''
  FROM [' + @DBName + ']..sysusers USR
  WHERE EXISTS (SELECT TOP 1 1 
                FROM master..syslogins 
                WHERE name COLLATE DATABASE_DEFAULT = USR.name COLLATE DATABASE_DEFAULT)';

EXECUTE (@sql);

OPEN cSQL
WHILE 1 = 1 
BEGIN
  FETCH NEXT 
  FROM cSQL 
  INTO @sql;
  
  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK
  END;
  
  EXECUTE sp_executesql @sql;
END;

CLOSE cSQL;
DEALLOCATE cSQL;
GO