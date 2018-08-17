SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDuplicateRows
GO

CREATE PROCEDURE [dbo].[spDuplicateRows]
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
AS

-- set @TableName = 'BaPerson'
-- set @WhereClause = 'BaPersonID = 207002'

DECLARE @SQL       varchar(8000)
DECLARE @ColList   varchar(4000)
DECLARE @ValueList varchar(4000)
DECLARE @ColName   varchar(100)
DECLARE @PKColName varchar(100)
DECLARE @COUNT     varchar(100)

IF (SELECT OBJECT_ID(@TableName)) IS NULL BEGIN
  PRINT 'Die Tabelle ' + @TableName + ' existiert nicht'
  RETURN
END

IF len(IsNull(@WhereClause,'')) = 0 BEGIN
  PRINT 'Der Parameter @WhereClause ist leer'
  RETURN
END

SELECT @PKColName = MAX(COL.Name),
       @COUNT     = COUNT(*)
FROM sys.indexes IDX
     INNER JOIN sys.index_columns ICO on ICO.index_id = IDX.index_id AND
                                         ICO.OBJECT_ID = IDX.OBJECT_ID
     INNER JOIN syscolumns        COL on COL.id = IDX.OBJECT_ID AND
                                         COL.colid = ICO.column_id
WHERE IDX.OBJECT_ID = OBJECT_ID(@TableName) AND
      IDX.is_primary_key = 1
GROUP BY ICO.index_id

IF @COUNT <> 1 BEGIN
  PRINT 'Die Tabelle ' + @TableName + ' besitzt keinen oder einen Primary Key mit mehreren Kolonnen'
  RETURN
END

IF NOT EXISTS (SELECT 1 FROM sys.identity_columns WHERE OBJECT_ID = OBJECT_ID(@TableName) AND Name = @PKColName) BEGIN
  PRINT 'Die Primary Key Feld ' + @TableName + '.' + @PKColName + ' ist kein identity Feld'
  RETURN
END

DECLARE cColumn CURSOR STATIC FOR
  SELECT C.Name
  FROM   syscolumns C
         INNER JOIN sysobjects T on T.ID = C.ID
  WHERE  T.Name = @TableName AND
         C.Name <> @PKColName AND
         C.xusertype <> 189
  ORDER BY C.ColID

SET @ColList = ''
OPEN cColumn
FETCH NEXT FROM cColumn INTO @ColName
WHILE @@fetch_status = 0 BEGIN
  IF @ColList <> '' SET @ColList = @ColList + ','
  SET @ColList = @ColList + @ColName
  FETCH NEXT FROM cColumn INTO @ColName
END
CLOSE cColumn
DEALLOCATE cColumn

SET @ValueList = @ColList
IF @Column1 IS NOT NULL AND @Value1 IS NOT NULL SET @ValueList = replace(@ValueList,@Column1,@Value1)
IF @Column2 IS NOT NULL AND @Value2 IS NOT NULL SET @ValueList = replace(@ValueList,@Column2,@Value2)
IF @Column3 IS NOT NULL AND @Value3 IS NOT NULL SET @ValueList = replace(@ValueList,@Column3,@Value3)
IF @Column4 IS NOT NULL AND @Value4 IS NOT NULL SET @ValueList = replace(@ValueList,@Column4,@Value4)
IF @Column5 IS NOT NULL AND @Value5 IS NOT NULL SET @ValueList = replace(@ValueList,@Column5,@Value5)

SET @SQL = 'insert ' + @TableName + ' (' + @ColList + ') ' +
           'select ' + @ValueList + ' from ' + @TableName + ' where ' + @WhereClause

--Select @Sql
EXEC (@SQL)
