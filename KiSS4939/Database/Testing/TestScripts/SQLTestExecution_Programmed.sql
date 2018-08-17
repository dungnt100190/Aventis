/*===============================================================================================
  $Archive: /KiSS4/Database/Testing/TestScripts/SQLTestExecution_Programmed.sql $
  $Author: Cjaeggi $
  $Modtime: 6.08.10 15:55 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to test if Views, Functions (Scalar and Table) and Stored Procedures
           can run on current database (without modifying any data!).
=================================================================================================
  $Log: /KiSS4/Database/Testing/TestScripts/SQLTestExecution_Programmed.sql $
 * 
 * 2     6.08.10 15:56 Cjaeggi
 * #4167: Fixing performance, output and receiving data from output tables
 * 
 * 1     6.08.10 11:07 Cjaeggi
 * Renamed file
 * 
 * 4     6.08.10 10:57 Cjaeggi
 * #4167: Minor corrections and added checks for SPs
 * 
 * 3     6.08.10 10:16 Cjaeggi
 * Added checks for TFs
 * 
 * 2     5.08.10 15:38 Cjaeggi
 * #4167: Added check for views
 * 
 * 1     5.08.10 15:13 Cjaeggi
 * #4167: Created new testscript
=================================================================================================*/

--*****************************************************************************
-- pre-steps
--*****************************************************************************
SET NOCOUNT ON;
GO

-- info
PRINT ('---- Script version: $Revision: 2 $ ----');
PRINT ('Task - Init: ' + CONVERT(VARCHAR, GETDATE(), 113));
GO

-------------------------------------------------------------------------------
-- init global vars
-------------------------------------------------------------------------------
-- define vars
DECLARE @ErrorMessage VARCHAR(MAX);
DECLARE @DBName VARCHAR(255);
DECLARE @ID INT;
DECLARE @ExecSQLStatement NVARCHAR(MAX);
-- 
DECLARE @ViewName VARCHAR(255);
DECLARE @DBOName VARCHAR(255);
DECLARE @ParamNULLs VARCHAR(255);
--
DECLARE @ViewsCount INT;
DECLARE @InvalidViewsCounter INT;
--
DECLARE @TableFunctionsCount INT;
DECLARE @InvalidTableFunctionsCounter INT;
--
DECLARE @ScalarFunctionsCount INT;
DECLARE @InvalidScalarFunctionsCounter INT;
--
DECLARE @StoredProceduresCount INT;
DECLARE @InvalidStoredProceduresCounter INT;

-- init table containing parameter strings for various amount of parameters
DECLARE @ParameterNULLs TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  ParamNULLs VARCHAR(255) NOT NULL
);

-- init table containing all views for current database
DECLARE @Views TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  ViewName VARCHAR(255) NOT NULL
);

-- init table containing all dbos that require parameters for current database
DECLARE @DBOWithParameters TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  DBOName VARCHAR(255) NOT NULL,
  ParamNULLs VARCHAR(255) NULL -- no parameters are allowed
);

-- set vars
SET @DBName = DB_NAME();
SET @ParamNULLs = '';
--
SET @InvalidViewsCounter = 0;
SET @InvalidTableFunctionsCounter = 0;
SET @InvalidScalarFunctionsCounter = 0;
SET @InvalidStoredProceduresCounter = 0;

-- fill table with empty parameters
WHILE ((SELECT COUNT(1)
        FROM @ParameterNULLs) < 30)   -- allow 30 params
BEGIN
  -- handle delimiters
  IF (@ParamNULLs <> '')
  BEGIN
    SET @ParamNULLs = @ParamNULLs + ', ';
  END;
  
  -- append NULL to string for current entry
  SET @ParamNULLs = @ParamNULLs + 'NULL';
  
  INSERT INTO @ParameterNULLs (ParamNULLs)
  VALUES (@ParamNULLs);
END;

