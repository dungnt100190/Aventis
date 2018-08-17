SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXHistoryVersion
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXHistoryVersion
 (@TableName   sysname,
  @History     bit = 1)
AS BEGIN
  SET NOCOUNT ON

  DECLARE @SQL         varchar(8000),
          @sql2        varchar(2000),
          @ColumnName  sysname,
          @FieldType   varchar(200),
          @PrimaryKey  bit,
          @AutoValue   bit

  -- Add Verion to Current Table
  IF NOT EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID(@TableName) AND Name = 'VerID') BEGIN
    SET @SQL = 'ALTER TABLE [' + @TableName + '] ADD VerID int NULL'
    PRINT @SQL + char(13) + char(10) + 'G' + 'O'
    EXECUTE (@SQL)
  END

  IF OBJECT_ID('trHist_' + @TableName) IS NOT NULL  BEGIN
    SET @SQL = 'DROP TRIGGER [trHist_' + @TableName + ']'
    PRINT @SQL + char(13) + char(10) + 'G' + 'O'
    EXECUTE (@SQL)
  END

  SET @SQL = 'UPDATE [' + @TableName + '] SET VerID = 1 WHERE VerID IS NULL'
  PRINT @SQL + char(13) + char(10) + 'G' + 'O'
  EXECUTE (@SQL)

  DECLARE cTableSchema CURSOR FAST_FORWARD FOR
    SELECT '[' + COL.Name + ']',
      FieldType    = TYP.Name + CASE WHEN TYP.Name LIKE '%char' THEN '(' + CONVERT(varchar, COL.prec) + ') ' ELSE '' END + ' NOT NULL',
      PrimaryKey   = CONVERT(bit, CASE WHEN IDK.id IS NULL      THEN 0 ELSE 1 END),
      AutoValue    = CONVERT(bit, CASE WHEN COL.autoval IS NULL THEN 0 ELSE 1 END)
    FROM syscolumns             COL
      INNER JOIN systypes       TYP ON TYP.xtype = COL.xtype
      LEFT  JOIN sysindexes     IDX ON IDX.id = COL.id AND IDX.Status & 2050 = 2050
      LEFT  JOIN sysindexkeys   IDK ON IDK.id = COL.id AND IDK.indid  = IDX.indid AND IDK.colid = COL.colid
    WHERE COL.id = OBJECT_ID(@TableName) AND COL.xtype != 189 -- timestamp
      AND (OBJECT_ID('Hist_' + @TableName) IS NULL OR EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('Hist_' + @TableName) AND Name = COL.Name))
    ORDER BY COL.colorder

  IF @History = 1 AND OBJECT_ID('Hist_' + @TableName) IS NULL BEGIN
    OPEN cTableSchema
    SET @SQL = NULL
    WHILE 1 = 1 BEGIN
      FETCH NEXT FROM cTableSchema INTO @ColumnName, @FieldType, @PrimaryKey, @AutoValue
      IF @@FETCH_STATUS <> 0 BREAK

      SET @SQL = IsNull(@SQL + ', ', '') + @ColumnName
      IF @AutoValue = 1
        SET @SQL = @SQL + ' = CONVERT(int, ' + @ColumnName + ')'
    END
    SET @SQL = 'SELECT ' + @SQL + ', VerID_DELETED = CONVERT(int, NULL)
INTO [Hist_' + @TableName + ']
FROM [' + @TableName + ']'
    PRINT @SQL + char(13) + char(10) + 'G' + 'O'
    EXECUTE (@SQL)
    CLOSE cTableSchema

    OPEN cTableSchema
    SET @SQL = NULL
    WHILE 1 = 1 BEGIN
      FETCH NEXT FROM cTableSchema INTO @ColumnName, @FieldType, @PrimaryKey, @AutoValue
      IF @@FETCH_STATUS <> 0 BREAK

      IF @PrimaryKey = 1 OR @ColumnName = '[VerID]' BEGIN
        SET @sql2 = 'ALTER TABLE [Hist_' + @TableName + '] ALTER COLUMN ' + @ColumnName + ' int NOT NULL'
        EXECUTE (@sql2)

        SET @SQL = IsNull(@SQL + ', ', '') + @ColumnName
      END
    END
    SET @SQL = 'ALTER TABLE [Hist_' + @TableName + '] ADD CONSTRAINT [PK_Hist_' + @TableName + '] PRIMARY KEY (' + @SQL + ')'
    PRINT @SQL + char(13) + char(10) + 'G' + 'O'
    EXECUTE (@SQL)
    CLOSE cTableSchema
  END

  SET @SQL = 'CREATE TRIGGER [trHist_' + @TableName + ']
  ON [' + @TableName + ']
  FOR INSERT, UPDATE' + CASE WHEN @History = 1 THEN ', DELETE' ELSE '' END + '
