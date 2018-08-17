/*===============================================================================================
  $Revision: 3
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all ID columns without FK and PK.
=================================================================================================*/

;WITH cte AS
(
  SELECT 
    Tabelle = OBJ.name,
    ColName = COL.NAME COLLATE Latin1_General_CS_AS,
    COL.is_nullable,
    COL.is_identity,
    PrimaryKey    = ISNULL((SELECT CASE SKEY.name 
                                  WHEN NULL THEN '' 
                                  ELSE 'x' 
                                END
                            FROM sys.key_constraints       SKEY
                              INNER JOIN sys.index_columns SIXC ON SIXC.object_id = SKEY.parent_object_id
                                                               AND SIXC.index_id = SKEY.unique_index_id
                                                               AND SIXC.column_id = COL.column_id
                            WHERE SKEY.type = 'PK'
                              AND SKEY.parent_object_id = COL.object_id), ''), 

    ForeignKey    = ISNULL((SELECT DISTINCT -- used for multiple FKs
                                  CASE SCOL.name 
                                    WHEN NULL THEN '' 
                                    ELSE 'x' 
                                  END
                            FROM sys.foreign_key_columns SFKC
                              INNER JOIN sys.columns     SCOL ON SCOL.object_id = COL.object_id
                                                             AND SCOL.column_id = COL.column_id
                                                             AND SCOL.column_id = SFKC.parent_column_id
                            WHERE SFKC.parent_object_id = COL.object_id), '')
  FROM sys.columns                     COL
    INNER JOIN sys.objects             OBJ  ON OBJ.object_id = COL.object_id
  WHERE OBJ.name NOT LIKE '_Old_%'
    AND OBJ.name NOT LIKE 'Hist_%'
    AND OBJ.type = 'U'
)

SELECT 
  Tabelle,
  ColName,
  is_nullable,
  is_identity
FROM Cte
WHERE ColName LIKE '%ID%'
  AND ColName NOT LIKE '%TID'
  AND ColName NOT LIKE '%DokID%'
  AND ColName NOT LIKE '%DocumentID%'
  AND PrimaryKey = ''
  AND ForeignKey = ''
ORDER BY 1, 2;


