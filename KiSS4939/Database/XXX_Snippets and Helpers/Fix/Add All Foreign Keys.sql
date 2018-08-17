 SELECT  
     'ALTER TABLE dbo.'
   + object_name(a.parent_object_id)
   + ' ADD CONSTRAINT '+ a.name
   + ' FOREIGN KEY (' + c.name + ') REFERENCES '
   + object_name(b.referenced_object_id)
   + ' (' + d.name + ')'
FROM   sys.foreign_keys        a
  JOIN sys.foreign_key_columns b ON a.object_id = b.constraint_object_id
  JOIN sys.columns             c ON b.parent_column_id = c.column_id AND a.parent_object_id=c.object_id
  JOIN sys.columns             d ON b.referenced_column_id = d.column_id AND a.referenced_object_id = d.object_id
--where   object_name(b.referenced_object_id) in ('tablename1','tablename2')
ORDER BY c.name