AS BEGIN
  SET NOCOUNT ON

  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR (''Table [' + @TableName + '] is under Version Control you must first create a new HistoryVersion entry'', 16, 1)
    ROLLBACK TRANSACTION
  END'

  IF @History = 1 BEGIN
    SET @SQL = @SQL + '

  DECLARE @Changes TABLE (
    [PK.FieldDef],
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [PrimaryKey])
  )

  INSERT INTO @Changes
    SELECT IsNull([INS.PK], [DEL.PK]), TBL.VerID,
      CASE WHEN ([INS.PK] IS NULL) THEN 3 WHEN ([DEL.PK] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON [DEL.PK = INS.PK]
      LEFT       JOIN [Hist_' + @TableName + ']  TBL ON [TBL.PK = DEL.PK] AND TBL.VerID_DELETED IS NULL
    WHERE ([INS.PK] IS NULL) OR ([DEL.PK] IS NULL)
      OR CHECKSUM([INS.FieldList])
      <> CHECKSUM([TBL.FieldList])
      OR dbo.fnXCompareTEXT([INS.FieldName], [TBL.FieldName])
      OR dbo.fnXCompareSQL_VARIANT([INS.FieldName], [TBL.FieldName])

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_' + @TableName + ']  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND [UPD.PK = TBL.PK]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_' + @TableName + ']  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND [UPD.PK = TBL.PK] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_' + @TableName + ' ([FieldList], VerID)
      SELECT [TBL.FieldList], @VerID
      FROM [' + @TableName + ']  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND [UPD.PK = TBL.PK]

    UPDATE TBL
      SET VerID = @VerID
    FROM [' + @TableName + ']  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND [UPD.PK = TBL.PK]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END'
  END ELSE BEGIN
    SET @SQL = @SQL + '

  UPDATE TBL
    SET VerID = @VerID
  FROM [' + @TableName + ']  TBL
    INNER JOIN INSERTED  UPD ON [UPD.PK = TBL.PK]
  WHERE IsNull(TBL.VerID, -1) != @VerID'
  END

    SET @SQL = @SQL + '

  SET NOCOUNT OFF
END'

  DECLARE @sqlPK_IS_NULL  varchar(2000),
          @sqlIsNull_PK   varchar(2000),
          @sql5           varchar(2000),
          @sqlFieldList   varchar(2000),
          @sqlCompText    varchar(2000),
          @sqlCompVARIANT varchar(2000)

  OPEN cTableSchema
  SET @sql2 = NULL SET @sqlPK_IS_NULL = NULL SET @sqlIsNull_PK = NULL
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cTableSchema INTO @ColumnName, @FieldType, @PrimaryKey, @AutoValue
    IF @@FETCH_STATUS <> 0 BREAK

    IF @PrimaryKey = 1 BEGIN
      SET @sql2 = IsNull(@sql2 + ',' + char(13) + char(10) + '  ', '') + @ColumnName + ' ' + @FieldType
      SET @sqlPK_IS_NULL = IsNull(@sqlPK_IS_NULL + ' AND ', '') + 'TBL.' + @ColumnName + ' IS NULL'
      SET @sqlIsNull_PK = IsNull(@sqlIsNull_PK + ', ', '') + 'IsNull(INS.' + @ColumnName + ', DEL.' + @ColumnName + ')'
      SET @sql5 = IsNull(@sql5 + ' AND ', '') + 'UPD.' + @ColumnName + ' = TBL.' + @ColumnName
    END ELSE IF @FieldType = 'text' OR @FieldType = 'ntext'
      SET @sqlCompText = IsNull(@sqlCompText, '') + 'OR dbo.fnXCompareTEXT(INS.' + @ColumnName + ', TBL.' + @ColumnName + ') = 0 '
    ELSE IF @FieldType = 'sql_variant'
      SET @sqlCompVARIANT = IsNull(@sqlCompVARIANT, '') + 'OR dbo.fnXCompareSQL_VARIANT(INS.' + @ColumnName + ', TBL.' + @ColumnName + ') = 0 '

    IF @ColumnName <> '[VerID]'
      SET @sqlFieldList = IsNull(@sqlFieldList + ', ', '') + 'TBL.' + @ColumnName
  END
  CLOSE cTableSchema

  SET @SQL = REPLACE(@SQL, '[PK.FieldDef]', @sql2)
  SET @SQL = REPLACE(@SQL, '[PrimaryKey]', REPLACE(SubString(@sqlPK_IS_NULL, 5, LEN(@sqlPK_IS_NULL) - 12), ' IS NULL AND TBL.', ', '))
  SET @SQL = REPLACE(@SQL, '[INS.PK] IS NULL', REPLACE(@sqlPK_IS_NULL, 'TBL.[', 'INS.['))
  SET @SQL = REPLACE(@SQL, '[DEL.PK] IS NULL', REPLACE(@sqlPK_IS_NULL, 'TBL.[', 'DEL.['))

  SET @SQL = REPLACE(@SQL, 'IsNull([INS.PK], [DEL.PK])', @sqlIsNull_PK)

  SET @SQL = REPLACE(@SQL, '[UPD.PK = TBL.PK]', @sql5)
  SET @SQL = REPLACE(@SQL, '[DEL.PK = INS.PK]', REPLACE(REPLACE(@sql5, 'TBL.[', 'INS.['), 'UPD.[', 'DEL.['))
  SET @SQL = REPLACE(@SQL, '[TBL.PK = DEL.PK]', REPLACE(REPLACE(@sql5, 'TBL.[', 'DEL.['), 'UPD.[', 'TBL.['))

  SET @SQL = REPLACE(@SQL, '[FieldList]', REPLACE(@sqlFieldList, 'TBL.[', '['))
  SET @SQL = REPLACE(@SQL, '[INS.FieldList]', REPLACE(@sqlFieldList, 'TBL.[', 'INS.['))
  SET @SQL = REPLACE(@SQL, '[TBL.FieldList]', @sqlFieldList)


  SET @SQL = REPLACE(@SQL, ' OR dbo.fnXCompareTEXT([INS.FieldName], [TBL.FieldName])', IsNull(@sqlCompText, ''))
  SET @SQL = REPLACE(@SQL, ' OR dbo.fnXCompareSQL_VARIANT([INS.FieldName], [TBL.FieldName])', IsNull(@sqlCompVARIANT, ''))

  PRINT @SQL + char(13) + char(10) + 'G' + 'O'
  EXECUTE (@SQL)

  DEALLOCATE cTableSchema
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
