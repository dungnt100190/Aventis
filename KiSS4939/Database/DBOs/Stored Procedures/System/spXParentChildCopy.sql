SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXParentChildCopy;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXParentChildCopy
(
  @TempTableName VARCHAR(100),
  @TableName VARCHAR(100),
  @PrimaryKeyName VARCHAR(100),
  @ParentKeyName VARCHAR(100)  = NULL,
  @FixColumnNames VARCHAR(2000) = NULL,
  @FixColumnValues VARCHAR(2000) = NULL,
  @DBDefaultNames VARCHAR(2000) = NULL
)
AS 
BEGIN
  SET NOCOUNT ON;
  
  SET @FixColumnNames = ISNULL(', ' + @FixColumnNames, '');
  SET @FixColumnValues = ISNULL(', ' + @FixColumnValues, '');

  DECLARE @sql NVARCHAR(4000);
  DECLARE @Columns NVARCHAR(2000);
  
  SET @sql = SUBSTRING(REPLACE(REPLACE(ISNULL(@FixColumnNames, '') + 
                                       ISNULL(', ' + @DBDefaultNames, ''), ' ', ''), ',', ''', '''), 2, 4000);
  
  IF (@sql != '')
  BEGIN
    SET @sql = @sql + '''';
  END;
  
  DECLARE @ColumnName VARCHAR(100);
  
  SET @sql = 'DECLARE curTableColumn CURSOR FAST_FORWARD FOR
    SELECT ''['' + col.name + '']'' AS FieldName
    FROM syscolumns     col
    WHERE col.id = object_id(''' + @TableName + ''')
      AND col.name NOT IN (''' + @PrimaryKeyName + '''' + ISNULL(', ''' + @ParentKeyName + '''', '') + @sql + ')
      AND col.xtype != 189';     -- timestamp
  
  EXECUTE (@sql);

  SET @Columns = '';

  OPEN curTableColumn;
  WHILE (1 = 1)
  BEGIN
    FETCH NEXT 
    FROM curTableColumn 
    INTO @ColumnName;

    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;
    
    SET @Columns = @Columns + ', ' + @ColumnName;
  END;
  
  CLOSE curTableColumn;
  DEALLOCATE curTableColumn;
  
  SET @sql = 'SET NOCOUNT ON' + CHAR(13) + CHAR(10) +
             'ALTER TABLE ' + @TempTableName + ' ADD Updated BIT';
  EXECUTE (@sql);

  SET @sql = 'UPDATE TMP' + CHAR(13) + CHAR(10) +
             'SET TMP.Parent = NULL ' + CHAR(13) + CHAR(10) +
             'FROM ' + @TempTableName + ' TMP' + CHAR(13) + CHAR(10) +
             'WHERE TMP.Parent IS NOT NULL AND NOT EXISTS (SELECT TOP 1 1 FROM ' + @TempTableName + ' WHERE Pk = TMP.Parent)';
  EXECUTE (@sql);
  
  EXECUTE ('UPDATE ' + @TempTableName + ' SET Updated = 0');
  
  WHILE (@@ROWCOUNT > 0)
  BEGIN
    DECLARE @Pk INT;
    DECLARE @KeyNew INT;
    DECLARE @ParentNew INT;
    DECLARE @sql_NewRow NVARCHAR(4000);
    DECLARE @sql_ReplaceRow NVARCHAR(4000)
    
    SET @sql = 'DECLARE curParentChildCopy CURSOR FAST_FORWARD FOR
      SELECT REC.Pk, REC.KeyNew, PAR.KeyNew
      FROM ' + @TempTableName + ' REC
        LEFT JOIN ' + @TempTableName + ' PAR ON REC.Parent = PAR.Pk
      WHERE REC.Pk IS NOT NULL AND REC.Updated = 0
        AND (REC.Parent IS NULL OR PAR.KeyNew IS NOT NULL)
      ORDER BY REC.Pk';
    EXECUTE (@sql);

    OPEN curParentChildCopy

    -- Prepare SQL Statments
    IF (@ParentKeyName IS NULL)
    BEGIN
      SET @sql = 'INSERT INTO [' + @TableName + '] (' + SUBSTRING(@FixColumnNames + @Columns, 2, 4000) + ')' + CHAR(13) + CHAR(10) +
                 '  SELECT ' + SUBSTRING(@FixColumnValues + @Columns, 2, 4000) + CHAR(13);
    END 
    ELSE 
    BEGIN
      SET @sql = 'INSERT INTO [' + @TableName + '] (' + @ParentKeyName + @FixColumnNames + @Columns + ')' + CHAR(13) + CHAR(10) +
                 '  SELECT IsNull(@ParentNew, NULL) ' + @FixColumnValues + @Columns;
    END;
    
    SET @sql_NewRow = @sql + CHAR(13) + CHAR(10) +
                          '  FROM [' + @TableName + ']' + CHAR(13) + CHAR(10) +
                          '  WHERE ' + @PrimaryKeyName + ' = @Pk' + CHAR(13) + CHAR(10) +
                          
                          'UPDATE ' + @TempTableName + CHAR(13) + CHAR(10) +
                          '  SET Updated = 1, KeyNew = @@IDENTITY' + CHAR(13) + CHAR(10) +
                          'WHERE Pk = @Pk';
    
    IF (@ParentKeyName IS NULL)
    BEGIN
      SET @sql = 'INSERT INTO [' + @TableName + '] (' + @PrimaryKeyName + ', ' + SUBSTRING(@FixColumnNames + @Columns, 2, 4000) + ')' + CHAR(13) + CHAR(10) +
                 '  SELECT @KeyNew, ' + SUBSTRING(@FixColumnValues + @Columns, 2, 4000) + CHAR(13) + CHAR(10);
    END 
    ELSE
    BEGIN
      SET @sql = 'INSERT INTO [' + @TableName + '] (' + @PrimaryKeyName + ', ' + @ParentKeyName + @FixColumnNames + @Columns + ')' + CHAR(13) + CHAR(10) +
                 '  SELECT @KeyNew, IsNull(@ParentNew, NULL) ' + @FixColumnValues + @Columns;
    END
    
    SET @sql_ReplaceRow = 'DELETE FROM [' + @TableName + '] WHERE ' + @PrimaryKeyName + ' = @KeyNew;' + CHAR(13) + CHAR(10) +
                          
                          'SET IDENTITY_INSERT ' + @TableName + ' ON;' + CHAR(13) + CHAR(10) +
                          
                          @sql + CHAR(13) + CHAR(10) +
                          '  FROM [' + @TableName + ']' + CHAR(13) + CHAR(10) +
                          '  WHERE ' + @PrimaryKeyName + ' = @Pk' + CHAR(13) + CHAR(10) +
                          
                          'SET IDENTITY_INSERT ' + @TableName + ' OFF;' + CHAR(13) + CHAR(10) +

                          'UPDATE ' + @TempTableName + CHAR(13) + CHAR(10) +
                          'SET Updated = 1' + CHAR(13) + CHAR(10) +
                          'WHERE Pk = @Pk;';
    
    WHILE (1 = 1)
    BEGIN
      FETCH NEXT 
      FROM curParentChildCopy 
      INTO @Pk, @KeyNew, @ParentNew;
      
      IF (@@FETCH_STATUS != 0)
      BEGIN
        BREAK;
      END;
      
      IF (@KeyNew IS NULL)
      BEGIN
        EXECUTE sp_executesql @sql_NewRow, N'@Pk INT, @KeyNew INT, @ParentNew INT', @Pk, @KeyNew, @ParentNew;
      END 
      ELSE 
      BEGIN
        EXECUTE sp_executesql @sql_ReplaceRow, N'@Pk INT, @KeyNew INT, @ParentNew INT', @Pk, @KeyNew, @ParentNew;
      END;
    END;
    
    CLOSE curParentChildCopy;
    DEALLOCATE curParentChildCopy;
    
    EXECUTE ('UPDATE ' + @TempTableName + ' SET Updated = 0 WHERE Pk IS NOT NULL AND Updated = 0;');
  END;
  
  EXECUTE ('ALTER TABLE ' + @TempTableName + ' DROP COLUMN Updated;')
END
GO