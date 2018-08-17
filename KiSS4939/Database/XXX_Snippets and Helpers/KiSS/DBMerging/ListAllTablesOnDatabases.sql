/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all tables in all databases for specific release number or
           database names.
           Do not list temporary or obsolete tables in output.
=================================================================================================*/

-- init
SET NOCOUNT ON;

-- init vars
DECLARE @DBList TABLE 
(
  ID INT NOT NULL IDENTITY (1, 1),
  DBName SYSNAME NOT NULL
);

DECLARE @DBOs TABLE
(
  ID INT NOT NULL IDENTITY (1, 1),
  DBOName SYSNAME NOT NULL,
  DBName SYSNAME NOT NULL,
  Type VARCHAR(20) NOT NULL
);

DECLARE @DBName SYSNAME;
DECLARE @ID INT;
DECLARE @SQL VARCHAR(MAX);

-- use master
USE [master];

-- fill all KiSS_ databases
INSERT INTO @DBList(DBName)
  SELECT name
  FROM sys.databases
  WHERE name LIKE '%R4246'
     OR name = 'KiSS_ZH_Test_Prototyp'
  /*
  WHERE name LIKE 'KiSS_%'
    AND name NOT LIKE 'KiSS3_%'   -- exclude KiSS3
    AND name NOT LIKE 'KiSS_ZH_%' -- exclude ZH for this run
  */
  ORDER BY name;

-- loop all databases
WHILE ((SELECT COUNT(1) 
       FROM @DBList) > 0)
BEGIN
  -- get current database
  SELECT TOP 1 
         @DBName = DBName,
         @ID = ID
  FROM @DBList
  ORDER BY ID ASC;
  
  -- setup sql
  SET @SQL = 'USE [' + @DBName + '];' +
             'SELECT DBOName = name,
                     DBName  = ''' + @DBName + ''',
                     Type    = type
              FROM sys.tables
              WHERE is_ms_shipped = 0;'
  
  -- get all dbos for given database
  INSERT INTO @DBOs (DBOName, DBName, Type)
    EXEC (@SQL);  
  
  -- remove current database to prepare for next
  DELETE TMP
  FROM @DBList TMP 
  WHERE ID = @ID;
END;

SELECT DISTINCT
       DBOName = DBO.DBOName,
       Usage   = CASE
                   WHEN (SELECT COUNT(1) FROM @DBOs SDBO WHERE SDBO.DBOName = DBO.DBOName) = 1 
                     THEN (SELECT SDBO.DBName FROM @DBOs SDBO WHERE SDBO.DBOName = DBO.DBOName)
                   ELSE CONVERT(VARCHAR(20), (SELECT COUNT(1) FROM @DBOs SDBO WHERE SDBO.DBOName = DBO.DBOName)) + ' DBs'
                 END
FROM @DBOs DBO
WHERE DBO.DBOName NOT LIKE 'tdfKiss%'
  AND DBO.DBOName NOT LIKE 'tcoKiss%'
  AND DBO.DBOName NOT LIKE '\_OBSOLETE%' ESCAPE '\'
  AND DBO.DBOName NOT LIKE '\_tmp%' ESCAPE '\'
  AND DBO.DBOName NOT LIKE 'OLD\_%' ESCAPE '\'
  AND DBO.DBOName NOT LIKE '\_OLD%' ESCAPE '\'
ORDER BY DBOName;
GO