/*===============================================================================================
  $Archive: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/ExecSQLForEachKiSSDB.sql $
  $Author: Cjaeggi $
  $Modtime: 2.08.10 10:16 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to run a sql-statements on every KiSS database (non-DOC-databases).
=================================================================================================
  $Log: /KiSS4/Database/XXX_Snippets & Helpers/KiSS/ExecSQLForEachKiSSDB.sql $
 * 
 * 1     2.08.10 10:17 Cjaeggi
 * Added new script
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

USE [master];
GO

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @DatabaseName VARCHAR(255);
DECLARE @ID INT;
DECLARE @SQL NVARCHAR(MAX);
DECLARE @ExecSQL NVARCHAR(MAX);

-- create sql-statement to execute on every kiss database
SET @SQL = 'USE [<DatabaseName>];
            SELECT 1';

-------------------------------------------------------------------------------
-- create temp tables
-------------------------------------------------------------------------------
-- store all databases we want to scan
DECLARE @KiSSDatabases TABLE
(
  ID INT NOT NULL IDENTITY(1, 1),
  DatabaseName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- get all KiSS databases
-------------------------------------------------------------------------------
INSERT INTO @KiSSDatabases(DatabaseName)
  SELECT DatabaseName = name
  FROM sys.databases
  WHERE name LIKE 'KiSS_%'
    AND name NOT LIKE 'KiSS3_%'       -- exclude KiSS3
    AND name NOT LIKE 'KiSS_ZH_%'     -- exclude ZH for this run
    AND name NOT LIKE 'KiSS_%_DOC'    -- exclude all DOC databases
  ORDER BY name;

-------------------------------------------------------------------------------
-- loop all KiSS databases and get sql statements on databases
-------------------------------------------------------------------------------
WHILE ((SELECT COUNT(1) 
        FROM @KiSSDatabases) > 0)
BEGIN
  -- get current database
  SELECT TOP 1 
         @ID           = TMP.ID,
         @DatabaseName = TMP.DatabaseName
  FROM @KiSSDatabases TMP
  ORDER BY TMP.ID ASC;

  -----------------------------------------------------------------------------
  -- prepare and execute sql statement
  -----------------------------------------------------------------------------
  SET @ExecSQL = REPLACE(@SQL, '<DatabaseName>', @DatabaseName);
  
  EXEC sp_executesql @ExecSQL;
  -----------------------------------------------------------------------------

  -- remove current database to prepare for next
  DELETE TMP
  FROM @KiSSDatabases TMP 
  WHERE TMP.ID = @ID;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO