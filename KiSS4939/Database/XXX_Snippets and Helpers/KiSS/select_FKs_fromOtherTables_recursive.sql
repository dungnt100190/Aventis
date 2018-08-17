/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to select all the FKs with recursion.
=================================================================================================*/

DECLARE @PkTableName VARCHAR(128);
SET @PkTableName = 'BaPerson';

;WITH FKTmp 
AS
(
  -- select all FK from other tables that uses BaPerson
  SELECT 
    PkTableName = OBJECT_NAME(FKC.referenced_object_id),
    PkColumnName = COLPK.name,
    PkTableObjectId = FKC.referenced_object_id,
    PkColumnId = FKC.referenced_column_id,
    FkTableName = OBJECT_NAME(FKC.parent_object_id),
    FkColumnName = COLFK.name,
    FkTableObjectId = FKC.parent_object_id,
    FkColumnId = FKC.parent_column_id,
    FkName = OBJECT_NAME(FKC.constraint_object_id),
    FkObjectId = FKC.constraint_object_id,
    tableLevel = 0,
    fkPath = CONVERT(VARCHAR(MAX), OBJECT_NAME(FKC.referenced_object_id)) + '.' + COLPK.name + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name
  FROM sys.foreign_key_columns FKC
    INNER JOIN sys.columns COLPK ON COLPK.object_id = FKC.referenced_object_id 
                                AND COLPK.column_id = FKC.referenced_column_id
    INNER JOIN sys.columns COLFK ON COLFK.object_id = FKC.parent_object_id 
                                AND COLFK.column_id = FKC.parent_column_id
  WHERE OBJECT_NAME(referenced_object_id) = @PkTableName
  
  UNION ALL
  
  -- recursion on ohter tables
  SELECT 
    PkTableName = OBJECT_NAME(FKC.referenced_object_id),
    PkColumnName = COLPK.name,
    PkTableObjectId = FKC.referenced_object_id,
    PkColumnId = FKC.referenced_column_id,
    FkTableName = OBJECT_NAME(FKC.parent_object_id),
    FkColumnName = COLFK.name,
    FkTableObjectId = FKC.parent_object_id,
    FkColumnId = FKC.parent_column_id,
    FkName = OBJECT_NAME(FKC.constraint_object_id),
    FkObjectId = FKC.constraint_object_id,
    tableLevel = CTE.tableLevel + 1,
    fkPath = CTE.fkPath + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name
  FROM sys.foreign_key_columns FKC
    INNER JOIN sys.columns COLPK ON COLPK.object_id = FKC.referenced_object_id 
                                AND COLPK.column_id = FKC.referenced_column_id
    INNER JOIN sys.columns COLFK ON COLFK.object_id = FKC.parent_object_id 
                                AND COLFK.column_id = FKC.parent_column_id
    INNER JOIN FKTmp CTE ON CTE.FkTableName = OBJECT_NAME(FKC.referenced_object_id)
                        AND CTE.PkTableObjectId <> FKC.referenced_object_id
)


SELECT *
FROM FKTmp
ORDER BY tableLevel, PkTableName, PkColumnName, FkTableName, FkColumnName
