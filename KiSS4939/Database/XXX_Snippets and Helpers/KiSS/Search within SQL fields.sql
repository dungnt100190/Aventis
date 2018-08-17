--------------------------------------------------------------------------------
-- define search value
--------------------------------------------------------------------------------
DECLARE @searchString VARCHAR(255)
SET @searchString = 'xyz'

--------------------------------------------------------------------------------
-- search within: BFSFrage.HerkunftSQL,
--                BgPositionsart.sqlRichtlinie,
--                DynaField.[SQL],
--                XBookmark.[SQL],
--                XModulTree.sqlInsertTreeItem,
--                XModulTree.sqlPreExecute,
--                XQuery.SQLquery,
--                XQuery.ParameterXML,
--------------------------------------------------------------------------------

SELECT 
  [Table]     = '.: Found for Search :.', 
  [Table PK]  = '''' + @SearchString + '''',
  FieldName   = '',
  FieldSQL    = ''

UNION

SELECT 
  [Table]     = 'BFSFrage',
  [Table PK]  = CONVERT(VARCHAR(MAX), BFSFrageID),
  FieldName   = 'HerkunftSQL',
  FieldSQL    = HerkunftSQL
FROM dbo.BFSFrage
WHERE HerkunftSQL LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'BgPositionsart',
  [Table PK]  = CONVERT(VARCHAR(MAX), BgPositionsartID),
  FieldName   = 'sqlRichtlinie',
  FieldSQL    = sqlRichtlinie
FROM dbo.BgPositionsart
WHERE sqlRichtlinie LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'DynaField',
  [Table PK]  = CONVERT(VARCHAR(MAX), DynaFieldID),
  FieldName   = '[SQL]',
  FieldSQL    = [SQL]
FROM dbo.DynaField
WHERE [SQL] LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'XBookmark',
  [Table PK]  = CONVERT(VARCHAR(MAX), BookmarkName),
  FieldName   = '[SQL]',
  FieldSQL    = [SQL]
FROM dbo.XBookmark
WHERE [SQL] LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'XModulTree',
  [Table PK]  = CONVERT(VARCHAR(MAX), ModulTreeID),
  FieldName   = 'sqlInsertTreeItem',
  FieldSQL    = sqlInsertTreeItem
FROM dbo.XModulTree
WHERE sqlInsertTreeItem LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'XModulTree',
  [Table PK]  = CONVERT(VARCHAR(MAX), ModulTreeID),
  FieldName   = 'sqlPreExecute',
  FieldSQL    = sqlPreExecute
FROM dbo.XModulTree
WHERE sqlPreExecute LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'XQuery',
  [Table PK]  = QueryName,
  FieldName   = 'SQLquery',
  FieldSQL    = SQLquery
FROM dbo.XQuery
WHERE SQLquery LIKE '%'+ @searchString +'%'

UNION

SELECT 
  [Table]     = 'XQuery',
  [Table PK]  = QueryName,
  FieldName   = 'ParameterXML',
  FieldSQL    = ParameterXML
FROM dbo.XQuery
WHERE ParameterXML LIKE '%'+ @searchString +'%'

ORDER BY [Table], [Table PK]
