/*===============================================================================================
  $Archive: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/LocalRestore_ApplySecurity.sql $
  $Author: Cjaeggi $
  $Modtime: 27.07.10 10:45 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to automatically assign user "kiss3" to all KiSS(3) databases. 
           The bookmark user including its role and rights will be (re)created, too, on all 
           KiSS databases (> KiSS3 and non-DOC-dbs).
           
           For further details see VSS: $/Database/Scripts/Automation/ApplySecurityToDatabases.sql
           
           Run this script manually after any manual restore of a KiSS database.
=================================================================================================
  $Log: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/LocalRestore_ApplySecurity.sql $
 * 
 * 1     27.07.10 10:48 Cjaeggi
=================================================================================================*/

------------------------------------------------------------------------------
-- start call
------------------------------------------------------------------------------
SET NOCOUNT ON;
PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113));
PRINT ('');

------------------------------------------------------------------------------
-- use database
------------------------------------------------------------------------------
USE [master];

------------------------------------------------------------------------------
-- check if need to create kiss3-user
------------------------------------------------------------------------------
IF (NOT EXISTS (SELECT TOP 1 1 FROM sys.server_principals WHERE name = N'kiss3'))
BEGIN
  CREATE LOGIN [kiss3] WITH PASSWORD=N'kiss2012', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;
  
  -- info
  PRINT ('info: user "kiss3" could not be found and therefore was created on server');
END;
GO

------------------------------------------------------------------------------
-- set and validate server version
------------------------------------------------------------------------------
DECLARE @ServerName VARCHAR(50);

SET @ServerName = CASE
                    WHEN @@VERSION LIKE '%Microsoft SQL Server 2005%' THEN @@SERVERNAME
                    WHEN @@VERSION LIKE '%Microsoft SQL Server 2008%' THEN @@SERVERNAME
                    ELSE NULL
                  END;

IF (@ServerName IS NULL)
BEGIN
  -- do not continue
  RAISERROR ('Error: Current SQL-Server version is not supported: Version=(''%s'')!', 18, 1, @@Version);
  RETURN;
END;

-- info
PRINT ('info: using sql server instance "' + @ServerName + '"');
PRINT ('');

------------------------------------------------------------------------------
-- init vars
------------------------------------------------------------------------------
DECLARE @SQL_DBAccess NVARCHAR(MAX);
DECLARE @SQL_DBAccess_EXEC NVARCHAR(MAX);

DECLARE @SQL_BMUser NVARCHAR(MAX);
DECLARE @SQL_BMUser_EXEC NVARCHAR(MAX);

