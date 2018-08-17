/* Find Collation of SQL Server Database */
SELECT DATABASEPROPERTYEX(DB_NAME(), 'Collation')
GO

/* Find Collation of SQL Server Database Table Column */
SELECT name, collation_name
FROM sys.columns
WHERE OBJECT_ID IN (SELECT OBJECT_ID
                    FROM sys.objects
                    WHERE type IN ('U', 'V'))
ORDER BY Collation_Name DESC
GO