-- info
PRINT ('Info: Checking database <' + @DBName + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));




--*****************************************************************************
-- TEST 1: Views
--*****************************************************************************
--/*
PRINT ('Task - Validate all views: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- fill table
INSERT INTO @Views (ViewName)
  SELECT VIW.name
  FROM sys.views VIW
  WHERE VIW.is_ms_shipped = 0
  ORDER BY VIW.name;

-- count entries
SELECT @ViewsCount = COUNT(1)
FROM @Views;

-- loop all views
WHILE ((SELECT COUNT(1) 
        FROM @Views) > 0)
BEGIN
  -- get current entry
  SELECT TOP 1 
         @ID       = TMP.ID,
         @ViewName = TMP.ViewName
  FROM @Views TMP
  ORDER BY TMP.ID ASC;
  
  -----------------------------------------------------------------------------
  -- test view and try to get top 1 rows
  -----------------------------------------------------------------------------
  -- info
  PRINT ('°°° Testing: ' + @DBName + '.dbo.' + @ViewName + ': ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  BEGIN TRY
    SET @ExecSQLStatement = 'SELECT TOP 1 * 
                             INTO _Tmp_SQLTests
                             FROM dbo.' + @ViewName + ' WITH (READUNCOMMITTED);
                             
                             DROP TABLE _Tmp_SQLTests;';
    EXEC sp_executesql @ExecSQLStatement;
  END TRY
  BEGIN CATCH
    -- count up
    SET @InvalidViewsCounter = @InvalidViewsCounter + 1;
  
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE();
    
    -- output
    PRINT ('--****--------------------------------------------------------------------------');
    PRINT ('Error: View is invalid: ' + @DBName + '.dbo.' + @ViewName + ', error was: ' + @ErrorMessage);
    PRINT ('--------------------------------------------------------------------------------');
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- remove current entry from table to prepare for next
  DELETE TMP
  FROM @Views TMP 
  WHERE TMP.ID = @ID;
END;

-- info
PRINT ('Task - Validate all views done: ' + CONVERT(VARCHAR, GETDATE(), 113));
--*/




--*****************************************************************************
-- TEST 2: Table functions
--*****************************************************************************
--/*
PRINT ('Task - Validate all table functions: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- clear table first
DELETE FROM @DBOWithParameters;

-- fill table
INSERT INTO @DBOWithParameters (DBOName, ParamNULLs)
  SELECT DBOName    = OBJ.name,
         ParamNULLs = PNU.ParamNULLs
  FROM sys.objects OBJ
    LEFT JOIN @ParameterNULLs PNU ON PNU.ID = (SELECT COUNT(1)  
                                               FROM sys.all_parameters PAR
                                               WHERE PAR.object_id = OBJ.object_id)
  WHERE OBJ.type = 'TF'  -- table functions
    AND OBJ.is_ms_shipped = 0
  ORDER BY OBJ.name;

-- count entries
SELECT @TableFunctionsCount = COUNT(1)
FROM @DBOWithParameters;

-- loop all table functions
WHILE ((SELECT COUNT(1) 
        FROM @DBOWithParameters) > 0)
BEGIN
  -- get current entry
  SELECT TOP 1 
         @ID         = TMP.ID,
         @DBOName    = TMP.DBOName,
         @ParamNULLs = TMP.ParamNULLs
  FROM @DBOWithParameters TMP
  ORDER BY TMP.ID ASC;
  
  -----------------------------------------------------------------------------
  -- test table functions and try to get top 1 rows
  -----------------------------------------------------------------------------
  -- info
  PRINT ('°°° Testing: ' + @DBName + '.dbo.' + @DBOName + ': ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  BEGIN TRY
    SET @ExecSQLStatement = 'SELECT TOP 1 * 
                             INTO _Tmp_SQLTests
                             FROM dbo.' + @DBOName + '(' + ISNULL(@ParamNULLs, '') + ');
                             
                             DROP TABLE _Tmp_SQLTests;';
    EXEC sp_executesql @ExecSQLStatement;
  END TRY
  BEGIN CATCH
    -- count up
    SET @InvalidTableFunctionsCounter = @InvalidTableFunctionsCounter + 1;
  
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE();
    
    -- output
    PRINT ('--****--------------------------------------------------------------------------');
    PRINT ('Error: Table Function is invalid: ' + @DBName + '.dbo.' + @DBOName + '(...), error was: ' + @ErrorMessage);
    PRINT ('--------------------------------------------------------------------------------');
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- remove current entry from table to prepare for next
  DELETE TMP
  FROM @DBOWithParameters TMP 
  WHERE TMP.ID = @ID;
END;

-- info
PRINT ('Task - Validate all table functions done: ' + CONVERT(VARCHAR, GETDATE(), 113));
--*/




