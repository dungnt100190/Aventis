DBCC FREEPROCCACHE;
DBCC DROPCLEANBUFFERS;
GO

/*
Use DBCC FREEPROCCACHE to clear the procedure cache. 
Freeing the procedure cache would cause, for example, 
an ad-hoc SQL statement to be recompiled rather than 
reused from the cache. If observing through SQL Profiler, 
one can watch the Cache Remove events occur as 
DBCC FREEPROCCACHE goes to work. DBCC FREEPROCCACHE 
will invalidate all stored procedure plans that the 
optimizer has cached in memory and force SQL Server 
to compile new plans the next time those procedures 
are run.

Use DBCC DROPCLEANBUFFERS to test queries with a cold 
buffer cache without shutting down and restarting the 
server. DBCC DROPCLEANBUFFERS serves to empty the data 
cache. Any data loaded into the buffer cache due to 
the prior execution of a query is removed.

Link: http://blog.sqlauthority.com/2007/03/23/sql-server-stored-procedure-clean-cache-and-clean-buffer/
*/