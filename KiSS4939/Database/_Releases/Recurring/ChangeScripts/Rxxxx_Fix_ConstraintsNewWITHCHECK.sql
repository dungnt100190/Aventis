/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to fix constrainst created WITH NOCHECK to WITH CHECK.
           Reason:
           Constraints defined WITH NOCHECK are not considered by the query optimizer. These 
           constraints are ignored until all such constraints are re-enabled.
           
           See: http://msdn.microsoft.com/en-us/library/aa275462(v=sql.80).aspx
           
           Hint: Use "DBCC CHECKCONSTRAINTS (table_name)" to validate only
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TableName VARCHAR(1000);
DECLARE @ConstraintName VARCHAR(1000);
DECLARE @SQLStatement NVARCHAR(4000);
DECLARE @ErrorMessage VARCHAR(8000);
DECLARE @ErrorCount INT;

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(1000) NOT NULL,
  ConstraintName VARCHAR(1000) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ConstraintName)
  SELECT TableName      = OBJECT_NAME(parent_object_id),
         ConstraintName = name
  FROM sys.foreign_keys
  WHERE is_not_trusted = 1
    AND is_disabled = 0
  ORDER BY TableName, ConstraintName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table
SET @ErrorCount = 0;

-- info
PRINT ('Info: Found "' + CONVERT(VARCHAR(50), @EntriesCount) + '" invalid constraints');

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName      = TMP.TableName,
         @ConstraintName = TMP.ConstraintName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- try to fix constraint
  -----------------------------------------------------------------------------
  BEGIN TRANSACTION;
  
  BEGIN TRY
    -- try to fix constraint here
    SET @SQLStatement = 'ALTER TABLE [dbo].[' + @TableName + '] WITH CHECK CHECK CONSTRAINT [' + @ConstraintName + '];';
    EXECUTE sp_executesql @SQLStatement;
    
    -- save
    COMMIT TRANSACTION;
    
    -- done
    PRINT ('Info: Successfully fixed table "' + @TableName + '" and constraint "' + @ConstraintName + '".');
  END TRY
  BEGIN CATCH
    -- undo
    ROLLBACK TRANSACTION;
    
    -- set error part
    SET @ErrorMessage = 'Warning: Could not fix table "' + @TableName + '" and constraint "' + @ConstraintName + '". Database error was: ' + ISNULL(ERROR_MESSAGE(), '<error?>');
    SET @ErrorCount = @ErrorCount + 1;

    -- show message and continue
    PRINT (@ErrorMessage);
  END CATCH;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-- info
PRINT ('Info: Having now "' + CONVERT(VARCHAR(50), @ErrorCount) + '" invalid constraints after fixing');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO