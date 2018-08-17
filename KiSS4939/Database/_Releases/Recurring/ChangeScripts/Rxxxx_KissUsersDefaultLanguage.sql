/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix default language of server-user "{SqlUserName}" and "kiss_bm"
           to "us_english" to prevent language specific errors such as datetime-convert.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- switch to master database
-------------------------------------------------------------------------------
USE [master];
GO

-------------------------------------------------------------------------------
-- try to fix kiss user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'{SqlUserName}'))
BEGIN
  -- fix language
  ALTER LOGIN [{SqlUserName}] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "{SqlUserName}" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "{SqlUserName}" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- try to fix kiss_bm user
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.server_principals WHERE name = N'kiss_bm'))
BEGIN
  -- fix language
  ALTER LOGIN [kiss_bm] WITH DEFAULT_LANGUAGE=[us_english];
  
  -- info
  PRINT ('Info: Set default language of server-user "kiss_bm" to "us_english"');
END
ELSE
BEGIN
  -- info
  PRINT ('Warning: Could not fix default language of server-user "kiss_bm" to "us_english", user not found!');
END;
GO

-------------------------------------------------------------------------------
-- switch back to origin database
-------------------------------------------------------------------------------
{Include:Rxxxx_Use_Database}
GO