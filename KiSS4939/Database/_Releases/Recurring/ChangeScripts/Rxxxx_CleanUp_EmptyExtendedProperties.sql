/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to cleanup empty extended properties (no content in value or '(null)')
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
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnName VARCHAR(255);
DECLARE @PropertyName VARCHAR(255);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  TableName VARCHAR(255) NOT NULL,
  ColumnName VARCHAR(255),
  PropertyName VARCHAR(255) NOT NULL
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TableName, ColumnName, PropertyName)
  SELECT TableName     = OBJECT_NAME(EXT.major_id), 
         ColumnName    = COL.name,
         PropertyName  = EXT.name
  FROM sys.extended_properties EXT
    LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                  AND COL.column_id = EXT.minor_id
  WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
    AND EXT.name <> 'microsoft_database_tools_support'
    AND ISNULL(EXT.value, '') IN ('', '(null)')
  ORDER BY TableName, 
           ColumnName, 
           CASE 
             WHEN EXT.name = 'MS_Description' THEN 0 
             ELSE 1 
           END, 
           PropertyName;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TableName    = TMP.TableName,
         @ColumnName   = TMP.ColumnName,
         @PropertyName = TMP.PropertyName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- drop extended property
  -----------------------------------------------------------------------------
  EXEC dbo.spXExtendedProperty @TableName, @ColumnName, @PropertyName, '_delete_', 0, 1;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO