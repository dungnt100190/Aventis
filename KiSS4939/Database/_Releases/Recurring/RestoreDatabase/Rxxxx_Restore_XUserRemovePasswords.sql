/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to remove all passwords on table XUser. This script is only allowed 
           to run with BIAG internal RESTORE tag.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 4 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- check history version
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'Hist_XUser'))
BEGIN
  -- create new history entry if table is historised
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
END;

-------------------------------------------------------------------------------
-- update entries in XUser if table is existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'XUser'))
BEGIN
  -- update entries and remove passwords
  UPDATE USR
  SET USR.PasswordHash = '4P/dakfPi6MQqGVn7Tdelw=='
  FROM dbo.XUser USR;
  
  -- info
  PRINT ('WARNING: Removed all passwords from table XUser!');
END;

-------------------------------------------------------------------------------
-- update entries in SysLogin if table is existing
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'SysLogin'))
BEGIN
  -- update entries and remove passwords
  UPDATE LGI
  SET LGI.PasswordHash = '4P/dakfPi6MQqGVn7Tdelw=='
  FROM dbo.SysLogin LGI
  WHERE AuthenticationModeEnum = 2; -- KiSS
  
  -- info
  PRINT ('WARNING: Removed all passwords from table SysLogin!');
END;
GO