SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spImportTable
GO

/*===============================================================================================
  $Revision: 1 $
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
CREATE PROCEDURE dbo.spImportTable
(@SourceDB varchar(100),
 @SourceTable varchar(100))
AS

IF (SELECT OBJECT_ID(@SourceDB + '..' + @SourceTable)) IS NULL BEGIN
  PRINT 'SourceTable ' + @SourceDB + '..' + @SourceTable + ' does not exist'
  RETURN
END

IF (SELECT OBJECT_ID(@SourceTable)) IS NULL BEGIN
  PRINT 'DestTable ' + db_name() + '..' + @SourceDB + ' does not exist'
  RETURN
END

EXECUTE ('delete ' + @SourceTable)
IF @@error <> 0 BEGIN
  PRINT 'DestTable ' + db_name() + '..' + @SourceTable + ' cannot be emptied'
  RETURN
END


DECLARE @SQL     varchar(8000)
DECLARE @ColList varchar(1000)
DECLARE @ColName varchar(100)
DECLARE @identity bit
DECLARE @hasidentity bit

DECLARE cColumn CURSOR STATIC FOR
  SELECT C1.Name, [identity] = CONVERT(bit,CASE WHEN I.Name IS NOT NULL THEN 1 ELSE 0 END)
  FROM   syscolumns C1
         INNER JOIN sysobjects T1 on T1.ID = C1.ID AND C1.xtype <> 189
         LEFT JOIN sys.identity_columns I on I.OBJECT_ID = C1.id AND
                                             I.Name = C1.Name
  WHERE  T1.Name = @SourceTable
  ORDER BY C1.ColID

SET @ColList = ''
SET @hasidentity = 0

OPEN cColumn
FETCH NEXT FROM cColumn INTO @ColName,@identity
WHILE @@fetch_status = 0 BEGIN
  IF @ColList <> '' SET @ColList = @ColList + ',' + char(13) + char(10) + '  '
  SET @ColList = @ColList + @ColName
  IF @identity = 1 SET @hasidentity = 1

  FETCH NEXT FROM cColumn INTO @ColName,@identity
END
CLOSE cColumn
DEALLOCATE cColumn

IF @hasidentity = 1
  SET @SQL = 'Set identity_insert ' + @SourceTable + ' on' + char(13) + char(10)
ELSE
  SET @SQL = ''

SET @SQL = @SQL +
           'insert ' + @SourceTable + char(13) + char(10) +
           ' (' + @ColList + ') ' + char(13) + char(10) +
           'select ' + char(13) + char(10) +
           '  ' + @ColList + char(13) + char(10) +
           'from ' + @SourceDB + '..' + @SourceTable + char(13) + char(10)

IF @hasidentity = 1
  SET @SQL = @SQL + 'Set identity_insert ' + @SourceTable + ' off' + char(13) + char(10)

--select @Sql
EXECUTE (@SQL)
