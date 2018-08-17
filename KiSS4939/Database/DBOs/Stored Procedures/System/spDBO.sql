SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spDBO;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Show the dbo definition (columns, additional data, code) for given dbo name
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: - Tables/Views: 
                   - 0 = default (both: table and columns)
                   - 1 = only table
                   - 2 = only columns
                   - 3 = print columns as DECLARE for vars instead of description content
                 - Others:
                   - 0 = default (print output)
                   - 1 = output of definition as select
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Shows the definition of the object and returns 0 on success, 1 on failure
=================================================================================================
  TEST:    EXEC dbo.spDBO 'BaPerson';
           EXEC dbo.spDBO 'BaPerson', NULL, 'U';
           EXEC dbo.spDBO 'XUser', NULL;
           EXEC dbo.spDBO 'XProfileTag', NULL;
           --
           EXEC dbo.spDBO 'fnDateOf', 1;
           EXEC dbo.spDBO 'fnDateOf', 0;
           --
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 1;
           EXEC dbo.spDBO 'spKbWVEinzelpostenGenerieren', 0;
=================================================================================================*/

CREATE PROCEDURE dbo.spDBO
(
  @DBOName VARCHAR(200),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;

  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  
  -- constants
  DECLARE @DEBUGLEVEL INT;
  SET @DEBUGLEVEL = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE/VIEW:
  -- ==========================================================================
  IF (@DBOType IN ('U', 'V'))
  BEGIN
    ---------------------------------------------------------------------------
    -- init temporary table for description
    ---------------------------------------------------------------------------
    DECLARE @TmpDescription TABLE
    (
      TableName VARCHAR(255) NOT NULL,
      ColumnName VARCHAR(255),
      PropertyName VARCHAR(255),
      PropertyValue VARCHAR(2000)
    );
    
    -----------------------------------------------------------------------------
    -- get description for given table
    -----------------------------------------------------------------------------
    -- fill data
    INSERT INTO @TmpDescription (TableName, ColumnName, PropertyName, PropertyValue)
      SELECT TableName     = OBJECT_NAME(EXT.major_id),
             ColumnName    = COL.Name,
             PropertyName  = EXT.Name,
             PropertyValue = CONVERT(VARCHAR(2000), EXT.value)
      FROM sys.extended_properties EXT
        LEFT JOIN sys.columns      COL ON COL.OBJECT_ID = EXT.major_id 
                                      AND COL.column_id = EXT.minor_id
      WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
        AND EXT.major_id = @DBOObjectID                                 -- only for current dbo
        AND EXT.Name IN ('MS_Description', 'Author', 'Used_In', 'NamespaceExtension');
    
    -----------------------------------------------------------------------------
    -- show table information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 1) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT [TableName]           = @DBOName,
             [Author]              = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Author'),
             [UsedIn]              = (SELECT TMP.PropertyValue
                                     FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'Used_In'),
             [Description]         = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'MS_Description'),
             [ColumnsCount]        = (SELECT COUNT(1)
                                      FROM sys.columns
                                      WHERE object_id = @DBOObjectID),
             [NamespaceExtension]  = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName IS NULL
                                        AND TMP.PropertyName = 'NamespaceExtension');
    END;
    
    -----------------------------------------------------------------------------
    -- show table-column information
    -----------------------------------------------------------------------------
    IF (@OutputMode IN (0, 2) OR @OutputMode < 0 OR @OutputMode > 2)
    BEGIN
      SELECT ColumnName           = COL.name,
             DataType             = UPPER(TYP.name),
             [Length]             = CASE
                                      WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                      ELSE CONVERT(VARCHAR(20), COL.max_length)
                                    END,
             NotNull              = CASE COL.is_nullable 
                                      WHEN 1 THEN ''
                                      ELSE 'x'
                                    END,
             DefaultValue         = REPLACE(REPLACE(ISNULL((DEF.Text), ''), '((0))', '0'), '(0)', '0'),
             PrimaryKey           = ISNULL((SELECT CASE SKEY.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.key_constraints       SKEY
                                              INNER JOIN sys.index_columns SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                                               AND SIXC.index_id = SKEY.unique_index_id
                                                                               AND SIXC.column_id = COL.column_id
                                            WHERE SKEY.type = 'PK'
                                              AND SKEY.parent_object_id = COL.object_id), ''), 
             [Identity]           = CASE COL.is_identity
                                      WHEN 1 THEN 'x'
                                      ELSE ''
                                    END,
             ForeignKey           = ISNULL((SELECT DISTINCT -- used for multiple FKs
                                                   CASE SCOL.name 
                                                     WHEN NULL THEN '' 
                                                     ELSE 'x' 
                                                   END
                                            FROM sys.foreign_key_columns SFKC
                                              INNER JOIN sys.columns     SCOL ON SCOL.object_id = COL.object_id
                                                                             AND SCOL.column_id = COL.column_id
                                                                             AND SCOL.column_id = SFKC.parent_column_id
                                            WHERE SFKC.parent_object_id = COL.object_id), ''),
             [Description]        = CASE @OutputMode
                                      WHEN 3 THEN -- output as var declaration
                                                  'DECLARE @' + COL.name + ' ' + 
                                                  CASE
                                                    WHEN TYP.name IN ('DECIMAL', 'NUMERIC')
                                                      THEN UPPER(TYP.name) + '(x, y);  -- TODO: set x, y'
                                                    WHEN TYP.name IN ('FLOAT', 'VARCHAR', 'CHAR', 'NVARCHAR', 'NCHAR', 'BINARY', 'VARBINARY')
                                                      THEN UPPER(TYP.name) + '(' + CASE
                                                                                     WHEN TYP.name LIKE '%CHAR' AND COL.max_length = -1 THEN 'MAX'
                                                                                     ELSE CONVERT(VARCHAR(20), COL.max_length)
                                                                                   END + ');'
                                                    WHEN TYP.name = 'TEXT'      THEN 'VARCHAR(MAX);'  + '  -- original as "TEXT"'
                                                    WHEN TYP.name = 'NTEXT'     THEN 'NVARCHAR(MAX);' + '  -- original as "NTEXT"'
                                                    WHEN TYP.name = 'TIMESTAMP' THEN 'BINARY(8);'     + '  -- original as "TIMESTAMP"'
                                                    ELSE UPPER(TYP.name) + ';'
                                                  END
                                      ELSE (SELECT TMP.PropertyValue
                                            FROM @TmpDescription TMP
                                            WHERE TMP.ColumnName = COL.[Name] 
                                              AND TMP.PropertyName = 'MS_Description')
                                    END,
             [NamespaceExtension] = (SELECT TMP.PropertyValue
                                      FROM @TmpDescription TMP
                                      WHERE TMP.ColumnName = COL.[Name] 
                                        AND TMP.PropertyName = 'NamespaceExtension')
      FROM sys.columns         COL
        INNER JOIN sys.types   TYP ON TYP.system_type_id = COL.system_type_id
        LEFT  JOIN syscomments DEF ON DEF.id = COL.default_object_id
      WHERE COL.object_id = @DBOObjectID
      ORDER BY COL.column_id;
    END;

    -- return value
    RETURN CASE @@ROWCOUNT 
             WHEN 0 THEN 1 
             ELSE 0 
           END;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- FUNCTION/STOREDPROCEDURE/TRIGGER/CONSTRAINT:
  -- ==========================================================================
  IF (@DBOType IN ('FN', 'IF', 'TF', 'P', 'TR', 'C', 'D'))
  BEGIN
    -- init vars
    DECLARE @DBODefinition VARCHAR(MAX);
    
    -- get definition
    SET @DBODefinition = ISNULL(OBJECT_DEFINITION(OBJECT_ID(@DBOName)), '>>> Error: Could not get object definition of "' + @DBOName + '" with type "' + @DBOType + '"');
    
    IF (@OutputMode = 1)
    BEGIN
      -- output definiton within SELECT statement
      SELECT [DBOName]    = @DBOName,
             [Length]     = LEN(@DBODefinition),
             [Definition] = @DBODefinition;
    END
    ELSE
    BEGIN
      -- init vars
      DECLARE @DBODefLength BIGINT;
      DECLARE @DBODefCharAtNewLine BIGINT;
            
      -- print can handle only 8000 chars, so we need to check that
      IF (LEN(@DBODefinition) < 8000)
      BEGIN
        -- print out directly
        PRINT (@DBODefinition);
      END
      ELSE
      BEGIN
        -- print out in multiple steps
        WHILE (LEN(@DBODefinition) > 0)
        BEGIN
          -- get position of next newline to have proper text output
          SET @DBODefCharAtNewLine = CHARINDEX(CHAR(10), SUBSTRING(@DBODefinition, 1, 8000), 6000);
         
          IF (@DBODefCharAtNewLine < 1)
          BEGIN
            -- no newline, take max output
            SET @DBODefCharAtNewLine = 8000;
          END;
          
          -- print out first part of chars
          PRINT (SUBSTRING(@DBODefinition, 1, @DBODefCharAtNewLine));
          SET @DBODefLength = LEN(@DBODefinition);
          
          -- cut first part of chars
          IF (@DBODefLength > @DBODefCharAtNewLine)
          BEGIN
            SET @DBODefinition = SUBSTRING(@DBODefinition, @DBODefCharAtNewLine, @DBODefLength - @DBODefCharAtNewLine);
          END
          ELSE
          BEGIN
            SET @DBODefinition = '';
          END;
        END;
      END;
    END;
    
    -- success
    RETURN 0;
  END;
  -- ==========================================================================
  
  
  
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported')
  
  -- failure
  RETURN 1;
  -- ==========================================================================
END;
GO