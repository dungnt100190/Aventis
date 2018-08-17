/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to compare specific tables on all databases for specific release 
           number or database names.
           The table will be compared to standard, pi and zh solutions.
=================================================================================================*/

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
SET NOCOUNT ON;

-- use master
USE [master];

-- init vars
DECLARE @DBList TABLE 
(
  ID INT NOT NULL IDENTITY (1, 1),
  DBName SYSNAME NOT NULL,
  IsStandard BIT NOT NULL,
  IsPI BIT NOT NULL,
  IsZH BIT NOT NULL
);

DECLARE @DBOs TABLE
(
  ID INT NOT NULL IDENTITY (1, 1),
  DBOName SYSNAME NOT NULL,
  DBName SYSNAME NOT NULL,
  Type VARCHAR(20) NOT NULL,
  CreateScript VARCHAR(MAX),
  ExistsSameNameDBO BIT NOT NULL DEFAULT (0),
  --
  IsInStandardSame BIT NOT NULL DEFAULT (0),
  IsInStandardAndPISame BIT NOT NULL DEFAULT (0),
  IsInStandardAndZHSame BIT NOT NULL DEFAULT (0),
  IsInPIAndZHSame BIT NOT NULL DEFAULT (0),
  IsInAllSame BIT NOT NULL DEFAULT (0),
  --
  UsageCount INT
);

DECLARE @DBName SYSNAME;
DECLARE @ID INT;
DECLARE @SQL VARCHAR(MAX);
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @CountDBs INT;
DECLARE @SpecificTableOnly VARCHAR(255);

-- set specific table or NULL if all tables have to be compared
SET @SpecificTableOnly = 'BaAdresse';
SET @SpecificTableOnly = NULL;

-------------------------------------------------------------------------------
-- fill all required KiSS_ databases
-------------------------------------------------------------------------------
INSERT INTO @DBList(DBName, IsStandard, IsPI, IsZH)
  SELECT DBName     = name,
         IsStandard = CASE
                        WHEN name NOT LIKE '%\_PI\_%' ESCAPE '\'
                         AND name NOT LIKE '%\_ZH\_%' ESCAPE '\' THEN 1
                        ELSE 0
                      END,
         IsPI       = CASE
                        WHEN name LIKE '%\_PI\_%' ESCAPE '\' THEN 1
                        ELSE 0
                      END,
         IsZH       = CASE
                        WHEN name LIKE '%\_ZH\_%' ESCAPE '\' THEN 1
                        ELSE 0
                      END
  FROM sys.databases
  WHERE name LIKE '%R4246'
     OR name = 'KiSS_ZH_Test_Prototyp'
  ORDER BY name;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

SET @SpecificTableOnly = ISNULL(@SpecificTableOnly, 'NULL');
SET @CountDBs = @EntriesCount;

-------------------------------------------------------------------------------
-- optional output databases
-------------------------------------------------------------------------------
/*
SELECT *
FROM @DBList
ORDER BY DBName;
--*/

