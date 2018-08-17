SET NOCOUNT ON

-------------------------------------------------------------------------------
-- setup temporary tables
-------------------------------------------------------------------------------
-- all tables database
DECLARE @Table TABLE
(
  [object_id] INT NOT NULL PRIMARY KEY,
  [Name]      VARCHAR(100) NOT NULL
)

-- all columns database
DECLARE @Column TABLE
(
  [ID]       INT IDENTITY(1,1) PRIMARY KEY,
  [ColumnID] INT NOT NULL,
  [Name]     VARCHAR(100) NOT NULL,
  [TableID]  INT,
  [Type]     VARCHAR(255),
  [Length]   INT,
  [Default]  VARCHAR(255),   
  [isnullable]  BIT
)

-- get all tables and fill @Table
INSERT INTO @Table
  SELECT 
    [object_id], 
    [name]
  FROM sys.tables

-- get all columns and fill @Column
INSERT INTO @Column
  SELECT  
    [ColumnID]   = COL.id,
    [Name]       = COL.name,
    [TableID]    = TBL.object_id,
    [Type]       = TYP.name,
    [Length]     = COL.length,
    [Default]    = (SELECT COM_II.[text]
                    FROM syscomments COM_II
                    WHERE COM_II.[id] IN (SELECT COL_III.cdefault
                                          FROM syscolumns COL_III
                                          WHERE COL_III.[id] = COL.[id] AND 
                                                COL_III.[name] = COL.[name] AND 
                                                COL_III.cdefault > 0)),
    [isnullable] = COL.isnullable
  FROM syscolumns COL
    INNER JOIN @Table   TBL ON TBL.object_id = COL.id
    INNER JOIN systypes TYP ON TYP.xtype = COL.xtype
  WHERE TYP.xtype NOT IN (34, 35, 99)  -- image / textfelder / ntext können nicht verglichen werden!

  -----------------------------------------------------------------------------
  -- info
  -----------------------------------------------------------------------------
  -- setup vars
  DECLARE @SQL        NVARCHAR(MAX)
  DECLARE @TableName  VARCHAR(100)
  DECLARE @ColumnName VARCHAR(100)

  -- setup cursor
  DECLARE curTableCols CURSOR FAST_FORWARD FOR
  SELECT TBL.name, COL.name
  FROM @Table          TBL
    INNER JOIN @Column COL ON COL.TableID = TBL.object_id
  --WHERE TBL.name LIKE 'XTask'
  ORDER BY TBL.name

  -- iterate through cursor
  OPEN curTableCols
  WHILE 1 = 1
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT FROM curTableCols INTO @TableName, @ColumnName
    IF @@FETCH_STATUS != 0 BREAK

    SET @SQL = N'IF 0 = (SELECT COUNT ('+ @ColumnName + ') FROM ' +   @TableName + ')' +
               N'SELECT ''' +  @TableName + ' , ' + @ColumnName + ''''

    PRINT @SQL  -- we just print the sql out...
  END -- [WHILE cursor]

  -- clean up cursor
  CLOSE curTableCols
  DEALLOCATE curTableCols 


--select   count(<columnName>)from  <tableName>If the count returns 0 that means that all rows in that column all NULL (or there is no rows at all in the table)
--can be changed to 
--select 
--  case(count(<columnName>)) when 0 then 'Nulls Only'
--  else 'Some Values' endfrom     <tableName>