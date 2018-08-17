/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create or update the XLangText entries from the table _Tmp_Translate
           and set the TID column on the referenced tabel

  TEST:    1. Export the translations with Export_XLangText.sql
           2. Create the insert into _Tmp_Translate script with dbUtil
           3. Import the translations with this script
=================================================================================================*/

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @TmpTranslateID INT;
DECLARE @SchemaName    VARCHAR(255);
DECLARE @TableName     VARCHAR(255);
DECLARE @ColumnIdName  VARCHAR(255);
DECLARE @ColumnId2Name VARCHAR(255);
DECLARE @TableID       SQL_VARIANT;
DECLARE @TableID2      SQL_VARIANT;
DECLARE @ColumnTidName VARCHAR(255);
DECLARE @TID           INT;
DECLARE @Original      VARCHAR(MAX);
DECLARE @DE            VARCHAR(MAX);
DECLARE @FR            VARCHAR(MAX);
DECLARE @IT            VARCHAR(MAX);
DECLARE @SqlExec VARCHAR(MAX);

DECLARE @TempTable TABLE
(
  ID INT IDENTITY(1,1) NOT NULL,
  TmpTranslateID INT,
  SchemaName     VARCHAR(255),
  TableName      VARCHAR(255),
  ColumnIdName   VARCHAR(255),
  ColumnId2Name  VARCHAR(255),
  TableID        SQL_VARIANT NOT NULL,
  TableID2       SQL_VARIANT,
  ColumnTidName  VARCHAR(255),
  Original       VARCHAR(MAX),
  DE             VARCHAR(MAX),
  FR             VARCHAR(MAX),
  IT             VARCHAR(MAX)
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (TmpTranslateID, SchemaName, TableName, ColumnIdName, ColumnId2Name, TableID, TableID2, ColumnTidName, Original, DE, FR, IT)
  SELECT ID, SchemaName, TableName, ColumnIdName, ColumnId2Name, TableID, TableID2, ColumnTidName, Original, DE, FR, IT
  FROM dbo._Tmp_Translate
  WHERE (FR IS NOT NULL
    OR  IT IS NOT NULL
    OR  DE <> Original)

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

SET NOCOUNT ON;

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @TmpTranslateID = TmpTranslateID, 
         @SchemaName     = SchemaName,
         @TableName      = TableName, 
         @ColumnIdName   = ColumnIdName, 
         @ColumnId2Name  = ColumnId2Name, 
         @TableID        = TableID, 
         @TableID2       = TableID2, 
         @ColumnTidName  = ColumnTidName, 
         @Original       = Original, 
         @DE             = DE, 
         @FR             = FR, 
         @IT             = IT
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  

  --- 
-- FrmToCtl correction falls nötig
---

IF (EXISTS(SELECT TOP 1 1 
           FROM sys.tables
           WHERE name = 'MigXClassFrmToCtl'))
BEGIN           
  UPDATE TPT
  SET TPT.TableID = MXCFTC.ControlName
  FROM @TempTable TPT
  INNER JOIN MigXClassFrmToCtl MXCFTC ON MXCFTC.FormName = TPT.TableID;
END


  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  SET @SqlExec = '
  DECLARE @TID INT;
  DECLARE @Text VARCHAR(2000);
  
  SELECT @TID = T.<ColumnTidName>
  FROM <SchemaName>.<TableName> T
  WHERE T.<ColumnIdName> = <TableID>
    AND T.<ColumnId2Name> = <TableID2>;

  SET @Text = NULLIF(''<DE>'', '''');
  IF (@Text IS NOT NULL)
  BEGIN
    EXEC dbo.spXSetXLangText @TID, 1, @Text, NULL, NULL, NULL, NULL, @TID OUT
  END
    
  SET @Text = NULLIF(''<FR>'', '''');
  IF (@Text IS NOT NULL)
  BEGIN
    EXEC dbo.spXSetXLangText @TID, 2, @Text, NULL, NULL, NULL, NULL, @TID OUT
  END
    
  SET @Text = NULLIF(''<IT>'', '''');
  IF (@Text IS NOT NULL)
  BEGIN
    EXEC dbo.spXSetXLangText @TID, 3, @Text, NULL, NULL, NULL, NULL, @TID OUT
  END
  
  UPDATE <SchemaName>.<TableName>
    SET <ColumnTidName> = @TID
  WHERE <ColumnIdName> = <TableID>
    AND <ColumnId2Name> = <TableID2>;
    
  --PRINT (''Info: <TableName>.<ColumnTidName> übersetzt'');
  ';
  
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnTidName>', @ColumnTidName);
  SET @SqlExec = REPLACE(@SqlExec, '<SchemaName>', @SchemaName);
  SET @SqlExec = REPLACE(@SqlExec, '<TableName>', @TableName);
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnIdName>', @ColumnIdName);
  IF (ISNUMERIC(CONVERT(VARCHAR(MAX), @TableID)) = 1)
  BEGIN
    SET @SqlExec = REPLACE(@SqlExec, '<TableID>', CONVERT(VARCHAR(MAX), @TableID));
  END
  ELSE
  BEGIN
    SET @SqlExec = REPLACE(@SqlExec, '<TableID>', '''' + CONVERT(VARCHAR(MAX), @TableID) + '''');
  END;
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnId2Name>', ISNULL(@ColumnId2Name, @ColumnIdName));
  IF (ISNUMERIC(CONVERT(VARCHAR(MAX), @TableID)) = 1)
  BEGIN
    SET @SqlExec = REPLACE(@SqlExec, '<TableID2>', CONVERT(VARCHAR(MAX), ISNULL(@TableID2, @TableID)));
  END
  ELSE
  BEGIN
    SET @SqlExec = REPLACE(@SqlExec, '<TableID2>', '''' + CONVERT(VARCHAR(MAX), ISNULL(@TableID2, @TableID)) + '''');
  END;
    
  SET @SqlExec = REPLACE(@SqlExec, '<DE>', ISNULL(REPLACE(@DE, '''', ''''''), ''));
  SET @SqlExec = REPLACE(@SqlExec, '<FR>', ISNULL(REPLACE(@FR, '''', ''''''), ''));
  SET @SqlExec = REPLACE(@SqlExec, '<IT>', ISNULL(REPLACE(@IT, '''', ''''''), ''));

  --PRINT (@SqlExec);
  PRINT ('Info: ' + @TableName + '.' + @ColumnTidName + ' mit ID ' + CONVERT(VARCHAR(MAX), @TableID) + CASE WHEN @TableID2 IS NOT NULL THEN ', ' + CONVERT(VARCHAR(MAX), @TableID2) ELSE '' END + ' übersetzt');
  EXEC(@SqlExec);
  
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

SET NOCOUNT OFF;
