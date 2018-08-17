/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select all columns ('%TID%') of USER_TABLE that are not PK or FK
           and to export these XLangText entries into the table _Tmp_Translate

  TEST:    1. Export the translations with this script
           2. Create the insert into _Tmp_Translate script with dbUtil
           3. Import the translations with Import_XLangText.sql
=================================================================================================*/

DECLARE @DropTmpTableIfExists BIT;

SET @DropTmpTableIfExists = 1;

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @SchemaName VARCHAR(255);
DECLARE @TableName VARCHAR(255);
DECLARE @ColumnIdName VARCHAR(255);
DECLARE @ColumnId2Name VARCHAR(255);
DECLARE @ColumnTidName VARCHAR(255);
DECLARE @ColumnOriginalTextName VARCHAR(255);
DECLARE @SqlExec VARCHAR(MAX);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  SchemaName VARCHAR(255),
  TableName VARCHAR(255),
  ColumnIdName VARCHAR(255),
  ColumnId2Name VARCHAR(255),
  ColumnTidName VARCHAR(255),
  ColumnOriginalTextName VARCHAR(255)
);


IF(@DropTmpTableIfExists = 1
  AND EXISTS(SELECT TOP 1 1 
             FROM sys.tables
             WHERE name = '_Tmp_Translate'))
BEGIN 
  DROP TABLE _Tmp_Translate;
  PRINT ('Warning: Table _Tmp_Translate has been dropped');
END;

IF (EXISTS(SELECT TOP 1 1 
           FROM sys.tables
           WHERE name = '_Tmp_Translate'))
BEGIN
  PRINT ('Warning: Table _Tmp_Translate already exists');
END
ELSE
BEGIN
  CREATE TABLE _Tmp_Translate
  (
    ID INT IDENTITY (1, 1) NOT NULL,
    SchemaName    VARCHAR(255),
    TableName     VARCHAR(255),
    ColumnIdName  VARCHAR(255),
    ColumnId2Name VARCHAR(255),
    TableID       SQL_VARIANT NOT NULL,
    TableID2      SQL_VARIANT,
    ColumnTidName VARCHAR(255),
    TID           INT NOT NULL,
    Original      VARCHAR(MAX),
    DE            VARCHAR(MAX),
    FR            VARCHAR(MAX),
    IT            VARCHAR(MAX)
  );
