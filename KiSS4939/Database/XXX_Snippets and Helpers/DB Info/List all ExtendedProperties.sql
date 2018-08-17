-- SOURCE: http://www.julian-kuiters.id.au/article.php/extended-properties-all-tables-columns

SELECT TableName     = OBJECT_NAME(EXT.major_id), 
       ColumnName    = COL.name,
       PropertyName  = EXT.name,
       PropertyValue = EXT.value
FROM sys.extended_properties EXT
  LEFT JOIN sys.columns      COL ON COL.object_id = EXT.major_id 
                                AND COL.column_id = EXT.minor_id
WHERE EXT.class_desc = 'OBJECT_OR_COLUMN' 
  AND EXT.name <> 'microsoft_database_tools_support'
ORDER BY TableName, 
         ColumnName, 
         CASE 
           WHEN EXT.name = 'MS_Description' THEN 0 
           ELSE 1 
         END, 
         PropertyName;