SELECT IX.Name, IX.type_desc, IX.is_unique, COL.name
FROM sys.indexes IX
  INNER JOIN sys.index_columns IXC ON IXC.object_id = IX.object_id AND IX.index_id = IXC.index_id
  INNER JOIN sys.columns COL ON COL.object_id = IX.object_id AND COL.column_id = IXC.column_id
WHERE IX.object_id = OBJECT_ID('BgPosition')
ORDER BY IX.Name, COL.Name