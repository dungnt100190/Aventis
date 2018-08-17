SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDuplicateRows
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spDuplicateRows.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:29 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spDuplicateRows.sql $
 * 
 * 4     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 3     16.12.08 14:02 Ckaeser
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
CREATE PROCEDURE dbo.spDuplicateRows
(@TableName varchar(100),
 @WhereClause varchar(1000),
 @Column1 varchar(100) = NULL,
 @Value1 varchar(1000) = NULL,
 @Column2 varchar(100) = NULL,
 @Value2 varchar(1000) = NULL,
 @Column3 varchar(100) = NULL,
 @Value3 varchar(1000) = NULL,
 @Column4 varchar(100) = NULL,
 @Value4 varchar(1000) = NULL,
 @Column5 varchar(100) = NULL,
 @Value5 varchar(1000) = NULL
)
AS BEGIN

  -- set @TableName = 'BaPerson'
  -- set @WhereClause = 'BaPersonID = 207002'

  DECLARE @ObjectID  int,
          @SQL       varchar(8000),
          @ColList   varchar(4000),
          @ValueList varchar(4000),
          @ColName   varchar(100),
          @PKColName varchar(100),
          @COUNT     varchar(100)

  SET @ObjectID = OBJECT_ID(@TableName)
  IF @ObjectID IS NULL BEGIN
    PRINT 'Die Tabelle ' + @TableName + ' existiert nicht'
    RETURN
  END

  IF len(IsNull(@WhereClause, '')) = 0 BEGIN
    PRINT 'Der Parameter @WhereClause ist leer'
    RETURN
  END

  SELECT
    @PKColName = MAX(COL.name),
    @COUNT     = COUNT(*)
  FROM sysindexes           IDX
    INNER JOIN syscolumns   COL ON COL.id = IDX.id
    INNER JOIN sysindexkeys IDK ON IDK.id = IDX.id AND IDK.indid = IDX.indid AND IDK.colid = COL.colid
  WHERE IDX.id = @ObjectID
    AND IDX.status & 2050 = 2050

  IF @COUNT <> 1 BEGIN
    PRINT 'Die Tabelle ' + @TableName + ' besitzt keinen oder einen Primary Key mit mehreren Kolonnen'
    RETURN
  END

  IF COLUMNPROPERTY(@ObjectID, @PKColName, 'IsIdentity') = 0 BEGIN
    PRINT 'Die Primary Key Feld ' + @TableName + '.' + @PKColName + ' ist kein identity Feld'
    RETURN
  END


  SELECT @ColList = IsNull(@ColList + ',', '') + COL.name
  FROM syscolumns  COL
  WHERE COL.id = @ObjectID
    AND COL.name <> @PKColName
    AND COL.xusertype <> 189 -- Timestamp
  ORDER BY COL.colid

  SET @ValueList = @ColList
  IF @Column1 IS NOT NULL AND @Value1 IS NOT NULL SET @ValueList = replace(@ValueList,@Column1,@Value1)
  IF @Column2 IS NOT NULL AND @Value2 IS NOT NULL SET @ValueList = replace(@ValueList,@Column2,@Value2)
  IF @Column3 IS NOT NULL AND @Value3 IS NOT NULL SET @ValueList = replace(@ValueList,@Column3,@Value3)
  IF @Column4 IS NOT NULL AND @Value4 IS NOT NULL SET @ValueList = replace(@ValueList,@Column4,@Value4)
  IF @Column5 IS NOT NULL AND @Value5 IS NOT NULL SET @ValueList = replace(@ValueList,@Column5,@Value5)

  SET @SQL = 'insert ' + @TableName + ' (' + @ColList + ') ' +
             'select ' + @ValueList + ' from ' + @TableName + ' where ' + @WhereClause

  --PRINT @Sql
  EXECUTE (@SQL)
END
GO