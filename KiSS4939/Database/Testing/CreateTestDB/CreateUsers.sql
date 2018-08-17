-------------------------------------------------------------------------------
-- CREATE USER AND ROLE, SETUP RIGHTS
-------------------------------------------------------------------------------

-- CREATE LOGINS
USE [master]
GO
IF NOT EXISTS(
  SELECT TOP 1 1
  FROM sys.server_principals
  WHERE name = 'kiss3'
)
BEGIN
  CREATE LOGIN [kiss3] WITH PASSWORD=N'kiss2012',
  DEFAULT_DATABASE=[{DBName}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END
ELSE
  PRINT 'sys.server_principals.kiss3 bereits vorhanden.'
GO

IF NOT EXISTS(
  SELECT TOP 1 1
  FROM sys.server_principals
  WHERE name = 'kiss_bm'
)
BEGIN
  CREATE LOGIN [kiss_bm] WITH PASSWORD=N'textmarken88$',
  DEFAULT_DATABASE=[{DBName}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END
ELSE
  PRINT 'sys.server_principals.kiss_bm bereits vorhanden.'
GO

IF NOT EXISTS(
  SELECT TOP 1 1
  FROM sys.server_principals
  WHERE name = 'kiss_public'
)
BEGIN
  CREATE LOGIN [kiss_public] WITH PASSWORD=N'K!55#55!K',
  DEFAULT_DATABASE=[{DBName}], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
END
ELSE
  PRINT 'sys.server_principals.kiss_public bereits vorhanden.'
GO

-- CREATE USERS
USE [{DBName}]
GO
CREATE USER [kiss3] FOR LOGIN [kiss3] WITH DEFAULT_SCHEMA=[dbo];
GO
EXEC sp_addrolemember N'db_owner', N'kiss3'
GO

CREATE USER [kiss_bm] FOR LOGIN [kiss_bm]
GO
CREATE ROLE [KiSS_BookmarksOnly]
GO
EXEC sp_addrolemember N'KiSS_BookmarksOnly', N'kiss_bm'
GO
--GRANT EXECUTE ON [dbo].[spXGetBookmark] TO [KiSS_BookmarksOnly] -- done in spXGetBookmark.sql

CREATE USER [kiss_public] FOR LOGIN [kiss_public]
GO

-------------------------------------------------------------------------------
-- DENY ON SEVERAL SERVER OBJECTS for kiss_bm
-------------------------------------------------------------------------------
use [master]
GO
DENY ADMINISTER BULK OPERATIONS TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY CONNECTION TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY CREDENTIAL TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY DATABASE TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY ENDPOINT TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY EVENT NOTIFICATION TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY LINKED SERVER TO [kiss_bm]
GO
use [master]
GO
DENY ALTER ANY LOGIN TO [kiss_bm]
GO
use [master]
GO
DENY ALTER RESOURCES TO [kiss_bm]
GO
use [master]
GO
DENY ALTER SERVER STATE TO [kiss_bm]
GO
use [master]
GO
DENY ALTER SETTINGS TO [kiss_bm]
GO
use [master]
GO
DENY ALTER TRACE TO [kiss_bm]
GO
use [master]
GO
DENY AUTHENTICATE SERVER TO [kiss_bm]
GO
use [master]
GO
DENY CREATE ANY DATABASE TO [kiss_bm]
GO
use [master]
GO
DENY CREATE DDL EVENT NOTIFICATION TO [kiss_bm]
GO
use [master]
GO
DENY CREATE ENDPOINT TO [kiss_bm]
GO
use [master]
GO
DENY CREATE TRACE EVENT NOTIFICATION TO [kiss_bm]
GO
use [master]
GO
DENY EXTERNAL ACCESS ASSEMBLY TO [kiss_bm]
GO
use [master]
GO
DENY SHUTDOWN TO [kiss_bm]
GO
use [master]
GO
DENY UNSAFE ASSEMBLY TO [kiss_bm]
GO
use [master]
GO
DENY VIEW ANY DATABASE TO [kiss_bm]
GO
use [master]
GO
GRANT VIEW ANY DEFINITION TO [kiss_bm]
GO
use [master]
GO
DENY VIEW SERVER STATE TO [kiss_bm]
GO

-------------------------------------------------------------------------------
-- DENY ON SEVERAL SERVER OBJECTS for kiss_public
-------------------------------------------------------------------------------
use [master]
GO
DENY ADMINISTER BULK OPERATIONS TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY CONNECTION TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY CREDENTIAL TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY DATABASE TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY ENDPOINT TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY EVENT NOTIFICATION TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY LINKED SERVER TO [kiss_public]
GO
use [master]
GO
DENY ALTER ANY LOGIN TO [kiss_public]
GO
use [master]
GO
DENY ALTER RESOURCES TO [kiss_public]
GO
use [master]
GO
DENY ALTER SERVER STATE TO [kiss_public]
GO
use [master]
GO
DENY ALTER SETTINGS TO [kiss_public]
GO
use [master]
GO
DENY ALTER TRACE TO [kiss_public]
GO
use [master]
GO
DENY AUTHENTICATE SERVER TO [kiss_public]
GO
use [master]
GO
DENY CREATE ANY DATABASE TO [kiss_public]
GO
use [master]
GO
DENY CREATE DDL EVENT NOTIFICATION TO [kiss_public]
GO
use [master]
GO
DENY CREATE ENDPOINT TO [kiss_public]
GO
use [master]
GO
DENY CREATE TRACE EVENT NOTIFICATION TO [kiss_public]
GO
use [master]
GO
DENY EXTERNAL ACCESS ASSEMBLY TO [kiss_public]
GO
use [master]
GO
DENY SHUTDOWN TO [kiss_public]
GO
use [master]
GO
DENY UNSAFE ASSEMBLY TO [kiss_public]
GO
use [master]
GO
DENY VIEW ANY DATABASE TO [kiss_public]
GO
use [master]
GO
GRANT VIEW ANY DEFINITION TO [kiss_public]
GO
use [master]
GO
DENY VIEW SERVER STATE TO [kiss_public]
GO

-------------------------------------------------------------------------------------------------
-- after all, switch back to original database
-------------------------------------------------------------------------------------------------
USE [{DBName}]
GO
