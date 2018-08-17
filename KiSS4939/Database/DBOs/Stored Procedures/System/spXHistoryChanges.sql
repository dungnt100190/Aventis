SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXHistoryChanges
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXHistoryChanges.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:08 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXHistoryChanges.sql $
 * 
 * 2     25.06.09 8:46 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spXHistoryChanges
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spXHistoryChanges
 (@TableName   sysname)
AS BEGIN
  SET NOCOUNT ON

  DECLARE @SQL         varchar(8000),
          @sql2        varchar(2000),
          @ColumnName  sysname,
          @FieldType   varchar(200),
          @PrimaryKey  bit,
          @AutoValue   bit


  IF OBJECT_ID('trHist_' + @TableName) IS NOT NULL  BEGIN
    SET @SQL = 'DROP TRIGGER [trHist_' + @TableName + ']'
    PRINT @SQL + char(13) + char(10) + 'G' + 'O'
    EXECUTE (@SQL)
  END

  DECLARE cTableSchema CURSOR FAST_FORWARD FOR
    SELECT '[' + COL.name + ']',
      FieldType    = TYP.name + CASE WHEN TYP.name LIKE '%char' THEN '(' + CONVERT(varchar, COL.prec) + ') ' ELSE '' END + ' NOT NULL',
      PrimaryKey   = CONVERT(bit, CASE WHEN IDK.id IS NULL      THEN 0 ELSE 1 END),
      AutoValue    = CONVERT(bit, CASE WHEN COL.autoval IS NULL THEN 0 ELSE 1 END)
    FROM syscolumns             COL
      INNER JOIN systypes       TYP ON TYP.xtype = COL.xtype
      LEFT  JOIN sysindexes     IDX ON IDX.id = COL.id AND IDX.status & 2050 = 2050
      LEFT  JOIN sysindexkeys   IDK ON IDK.id = COL.id AND IDK.indid  = IDX.indid AND IDK.colid = COL.colid
    WHERE COL.id = OBJECT_ID(@TableName) AND COL.xtype != 189 -- timestamp
      AND (OBJECT_ID('Hist_' + @TableName) IS NULL OR EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID('Hist_' + @TableName) AND name = COL.name))
    ORDER BY COL.colorder

  SET @SQL = 'CREATE TRIGGER [trHist_' + @TableName + ']
  ON [' + @TableName + ']
  FOR UPDATE
AS BEGIN
  SET NOCOUNT ON

  DECLARE @UserID     INT

  SELECT @UserID = USR.UserID
  FROM master..sysprocesses  PRC
    LEFT  JOIN XUser         USR ON PRC.hostname LIKE ''%(%)%'' AND USR.LogonName = SUBSTRING(SUBSTRING(PRC.hostname, 0, CHARINDEX('')'', PRC.hostname)), CHARINDEX(''('', PRC.hostname) + 1, 1000) COLLATE DATABASE_DEFAULT
  WHERE spid = @@SPID

  IF @VerID IS NULL BEGIN
    RAISERROR (''Table [' + @TableName + '] is under Version Control you must first create a new HistoryVersion entry'', 16, 1)
    ROLLBACK TRANSACTION
  END

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
  END

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