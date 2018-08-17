/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to disable CDC on current and document database to prevent errors 
           for capture job. This script can run on any database, even if there is no CDC available.

  WARNING: Running this script will drop all CDC history data!
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- use master database
-------------------------------------------------------------------------------
USE [master];
GO

-------------------------------------------------------------------------------
-- check if server is ready for CDC 
-- (requires SQLServer 2008 or newer and Developer or Enterprise edition)
-------------------------------------------------------------------------------
-- init vars
DECLARE @CanEnableCDC BIT;
DECLARE @ServerVersion VARCHAR(255);
DECLARE @ServerEdition VARCHAR(255);
--
DECLARE @SQLStatement NVARCHAR(MAX);

SET @CanEnableCDC = 0;
SET @ServerVersion = CONVERT(VARCHAR(255), SERVERPROPERTY('productversion'));
SET @ServerEdition = CONVERT(VARCHAR(255), SERVERPROPERTY ('edition'));

-- set vars
IF (@ServerVersion LIKE '10.%' AND (@ServerEdition LIKE 'Enterprise Edition%' OR @ServerEdition LIKE 'Developer Edition%'))
BEGIN
  SET @CanEnableCDC = 1;
END;

-- handling not available
IF (@CanEnableCDC = 0)
BEGIN
  PRINT ('Info: CDC is not available for this server (Version="' + ISNULL(@ServerVersion, '???') + '", Edition="' + ISNULL(@ServerEdition, '???') + '")');
  RETURN;
END;

PRINT ('Info: CDC is available for this server and will be disabled for main- (and optionally document-) database (Version="' + ISNULL(@ServerVersion, '???') + '", Edition="' + ISNULL(@ServerEdition, '???') + '")');

-------------------------------------------------------------------------------
-- disabling CDC in any case for main- and document-database
-------------------------------------------------------------------------------
-- main database
IF (EXISTS (SELECT TOP 1 1
            FROM sys.databases
            WHERE name = '{DBName}'
              AND state_desc = 'ONLINE'))
BEGIN
  SET @SQLStatement = 'USE [{DBName}];
                       EXEC sys.sp_cdc_disable_db;';
  
  EXEC sys.sp_executesql @SQLStatement;
  PRINT ('Info: Disabled CDC for current database "{DBName}" if it was enabled');
END;

-- document database
IF ((N';' + N'{NSExt}' + N';' LIKE N'%;SepDocDB;%' OR
     N';' + N'{NSExt}' + N';' LIKE N'%;$SepDocDB;%') 
    AND EXISTS (SELECT TOP 1 1
                FROM sys.databases
                WHERE name = '{DocDBName}'
                  AND state_desc = 'ONLINE'))
BEGIN
  SET @SQLStatement = 'USE [{DocDBName}];
                       EXEC sys.sp_cdc_disable_db;';
  
  EXEC sys.sp_executesql @SQLStatement;
  PRINT ('Info: Disabled CDC for current database "{DocDBName}" if it was enabled');
END;
GO

-------------------------------------------------------------------------------
-- use master database
-------------------------------------------------------------------------------
USE [master];
GO