------------------------------------------------------------------------------
-- set sql-template script: used for setting up user access
------------------------------------------------------------------------------
SET @SQL_DBAccess = '
  ----------------------------------------------------------------------------
  -- use database
  ----------------------------------------------------------------------------
  USE [<DBName>];
  
  ----------------------------------------------------------------------------
  -- init vars
  ----------------------------------------------------------------------------
  DECLARE @SchemaName NVARCHAR(255);
  DECLARE @SQL NVARCHAR(1000);
  
  ----------------------------------------------------------------------------
   -- set owner to sa (otherwise possibly an error would occure)
  ----------------------------------------------------------------------------
  -- info
  PRINT (''changed owner of database to "sa"'');
  
  -- set owner
  EXEC dbo.sp_changedbowner @loginame = N''sa'', @map = false;
  
  ----------------------------------------------------------------------------
  -- validate if kiss3 is assigned
  -- if assigned, we don`t expect any problems
  ----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1
             FROM sys.database_principals 
             WHERE name = N''kiss3''
               AND type = N''S''))
  BEGIN
    -- info
    PRINT (''info: user "kiss3" is assigned, no changed required'');
    RETURN;
  END;
  
  ----------------------------------------------------------------------------
  -- drop assignment of user kiss3 and reassign
  ----------------------------------------------------------------------------
  -- check if need to drop first
  IF (EXISTS(SELECT TOP 1 1
             FROM sys.database_principals 
             WHERE name = N''kiss3''
               AND type = N''S''))
  BEGIN
    -- check if user owns a schema
    SELECT @SchemaName = SCH.name
    FROM sys.database_principals DBP
      INNER JOIN sys.schemas     SCH ON SCH.principal_id = DBP.principal_id
    WHERE DBP.name = N''kiss3''
      AND DBP.type = N''S'';
    
    IF (ISNULL(@SchemaName, '''') <> '''')
    BEGIN
      -- info
      PRINT (''user "kiss3" owns a schema, drop schema "'' + @SchemaName + ''" first'');
      
      -- drop schema
      SET @SQL = N''DROP SCHEMA ['' + @SchemaName + N'']'';
      EXEC sp_executesql @SQL;
    END;
    
    -- info
    PRINT (''drop assignment of user "kiss3"'');
  
    -- drop assignment of kiss3 user
    DROP USER [kiss3];
  END;
  
  -- info
  PRINT (''reassign user "kiss3"'');
  
  -- reassign as db-owner
  CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA=[dbo];
  EXEC sp_addrolemember N''db_owner'', N''kiss3'';
  
  ----------------------------------------------------------------------------
  -- done
  ----------------------------------------------------------------------------
  RETURN;';

------------------------------------------------------------------------------
-- set sql-template script: used for setting up user access
------------------------------------------------------------------------------
SET @SQL_BMUser = '
  ----------------------------------------------------------------------------
  -- remove user kiss_bm on database if existing
  ----------------------------------------------------------------------------
  USE [<DBName>];
  
  IF (EXISTS(SELECT TOP 1 1
             FROM sys.database_principals 
             WHERE name = N''kiss_bm''))
  BEGIN
    -- info
    PRINT (''drop user "kiss_bm" on database'');
    
    -- drop
    DROP USER [kiss_bm];
  END
  ELSE
  BEGIN
    -- info
    PRINT (''info: user "kiss_bm" not found on database'');
  END;
  
  ----------------------------------------------------------------------------
  -- create login on server if not existing yet
  ----------------------------------------------------------------------------
  USE [master];

  IF (NOT EXISTS(SELECT TOP 1 1
                 FROM sys.server_principals
                 WHERE name = ''kiss_bm''))
  BEGIN
    -- info
    PRINT (''create login "kiss_bm" on server'');
    
    -- create login
    CREATE LOGIN [kiss_bm] WITH PASSWORD=N''textmarken88$'', DEFAULT_DATABASE=[<DBName>], CHECK_EXPIRATION=OFF;
  END
  ELSE
  BEGIN
    -- info
    PRINT (''info: login "kiss_bm" already exists on server'');
  END;
  
  ----------------------------------------------------------------------------
  -- create user on database if not existing yet
  ----------------------------------------------------------------------------
  USE [<DBName>];

  IF (NOT EXISTS(SELECT TOP 1 1
                 FROM sysusers
                 WHERE name = ''kiss_bm''))
  BEGIN
    -- info
    PRINT (''create user "kiss_bm" on database'');
    
    -- create user
    CREATE USER [kiss_bm] FOR LOGIN [kiss_bm];
  END
  ELSE
  BEGIN
    -- info
    PRINT (''info: user "kiss_bm" already exists on database'');
  END;
  
  ----------------------------------------------------------------------------
  -- create role on database if not existing yet
  ----------------------------------------------------------------------------
  USE [<DBName>];
  
  IF (NOT EXISTS(SELECT TOP 1 1
                 FROM sysusers
                 WHERE name = ''KiSS_BookmarksOnly''))
  BEGIN
    -- info
    PRINT (''create role "KiSS_BookmarksOnly" on database'');
    
    -- create role
    CREATE ROLE [KiSS_BookmarksOnly];
  END
  ELSE
  BEGIN
    -- info
    PRINT (''info: role "KiSS_BookmarksOnly" already exists on database'');
  END;
  
  -- assign role to user
  EXEC sp_addrolemember N''KiSS_BookmarksOnly'', N''kiss_bm''
  GRANT EXECUTE ON [dbo].[spXGetBookmark] TO [KiSS_BookmarksOnly]
  
  ----------------------------------------------------------------------------
  -- DENY ON SEVERAL SERVER OBJECTS
  ----------------------------------------------------------------------------
  USE [master]

  DENY ADMINISTER BULK OPERATIONS TO [kiss_bm]
  DENY ALTER ANY CONNECTION TO [kiss_bm]
  DENY ALTER ANY CREDENTIAL TO [kiss_bm]
  DENY ALTER ANY DATABASE TO [kiss_bm]
  DENY ALTER ANY ENDPOINT TO [kiss_bm]
  DENY ALTER ANY EVENT NOTIFICATION TO [kiss_bm]
  DENY ALTER ANY LINKED SERVER TO [kiss_bm]
  DENY ALTER ANY LOGIN TO [kiss_bm]
  DENY ALTER RESOURCES TO [kiss_bm]
  DENY ALTER SERVER STATE TO [kiss_bm]
  DENY ALTER SETTINGS TO [kiss_bm]
  DENY ALTER TRACE TO [kiss_bm]
  DENY AUTHENTICATE SERVER TO [kiss_bm]
  DENY CREATE ANY DATABASE TO [kiss_bm]
  DENY CREATE DDL EVENT NOTIFICATION TO [kiss_bm]
  DENY CREATE ENDPOINT TO [kiss_bm]
  DENY CREATE TRACE EVENT NOTIFICATION TO [kiss_bm]
  DENY EXTERNAL ACCESS ASSEMBLY TO [kiss_bm]
  DENY SHUTDOWN TO [kiss_bm]
  DENY UNSAFE ASSEMBLY TO [kiss_bm]
  DENY VIEW ANY DATABASE TO [kiss_bm]
  GRANT VIEW ANY DEFINITION TO [kiss_bm]
  DENY VIEW SERVER STATE TO [kiss_bm]
  
  ----------------------------------------------------------------------------
  -- after all, switch back to original database
  ----------------------------------------------------------------------------
  USE [<DBName>];';

------------------------------------------------------------------------------
-- loop all databases until one result is found
------------------------------------------------------------------------------
-- setup vars
DECLARE @DBName NVARCHAR(255);

-- setup cursor
DECLARE curDatabases CURSOR FAST_FORWARD FOR
  SELECT DBS.name
  FROM sys.databases DBS
  WHERE (DBS.name LIKE 'KiSS\_%' ESCAPE '\' OR DBS.name LIKE 'KiSS3\_%' ESCAPE '\')
    AND DBS.is_read_only = 0  -- prevent modifying readonly databases
  ORDER BY DBS.name;

-- iterate through cursor
OPEN curDatabases;
WHILE (1 = 1)
BEGIN
  -- read next row and check if we have one
  FETCH NEXT
  FROM curDatabases
  INTO @DBName;

  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;

  -- spacer
  PRINT ('------------------------------------------------------------------------------');
  PRINT ('DBName: ' + ISNULL(@DBName, '<??>') + ': ' + CONVERT(VARCHAR, GETDATE(), 113));
  PRINT ('------------------------------------------------------------------------------');
  
  -- setup sql-scripts
  SET @SQL_DBAccess_EXEC = REPLACE(@SQL_DBAccess, '<DBName>', @DBName);
  SET @SQL_DBAccess_EXEC = REPLACE(@SQL_DBAccess_EXEC, '<ServerName>', @ServerName);
  
  SET @SQL_BMUser_EXEC   = REPLACE(@SQL_BMUser, '<DBName>', @DBName);

  -- execute scripts on current database
  EXEC sp_executesql @SQL_DBAccess_EXEC;
  
  -- only if not "KiSS3%" and "%_DOC"
  IF ((@DBName NOT LIKE 'KiSS3\_%' ESCAPE '\') AND (@DBName NOT LIKE '%\_DOC' ESCAPE '\'))
  BEGIN
    -- info
    PRINT ('----');
    EXEC sp_executesql @SQL_BMUser_EXEC;
  END
  
  -- done with db
  PRINT ('------------------------------------------------------------------------------');
  PRINT ('');
END; -- [WHILE cursor]

-- clean up cursor
CLOSE curDatabases;
DEALLOCATE curDatabases;

------------------------------------------------------------------------------
-- done
------------------------------------------------------------------------------
PRINT ('done: ' + CONVERT(VARCHAR, GETDATE(), 113));
GO
