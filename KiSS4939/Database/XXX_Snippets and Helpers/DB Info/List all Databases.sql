USE master
GO

SELECT DBS.*
FROM sys.Databases DBS
ORDER BY DBS.name
GO