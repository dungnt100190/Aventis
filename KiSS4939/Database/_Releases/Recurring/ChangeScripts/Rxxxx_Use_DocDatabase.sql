/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select optional document database for current release.
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-- check if database exists
IF (DB_ID('{DocDBName}') IS NULL)
BEGIN
  RAISERROR('The Database ''{DocDBName}'' does not exist on the server!', 20, -1) WITH LOG;
END;
GO

-------------------------------------------------------------------------------------------------
-- select desired database
-------------------------------------------------------------------------------------------------
-- use document database (name must be given all the time, if no document database exists, use default database)
USE [{DocDBName}];
GO