--*****************************************************************************
-- TEST 3: Scalar functions
--*****************************************************************************
--/*
PRINT ('Task - Validate all scalar functions: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- clear table first
DELETE FROM @DBOWithParameters;

-- fill table
INSERT INTO @DBOWithParameters (DBOName, ParamNULLs)
  SELECT DBOName    = OBJ.name,
         ParamNULLs = PNU.ParamNULLs
  FROM sys.objects OBJ
    LEFT JOIN @ParameterNULLs PNU ON PNU.ID = (SELECT COUNT(1) - 1
                                               FROM sys.all_parameters PAR
                                               WHERE PAR.object_id = OBJ.object_id)
  WHERE OBJ.type = 'FN'  -- scalar functions
    AND OBJ.is_ms_shipped = 0
  ORDER BY OBJ.name;

-- count entries
SELECT @ScalarFunctionsCount = COUNT(1)
FROM @DBOWithParameters;

-- loop all scalar functions
WHILE ((SELECT COUNT(1) 
        FROM @DBOWithParameters) > 0)
BEGIN
  -- get current entry
  SELECT TOP 1 
         @ID         = TMP.ID,
         @DBOName    = TMP.DBOName,
         @ParamNULLs = TMP.ParamNULLs
  FROM @DBOWithParameters TMP
  ORDER BY TMP.ID ASC;
  
  -----------------------------------------------------------------------------
  -- test scalar functions and try to get result
  -----------------------------------------------------------------------------
  -- info
  PRINT ('°°° Testing: ' + @DBName + '.dbo.' + @DBOName + ': ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  BEGIN TRY
    SET @ExecSQLStatement = 'DECLARE @Result VARCHAR(255);
                             SELECT @Result = CONVERT(VARCHAR(255), dbo.' + @DBOName + '(' + ISNULL(@ParamNULLs, '') + '));';
    EXEC sp_executesql @ExecSQLStatement;
  END TRY
  BEGIN CATCH
    -- count up
    SET @InvalidScalarFunctionsCounter = @InvalidScalarFunctionsCounter + 1;
  
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE();
    
    -- output
    PRINT ('--****--------------------------------------------------------------------------');
    PRINT ('Error: Scalar Function is invalid: ' + @DBName + '.dbo.' + @DBOName + '(...), error was: ' + @ErrorMessage);
    PRINT ('--------------------------------------------------------------------------------');
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- remove current entry from table to prepare for next
  DELETE TMP
  FROM @DBOWithParameters TMP 
  WHERE TMP.ID = @ID;
END;

-- info
PRINT ('Task - Validate all scalar functions done: ' + CONVERT(VARCHAR, GETDATE(), 113));
--*/




