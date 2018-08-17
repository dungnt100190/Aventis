SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spGetDependendRowCount
GO

CREATE PROCEDURE [dbo].[spGetDependendRowCount]
 (@ParentTableName varchar(100),
  @ID int)
AS BEGIN

  DECLARE @SQL nvarchar(500)
  DECLARE @params nvarchar(500)
  DECLARE @table varchar(100)
  DECLARE @count int
  DECLARE @tmp TABLE
  (
    TableName varchar(100),
    [Count]   int
  )

  SET @params = '@countOUT int OUTPUT'

  DECLARE cCount CURSOR FAST_FORWARD FOR
    SELECT 'SELECT @countOUT = COUNT(*) FROM ' + dpd.Name + ' WHERE ' + col.Name + ' = ' + CAST(@ID AS varchar), dpd.Name
    FROM sys.objects tbl
      INNER JOIN sys.foreign_key_columns fky on fky.referenced_object_id = tbl.OBJECT_ID
      INNER JOIN sys.objects dpd on dpd.OBJECT_ID = fky.parent_object_id
      INNER JOIN sys.Columns col on col.OBJECT_ID = fky.parent_object_id AND col.column_id = fky.parent_column_id
    WHERE tbl.TYPE = 'U' AND tbl.Name = @ParentTableName
  
    
  OPEN cCount
  WHILE 1=1 BEGIN
  FETCH NEXT FROM cCount INTO @SQL, @table
  IF @@FETCH_STATUS < 0 BREAK

  EXEC sp_executesql @SQL, @params, @countOUT = @count OUTPUT

  INSERT INTO @tmp
  VALUES(@table,@count)

  END
  CLOSE cCount
  DEALLOCATE cCount

  SELECT *
  FROM @tmp
  WHERE [Count] > 0

END
