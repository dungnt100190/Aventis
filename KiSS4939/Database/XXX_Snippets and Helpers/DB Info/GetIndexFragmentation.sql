--=============================================================================
-- get fragmentation of indexes
--=============================================================================
SELECT  OBJECT_NAME(dt.object_id) Tablename,
        si.name IndexName,
        dt.avg_fragmentation_in_percent AS ExternalFragmentation,
        dt.avg_page_space_used_in_percent AS InternalFragmentation
FROM    (SELECT object_id,
                index_id,
                avg_fragmentation_in_percent,
                avg_page_space_used_in_percent
         FROM   sys.dm_db_index_physical_stats(DB_ID(DB_NAME()), null, null, null, 'DETAILED')
         WHERE  index_id <> 0) AS dt
INNER JOIN sys.indexes si ON si.object_id = dt.object_id
                             AND si.index_id = dt.index_id
                             AND dt.avg_fragmentation_in_percent > 10
                             AND dt.avg_page_space_used_in_percent < 75
ORDER BY avg_fragmentation_in_percent DESC;

--=============================================================================
-- description
--=============================================================================
/*
Index fragmentation information:
--------------------------------

Analyzing the result, you can determine where the index fragmentation has occurred, using the following rules:
ExternalFragmentation value > 10 indicates external fragmentation occurred for the corresponding index
InternalFragmentation value < 75 indicates internal fragmentation occurred for the corresponding index

When to reorganize and when to rebuild indexes?
-----------------------------------------------
You should "reorganize" indexes when the External Fragmentation value for the corresponding index is 
between 10-15 and the Internal Fragmentation value is between 60-75. Otherwise, you should rebuild indexes.

One important thing with index rebuilding is, while rebuilding indexes for a particular table, the entire 
table will be locked (which does not occur in the case of index reorganization). So, for a large table in 
the production database, this locking may not be desired, because rebuilding indexes for that table might 
take hours to complete. Fortunately, in SQL Server 2005, there is a solution. You can use the ONLINE option 
as ON while rebuilding indexes for a table (see the index rebuild command given above). This will rebuild 
the indexes for the table, along with making the table available for transactions.

Statments:
----------
Reorganize the fragmented indexes: execute the following command to do this:
ALTER INDEX ALL ON TableName REORGANIZE

Rebuild indexes: execute the following command to do this:
ALTER INDEX ALL ON TableName REBUILD WITH (FILLFACTOR=90,ONLINE=ON) 

See: http://www.codeproject.com/KB/database/OptimizeDBUseIndexing.aspx
*/