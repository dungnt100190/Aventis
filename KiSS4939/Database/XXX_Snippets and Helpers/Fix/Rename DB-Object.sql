-- setup vars
DECLARE @ObjectName VARCHAR(50)
DECLARE @ObjectNameNew VARCHAR(50)

-- setup names
SET @ObjectName = N'fnDmgRelation'
SET @ObjectNameNew = '_Old_' + @ObjectName

-- do rename
EXEC dbo.sp_rename @ObjectName,  @ObjectNameNew