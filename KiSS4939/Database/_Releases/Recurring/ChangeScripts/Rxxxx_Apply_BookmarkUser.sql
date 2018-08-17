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
USE [{DBName}];
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
  CREATE LOGIN [kiss_bm] WITH PASSWORD=N'textmarken88$', DEFAULT_DATABASE=[{DBName}], CHECK_EXPIRATION=OFF;
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
USE [{DBName}];
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
USE [{DBName}];
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
USE [{DBName}];
GO