END;

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (SchemaName, TableName, ColumnIdName, ColumnId2Name, ColumnTidName, ColumnOriginalTextName)
  SELECT 
    SchemaName    = SCH.name,
    TableName     = OBJ.Name, 
    ColumnIdName  = CPK.Name, 
    ColumnId2Name = CPK2.Name, 
    ColumnTidName = COL.Name, 
    ColumnOriginalTextName = COL1.Name
  FROM sys.columns COL
    INNER JOIN sys.objects OBJ ON OBJ.object_id = COL.object_id
    INNER JOIN sys.schemas SCH WITH (READUNCOMMITTED) ON SCH.schema_id = OBJ.schema_id
    LEFT JOIN sys.columns COL1 ON COL1.object_id = COL.object_id -- orininal Spalte gleichen Name ohne TID
                              AND (COL1.Name = SUBSTRING(COL.Name, 1, LEN(COL.Name)-3)
                                OR (OBJ.Name = 'XMenuItem' AND COL1.Name = 'Caption')
                                OR (OBJ.Name = 'XMessage' AND COL1.Name = 'MessageName')
                                )
    OUTER APPLY (SELECT TOP 1 COLPK.Name, IC.column_id
                 FROM sys.key_constraints       KC
                   INNER JOIN sys.index_columns IC    ON IC.object_id = KC.parent_object_id
                                                     AND IC.index_id = KC.unique_index_id
                   INNER JOIN sys.columns       COLPK ON COLPK.object_id = COL.object_id
                                                     AND COLPK.column_id = IC.column_id
                 WHERE KC.type = 'PK'
                   AND KC.parent_object_id = COL.object_id) CPK
    OUTER APPLY (SELECT TOP 1 COLPK2.Name, IC2.column_id
                 FROM sys.key_constraints       KC2
                   INNER JOIN sys.index_columns IC2    ON IC2.object_id = KC2.parent_object_id
                                                      AND IC2.index_id = KC2.unique_index_id
                   INNER JOIN sys.columns       COLPK2 ON COLPK2.object_id = COL.object_id
                                                      AND COLPK2.column_id = IC2.column_id
                                                      AND COLPK2.column_id <> CPK.column_id
                 WHERE KC2.type = 'PK'
                   AND KC2.parent_object_id = COL.object_id) CPK2
  WHERE COL.name LIKE '%TID%'
    AND NOT EXISTS(SELECT TOP 1 1
                   FROM sys.key_constraints SKEY
                     INNER JOIN sys.index_columns SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                      AND SIXC.index_id = SKEY.unique_index_id
                                                      AND SIXC.column_id = COL.column_id
                   WHERE SKEY.type = 'PK'
                     AND SKEY.parent_object_id = COL.object_id)
    AND NOT EXISTS(SELECT TOP 1 1
                   FROM sys.foreign_key_columns FKC
                   WHERE FKC.parent_object_id = COL.object_id
                     AND FKC.parent_column_id = COL.column_id)
    AND COL.Name NOT IN ('AdressatID', 'OldUnitID', 'ProduktID', 'BgPositionsartID_CopyOf', 'KostenstelleOrgUnitID', 'KESBDocumentID', 'FlKostenartID')
    AND COL.Name NOT LIKE 'XDocumentID%'
    AND COL.Name NOT LIKE 'DocumentID%'
    AND COL.Name NOT LIKE 'DokumentID%'
    AND OBJ.Name NOT LIKE 'Hist_%'
    AND OBJ.Name NOT LIKE '_Old_%'
    AND OBJ.Name NOT LIKE '_Tmp_%'
    AND OBJ.[type] IN ('U') -- user table
  ORDER BY OBJ.Name, COL.Name;

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
  SELECT @SchemaName    = TMP.SchemaName,
         @TableName     = TMP.TableName,
         @ColumnIdName  = TMP.ColumnIdName,
         @ColumnId2Name = TMP.ColumnId2Name,
         @ColumnTidName = TMP.ColumnTidName,
         @ColumnOriginalTextName = TMP.ColumnOriginalTextName
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  --SELECT SchemaName = TMP.SchemaName,
  --       TableName  = TMP.TableName,
  --       ColumnIdName = TMP.ColumnIdName,
  --       ColumnId2Name = TMP.ColumnId2Name,
  --       ColumnTidName = TMP.ColumnTidName,
  --       ColumnOriginalTextName = TMP.ColumnOriginalTextName
  --FROM @TempTable TMP
  --WHERE TMP.ID = @EntriesIterator;

  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  SET @SqlExec = '
  INSERT INTO _Tmp_Translate
  SELECT 
    SchemaName    = ''<SchemaName>'',
    TableName     = ''<TableName>'', 
    ColumnIdName  = ''<ColumnIdName>'',
    ColumnId2Name = NULLIF(''<ColumnId2Name>'', ''''),
    TableID       = T.<ColumnIdName>,
    TableID2      = T.<ColumnId2Name>,
    ColumnTidName = ''<ColumnTidName>'',
    TID           = T.<ColumnTidName>,
    Original      = T.<ColumnOriginalTextName>,
    DE            = LAN1.Text,
    FR            = LAN2.Text,
    IT            = LAN3.Text
    --, *
  FROM <SchemaName>.<TableName> T WITH (READUNCOMMITTED)
    LEFT JOIN dbo.XLangText LAN1 WITH (READUNCOMMITTED) ON LAN1.TID = T.<ColumnTidName> AND LAN1.LanguageCode = 1
    LEFT JOIN dbo.XLangText LAN2 WITH (READUNCOMMITTED) ON LAN2.TID = T.<ColumnTidName> AND LAN2.LanguageCode = 2
    LEFT JOIN dbo.XLangText LAN3 WITH (READUNCOMMITTED) ON LAN3.TID = T.<ColumnTidName> AND LAN3.LanguageCode = 3
  WHERE T.<ColumnTidName> IS NOT NULL
    AND COALESCE(LAN1.Text, LAN2.Text, LAN3.Text) IS NOT NULL;
    
  PRINT (''Info: '' + CONVERT(VARCHAR, @@ROWCOUNT) + REPLICATE('' '', 8-LEN(CONVERT(VARCHAR, @@ROWCOUNT))) + ''<TableName>.<ColumnTidName> übersetzt'');
  ';
  
  SET @SqlExec = REPLACE(@SqlExec, '<SchemaName>', @SchemaName);
  SET @SqlExec = REPLACE(@SqlExec, '<TableName>', @TableName);
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnIdName>', @ColumnIdName);
  SET @SqlExec = REPLACE(@SqlExec, 'T.<ColumnId2Name>', ISNULL('T.' + @ColumnId2Name, 'NULL'));
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnId2Name>', ISNULL(@ColumnId2Name, ''));
  SET @SqlExec = REPLACE(@SqlExec, '<ColumnTidName>', @ColumnTidName);
  SET @SqlExec = REPLACE(@SqlExec, 'T.<ColumnOriginalTextName>', ISNULL('T.' + @ColumnOriginalTextName, 'NULL'));

  
  --PRINT (@SqlExec);
  EXEC(@SqlExec);
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;


SELECT *         
FROM _Tmp_Translate
WHERE FR IS NOT NULL
  OR  IT IS NOT NULL
  OR  DE <> Original

SET NOCOUNT OFF;