--*****************************************************************************
-- TEST 4: Stored procedures
--*****************************************************************************
--/*
PRINT ('Task - Validate all stored procedures: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- clear table first
DELETE FROM @DBOWithParameters;

-- fill table
INSERT INTO @DBOWithParameters (DBOName, ParamNULLs)
  SELECT DBOName    = OBJ.name,
         ParamNULLs = PNU.ParamNULLs
  FROM sys.objects OBJ
    LEFT JOIN @ParameterNULLs PNU ON PNU.ID = (SELECT COUNT(1)
                                               FROM sys.all_parameters PAR
                                               WHERE PAR.object_id = OBJ.object_id)
  WHERE OBJ.type = 'P'  -- stored procedures
    AND OBJ.is_ms_shipped = 0
    AND OBJ.name NOT IN ('sp_alterdiagram', 'sp_creatediagram', 'sp_dropdiagram', 'sp_helpdiagramdefinition',
                         'sp_helpdiagrams', 'sp_renamediagram', 'sp_upgraddiagrams',
                         'spXTask_Create') -- gives us some troubles with execution time
  ORDER BY OBJ.name;

-- count entries
SELECT @StoredProceduresCount = COUNT(1)
FROM @DBOWithParameters;

-- loop all stored procedures
WHILE ((SELECT COUNT(1) 
        FROM @DBOWithParameters) > 0)
BEGIN
  -- get current entry
  SELECT TOP 1 
         @ID         = TMP.ID,
         @DBOName    = TMP.DBOName,
         @ParamNULLs = TMP.ParamNULLs
  FROM @DBOWithParameters TMP
  ORDER BY TMP.ID ASC;
  
  -----------------------------------------------------------------------------
  -- test stored procedures and try to get result
  -----------------------------------------------------------------------------
  -- info
  PRINT ('°°° Testing: ' + @DBName + '.dbo.' + @DBOName + ': ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  BEGIN TRY
    -- start transaction to prevent modifiying any data
    BEGIN TRANSACTION;
    
    SET @ExecSQLStatement = 'SET ROWCOUNT 1; -- return only one row back in order to prevent having so much data
                             SET LOCK_TIMEOUT 5000; -- 5000ms waiting for locks
                             EXEC dbo.' + @DBOName + ' ' + ISNULL(@ParamNULLs, '') + ';';
    EXEC sp_executesql @ExecSQLStatement;
    
    -- do rollback
    ROLLBACK TRANSACTION;
  END TRY
  BEGIN CATCH
    -- do rollback
    ROLLBACK TRANSACTION;
    
    -- count up
    SET @InvalidStoredProceduresCounter = @InvalidStoredProceduresCounter + 1;
  
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE();
    
    -- output
    PRINT ('--****--------------------------------------------------------------------------');
    PRINT ('Error: Stored Procedure is invalid: ' + @DBName + '.dbo.' + @DBOName + ', error was: ' + @ErrorMessage);
    PRINT ('--------------------------------------------------------------------------------');
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- remove current entry from table to prepare for next
  DELETE TMP
  FROM @DBOWithParameters TMP 
  WHERE TMP.ID = @ID;
END;

-- info
PRINT ('Task - Validate all stored procedures done: ' + CONVERT(VARCHAR, GETDATE(), 113));
--*/





--*****************************************************************************
-- FINAL: Error handling
--*****************************************************************************
-- setup vars counts to prevent divided by zero error for percent calculations
SET @ViewsCount = CASE 
                    WHEN ISNULL(@ViewsCount, 0) < 1 AND @InvalidViewsCounter > 0 THEN 1 
                    ELSE ISNULL(@ViewsCount, 0) 
                  END;

SET @TableFunctionsCount = CASE 
                             WHEN ISNULL(@TableFunctionsCount, 0) < 1 AND @InvalidTableFunctionsCounter > 0 THEN 1 
                             ELSE ISNULL(@TableFunctionsCount, 0)
                           END;

SET @ScalarFunctionsCount = CASE 
                              WHEN ISNULL(@ScalarFunctionsCount, 0) < 1 AND @InvalidScalarFunctionsCounter > 0 THEN 1 
                              ELSE ISNULL(@ScalarFunctionsCount, 0)
                            END;