-------------------------------------------------------------------------------
-- loop all databases and collect dbos
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current database
  SELECT @DBName = DBName,
         @ID = ID
  FROM @DBList
  WHERE ID = @EntriesIterator;
  
  -- setup sql
  SET @SQL = 'USE [' + @DBName + '];' +
             'SELECT DBOName        = name,
                     DBName         = ''' + @DBName + ''',
                     Type           = type,
                     CreateScript   = dbo.fnXCreateTableScript(name, 1, 0)    -- only FKs, no indexes
              FROM sys.tables
              WHERE is_ms_shipped = 0
                AND (''' + @SpecificTableOnly + ''' = ''NULL'' OR name = ''' + @SpecificTableOnly + ''')
                AND name NOT LIKE ''tdfKiss%''
                AND name NOT LIKE ''tcoKiss%''
                AND name NOT LIKE ''tblKiss%''
                AND name NOT LIKE ''sysdiagrams''
                AND name NOT LIKE ''\_OBSOLETE%'' ESCAPE ''\''
                AND name NOT LIKE ''\_tmp%'' ESCAPE ''\''
                AND name NOT LIKE ''OLD\_%'' ESCAPE ''\''
                AND name NOT LIKE ''\_OLD%'' ESCAPE ''\''
              
              UNION
              
              SELECT DBOName        = name,
                     DBName         = ''' + @DBName + ''',
                     Type           = type,
                     CreateScript   = ''''
              FROM sys.objects
              WHERE is_ms_shipped = 0
                AND type IN (''FN'', ''TF'', ''P'', ''V'');'
  
  -- get all dbos for given database
  INSERT INTO @DBOs (DBOName, DBName, Type, CreateScript)
    EXEC (@SQL);  
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- optional cleanup
-------------------------------------------------------------------------------
/*
DELETE DBO
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsStandard = 0;
--*/

-------------------------------------------------------------------------------
-- preparations
-------------------------------------------------------------------------------
-- exists other dbo-type with same name
UPDATE DBO
SET DBO.ExistsSameNameDBO = CASE
                              WHEN EXISTS (SELECT TOP 1 1
                                           FROM @DBOs SDBO
                                           WHERE SDBO.DBOName = DBO.DBOName
                                             AND SDBO.Type <> DBO.Type) THEN 1
                              ELSE 0
                            END
FROM @DBOs DBO
WHERE DBO.Type = 'U';

-- remove all non-table entries
DELETE DBO
FROM @DBOs DBO
WHERE DBO.Type <> 'U';

-- usage count
UPDATE DBO
SET DBO.UsageCount = (SELECT COUNT(1) FROM @DBOs SDBO WHERE SDBO.DBOName = DBO.DBOName)
FROM @DBOs DBO;

-------------------------------------------------------------------------------
-- compare scripts: Standard to Standard
-------------------------------------------------------------------------------
-- compare
UPDATE DBO
SET DBO.IsInStandardSame = CASE
                             WHEN DBO.UsageCount = 1 THEN 1
                             --
                             WHEN EXISTS (SELECT TOP 1 1
                                          FROM @DBOs SDBO
                                            INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                   AND SDBS.IsStandard = 1                -- compare only standard with eachother
                                          WHERE SDBO.DBName <> DBO.DBName
                                            AND SDBO.DBOName = DBO.DBOName
                                            AND SDBO.CreateScript <> DBO.CreateScript) THEN 0
                             --
                             ELSE 1
                           END
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsStandard = 1;                                                           -- compare only standard with eachother

-- fix others
UPDATE DBO
SET DBO.IsInStandardSame = ISNULL((SELECT MIN(CONVERT(INT, SDBO.IsInStandardSame))
                                   FROM @DBOs SDBO
                                     INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                            AND SDBS.IsStandard = 1
                                   WHERE SDBO.DBOName = DBO.DBOName), 1)                                 -- compare only standard with eachother
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsStandard = 0;                                                           -- only non standards
                            
-------------------------------------------------------------------------------
-- compare scripts: Standard to PI
-------------------------------------------------------------------------------
-- compare
UPDATE DBO
SET DBO.IsInStandardAndPISame = CASE
                                  WHEN DBO.UsageCount = 1 THEN 1
                                  WHEN DBO.IsInStandardSame = 0 THEN 0
                                  --
                                  WHEN EXISTS (SELECT TOP 1 1
                                               FROM @DBOs SDBO
                                                 INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                        AND (SDBS.IsStandard = 1
                                                                          OR SDBS.IsPI = 1)               -- compare only standard and PI with eachother
                                               WHERE SDBO.DBName <> DBO.DBName
                                                 AND SDBO.DBOName = DBO.DBOName
                                                 AND SDBO.CreateScript <> DBO.CreateScript) THEN 0
                                  --
                                  ELSE 1
                                END
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND (DBS.IsStandard = 1
                          OR DBS.IsPI = 1);                                                               -- compare only standard and PI with eachother

-- fix others
UPDATE DBO
SET DBO.IsInStandardAndPISame = ISNULL((SELECT MIN(CONVERT(INT, SDBO.IsInStandardAndPISame))
                                        FROM @DBOs SDBO
                                          INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                 AND (SDBS.IsStandard = 1
                                                                   OR SDBS.IsPI = 1)
                                        WHERE SDBO.DBOName = DBO.DBOName), 1)                             -- compare only standard and PI with eachother
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsStandard = 0
                        AND DBS.IsPI = 0;                                                                 -- only non standards and non PI

-------------------------------------------------------------------------------
-- compare scripts: Standard to ZH
-------------------------------------------------------------------------------
-- compare
UPDATE DBO
SET DBO.IsInStandardAndZHSame = CASE
                                  WHEN DBO.UsageCount = 1 THEN 1
                                  WHEN DBO.IsInStandardSame = 0 THEN 0
                                  --
                                  WHEN EXISTS (SELECT TOP 1 1
                                               FROM @DBOs SDBO
                                                 INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                        AND (SDBS.IsStandard = 1
                                                                          OR SDBS.IsZH = 1)               -- compare only standard and ZH with eachother
                                               WHERE SDBO.DBName <> DBO.DBName
                                                 AND SDBO.DBOName = DBO.DBOName
                                                 AND SDBO.CreateScript <> DBO.CreateScript) THEN 0
                                  --
                                  ELSE 1
                                END
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND (DBS.IsStandard = 1
                          OR DBS.IsZH = 1);                                                               -- compare only standard and ZH with eachother

-- fix others
UPDATE DBO
SET DBO.IsInStandardAndZHSame = ISNULL((SELECT MIN(CONVERT(INT, SDBO.IsInStandardAndZHSame))
                                        FROM @DBOs SDBO
                                          INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                 AND (SDBS.IsStandard = 1
                                                                   OR SDBS.IsZH = 1)
                                        WHERE SDBO.DBOName = DBO.DBOName), 1)                             -- compare only standard and ZH with eachother
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsStandard = 0
                        AND DBS.IsZH = 0;                                                                 -- only non standards and non ZH

-------------------------------------------------------------------------------
-- compare scripts: PI to ZH
-------------------------------------------------------------------------------
-- compare
UPDATE DBO
SET DBO.IsInPIAndZHSame = CASE
                            WHEN DBO.UsageCount = 1 THEN 1
                            --
                            WHEN EXISTS (SELECT TOP 1 1
                                         FROM @DBOs SDBO
                                           INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                                  AND (SDBS.IsPI = 1
                                                                    OR SDBS.IsZH = 1)                     -- compare only PI and ZH with eachother
                                         WHERE SDBO.DBName <> DBO.DBName
                                           AND SDBO.DBOName = DBO.DBOName
                                           AND SDBO.CreateScript <> DBO.CreateScript) THEN 0
                            --
                            ELSE 1
                          END
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND (DBS.IsPI = 1
                          OR DBS.IsZH = 1);                                                               -- compare only PI and ZH with eachother

-- fix others
UPDATE DBO
SET DBO.IsInPIAndZHSame = ISNULL((SELECT MIN(CONVERT(INT, SDBO.IsInPIAndZHSame))
                                  FROM @DBOs SDBO
                                    INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                                           AND (SDBS.IsPI = 1
                                                             OR SDBS.IsZH = 1)
                                  WHERE SDBO.DBOName = DBO.DBOName), 1)                                   -- compare only PI and ZH with eachother
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName
                        AND DBS.IsPI = 0
                        AND DBS.IsZH = 0;                                                                 -- only non PI and non ZH

-------------------------------------------------------------------------------
-- compare scripts: All with eachother
-------------------------------------------------------------------------------
-- compare
UPDATE DBO
SET DBO.IsInAllSame = CASE
                        WHEN DBO.UsageCount = 1 THEN 1
                        --
                        WHEN EXISTS (SELECT TOP 1 1
                                     FROM @DBOs SDBO
                                       INNER JOIN @DBList SDBS ON SDBS.DBName = SDBO.DBName
                                     WHERE SDBO.DBName <> DBO.DBName
                                       AND SDBO.DBOName = DBO.DBOName
                                       AND SDBO.CreateScript <> DBO.CreateScript) THEN 0
                        --
                        ELSE 1
                      END
FROM @DBOs DBO
  INNER JOIN @DBList DBS ON DBS.DBName = DBO.DBName;

-------------------------------------------------------------------------------
-- debug
-------------------------------------------------------------------------------
/*
SELECT DBOName, CreateScript, *
FROM @DBOs
WHERE DBOName = 'BaAdresse'
--GROUP BY DBOName, CreateScript
--*/

/*
SELECT *
FROM @DBOs
WHERE ExistsSameNameDBO = 1
--*/

/*
SELECT COUNT(DISTINCT DBOName)
FROM @DBOs
--*/

-------------------------------------------------------------------------------
-- output
-------------------------------------------------------------------------------
SELECT DISTINCT
       DBOName = DBO.DBOName,
       Usage   = CASE
                   WHEN DBO.UsageCount = 1 
                     THEN (SELECT SDBO.DBName FROM @DBOs SDBO WHERE SDBO.DBOName = DBO.DBOName)
                   ELSE CONVERT(VARCHAR(20), DBO.UsageCount) + ' DBs'
                 END,
       IsInStandardSame,
       IsInStandardAndPISame,
       IsInStandardAndZHSame,
       IsInPIAndZHSame,
       IsInAllSame,
       Action = CASE
                  WHEN DBO.ExistsSameNameDBO = 1 THEN 'Hard Merge/Deploy (Mixed)'
                  WHEN DBO.UsageCount = 1 THEN 'Easy Deploy/Drop'
                  WHEN DBO.UsageCount = @CountDBs AND DBO.IsInAllSame = 1 THEN 'Easy Merge (IX)'
                  WHEN DBO.IsInAllSame = 1 THEN 'Easy Merge/Deploy'
                  WHEN DBO.IsInStandardSame = 0 THEN 'Hardest Merge/Deploy'
                  WHEN DBO.IsInStandardSame = 1 AND IsInStandardAndPISame = 1 AND IsInStandardAndZHSame = 0 THEN 'Medium ZH Merge/Deploy'
                  WHEN DBO.IsInStandardSame = 1 AND IsInStandardAndPISame = 0 AND IsInStandardAndZHSame = 1 THEN 'Medium PI Merge/Deploy'
                  WHEN DBO.IsInStandardSame = 1 AND IsInStandardAndPISame = 0 AND IsInStandardAndZHSame = 0 THEN 'Hard Merge/Deploy'
                  ELSE '???'
                END
FROM @DBOs DBO
/*
WHERE IsInAllSame = 1
  AND UsageCount > 1
*/
ORDER BY DBOName;
GO