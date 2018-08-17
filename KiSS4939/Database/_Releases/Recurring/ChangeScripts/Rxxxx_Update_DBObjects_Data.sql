/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update data in tables XTableColumn, XTable
           This script is neccessary for every release (recurring).
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
SET NOCOUNT ON;

-------------------------------------------------------------------------------
-- do cleanup first
-------------------------------------------------------------------------------
DELETE FROM XTableColumn;
DELETE FROM XTable;
GO

-------------------------------------------------------------------------------
-- insert XTable-values
-------------------------------------------------------------------------------
PRINT CHAR(13) + CHAR(10) + CHAR(9) + ' Table: XTable';
GO

INSERT INTO XTable (TableName, System)
  SELECT name,
	       CASE WHEN name LIKE 'X%'   THEN 1
	            ELSE 0
	       END
  FROM sysobjects TBL
  WHERE xtype = 'U' AND 
        name NOT IN ('dtproperties', 'sysdiagrams') AND 
        name NOT LIKE 'Hist_%' AND
        NOT EXISTS (SELECT TOP 1 1 FROM XTable WHERE TableName = TBL.name)
  ORDER BY name;
GO

UPDATE OBJ
SET ModulID = CASE WHEN TableName LIKE 'Dyna%'   THEN 0
                   WHEN TableName LIKE 'XClass%' THEN 11
                   ELSE MOD.ModulID
              END
FROM XTable OBJ
  LEFT JOIN XModul MOD ON OBJ.TableName LIKE MOD.DB_Prefix + '%'
WHERE OBJ.ModulID IS NULL;
GO

-------------------------------------------------------------------------------
-- insert XTableColumn-values
-------------------------------------------------------------------------------
PRINT CHAR(13) + CHAR(10) + CHAR(9) + ' Table: XTableColumn';
GO

INSERT INTO XTableColumn (TableName, ColumnName, FieldCode, LOVName, System)
  SELECT TableName  = TBL.TableName, 
         ColumnName = COL.name,
         FieldCode  = CASE WHEN TYP.name LIKE '%varchar' AND COL.length < 500  THEN  1
                           WHEN TYP.name LIKE '%varchar'                       THEN  2
                           WHEN TYP.name LIKE '%text'                          THEN  2
                           WHEN TYP.name =    'int' AND COL.Name LIKE '%Code'  THEN  7
                           WHEN TYP.name =    'int' AND COL.Name LIKE '%DokID' THEN  9
                           WHEN TYP.name =    'int'                            THEN  3
                           WHEN TYP.name =    'smallint'                       THEN  3
                           WHEN TYP.name LIKE '%datetime'                      THEN  4
                           WHEN TYP.name LIKE 'bit'                            THEN  6
                           WHEN TYP.name LIKE 'money'                          THEN 12
                           WHEN TYP.name =    'image'                          THEN 13
                           WHEN TYP.name IN  ('float', 'real')                 THEN 14
                           WHEN TYP.name =    'sql_variant'                    THEN 15
                           ELSE NULL
                       END,
         LOVName    = (SELECT LOVName
                       FROM XLOV
                       WHERE TYP.name = 'int' AND 
                             COL.Name LIKE '%Code' AND 
                             LOVName + 'Code' = COL.Name),
         System     = TBL.System
  FROM XTable              TBL
    INNER JOIN syscolumns COL ON COL.id = object_id(TBL.TableName)
    INNER JOIN systypes   TYP ON TYP.xtype = COL.xtype AND 
                                 TYP.usertype = COL.usertype
  WHERE TYP.name <> 'timestamp' AND 
        COL.name NOT LIKE 'VerID%' AND
        NOT EXISTS (SELECT TOP 1 1 FROM XTableColumn WHERE TableName = TBL.TableName AND ColumnName = COL.name);
GO

-------------------------------------------------------------------------------------------------
-- done
-------------------------------------------------------------------------------------------------
GO