SET @StoredProceduresCount = CASE 
                               WHEN ISNULL(@StoredProceduresCount, 0) < 1 AND @InvalidStoredProceduresCounter > 0 THEN 1 
                               ELSE ISNULL(@StoredProceduresCount, 0)
                             END;

-- views
IF (@InvalidViewsCounter > 0)
BEGIN
  -- info
  PRINT ('Caution: Found <' + CONVERT(VARCHAR(20), @InvalidViewsCounter) + '> views with error of total <' + CONVERT(VARCHAR(20), @ViewsCount) + '> views (' + CONVERT(VARCHAR(10), ROUND((CONVERT(FLOAT, @InvalidViewsCounter) / CONVERT(FLOAT, @ViewsCount)) * 100.0, 2)) + '%): ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- raise error to fail on build-server
  RAISERROR ('Error: Not all views are correct', 18, 1);
END
ELSE
BEGIN
  -- info
  PRINT ('Info: All <' + CONVERT(VARCHAR(20), @ViewsCount) + '> views are correct: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;

-- table functions
IF (@InvalidTableFunctionsCounter > 0)
BEGIN
  -- info
  PRINT ('Caution: Found <' + CONVERT(VARCHAR(20), @InvalidTableFunctionsCounter) + '> Table Functions with error of total <' + CONVERT(VARCHAR(20), @TableFunctionsCount) + '> TableFunctions (' + CONVERT(VARCHAR(10), ROUND((CONVERT(FLOAT, @InvalidTableFunctionsCounter) / CONVERT(FLOAT, @TableFunctionsCount)) * 100.0, 2)) + '%): ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- raise error to fail on build-server
  RAISERROR ('Error: Not all Table Functions are correct', 18, 1);
END
ELSE
BEGIN
  -- info
  PRINT ('Info: All <' + CONVERT(VARCHAR(20), @TableFunctionsCount) + '> Table Functions are correct: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;

-- scalar functions
IF (@InvalidScalarFunctionsCounter > 0)
BEGIN
  -- info
  PRINT ('Caution: Found <' + CONVERT(VARCHAR(20), @InvalidScalarFunctionsCounter) + '> Scalar Functions with error of total <' + CONVERT(VARCHAR(20), @ScalarFunctionsCount) + '> ScalarFunctions (' + CONVERT(VARCHAR(10), ROUND((CONVERT(FLOAT, @InvalidScalarFunctionsCounter) / CONVERT(FLOAT, @ScalarFunctionsCount)) * 100.0, 2)) + '%): ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- raise error to fail on build-server
  RAISERROR ('Error: Not all Scalar Functions are correct', 18, 1);
END
ELSE
BEGIN
  -- info
  PRINT ('Info: All <' + CONVERT(VARCHAR(20), @ScalarFunctionsCount) + '> Scalar Functions are correct: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;

-- stored procedures
IF (@InvalidStoredProceduresCounter > 0)
BEGIN
  -- info
  PRINT ('Caution: Found <' + CONVERT(VARCHAR(20), @InvalidStoredProceduresCounter) + '> Stored Procedures with error of total <' + CONVERT(VARCHAR(20), @StoredProceduresCount) + '> StoredProcedures (' + CONVERT(VARCHAR(10), ROUND((CONVERT(FLOAT, @InvalidStoredProceduresCounter) / CONVERT(FLOAT, @StoredProceduresCount)) * 100.0, 2)) + '%): ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- raise error to fail on build-server
  RAISERROR ('Error: Not all Stored Procedures are correct', 18, 1);
END
ELSE
BEGIN
  -- info
  PRINT ('Info: All <' + CONVERT(VARCHAR(20), @StoredProceduresCount) + '> Stored Procedures are correct: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
-- info
PRINT ('Task - Successfully completed checking database <' + @DBName + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
GO

SET NOCOUNT OFF;
GO
