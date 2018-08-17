SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXGetDBScheme;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spXGetDBScheme.sql $
  $Author: Cjaeggi $
  $Modtime: 12.02.10 9:47 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Shows the database scheme with first dataset for the tables and the second dataset
            containg all the columns
    @NamespaceExtension: Filter, if set only the tables for given namespace extension will be shown
  -
  RETURNS: First result showing all tables, second result showing all columns
  -
  TEST:    EXEC dbo.spXGetDBScheme NULL
           EXEC dbo.spXGetDBScheme 'ZH'
           EXEC dbo.spXGetDBScheme 'PI'
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spXGetDBScheme.sql $
 * 
 * 5     12.02.10 9:50 Cjaeggi
 * Updated filter for OLD objects, added SPs and scalar FNs, fixed sorting
 * of entries on output
 * 
 * 4     21.12.09 13:53 Cjaeggi
 * Excluded more objects
 * 
 * 3     10.12.09 14:37 Cjaeggi
 * Changed constants and boosted performance
 * 
 * 2     10.12.09 14:17 Cjaeggi
 * Modified to fit required features
 * 
 * 1     9.12.09 15:00 Cjaeggi
 * Added new stored procedure
=================================================================================================*/

CREATE PROCEDURE [dbo].[spXGetDBScheme]
(
  @NamespaceExtension VARCHAR(50)
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -------------------------------------------------------------------------------
  -- define consts
  -------------------------------------------------------------------------------
  DECLARE @MAXLENDESC INT;
  DECLARE @MAXLENNSE INT;
  DECLARE @PRIMARYKEY VARCHAR(20);
  DECLARE @FOREIGNKEY VARCHAR(20);
  DECLARE @EXP_DESCRIPTION VARCHAR(20);
  DECLARE @EXP_NAMESPACEEXTENSION VARCHAR(20);
  DECLARE @EXP_OBSOLETE VARCHAR(20);
  
  SET @MAXLENDESC             = 1000;                   -- remember to change temp-tables
  SET @MAXLENNSE              = 50;                     -- remember to change temp-tables
  SET @PRIMARYKEY             = 'PRIMARY KEY';
  SET @FOREIGNKEY             = 'FOREIGN KEY';
  SET @EXP_DESCRIPTION        = 'MS_Description';
  SET @EXP_NAMESPACEEXTENSION = 'NamespaceExtension';
  SET @EXP_OBSOLETE           = 'Obsolete';
  
  -------------------------------------------------------------------------------
  -- information
  -------------------------------------------------------------------------------
  /*
  type  type_desc
  ---------------
  FN    SQL_SCALAR_FUNCTION
   F     FOREIGN_KEY_CONSTRAINT
  U     USER_TABLE
   UQ    UNIQUE_CONSTRAINT
   SQ    SERVICE_QUEUE
   D     DEFAULT_CONSTRAINT
   S     SYSTEM_TABLE
  P     SQL_STORED_PROCEDURE
   PK    PRIMARY_KEY_CONSTRAINT
  V     VIEW
   IT    INTERNAL_TABLE
   TR    SQL_TRIGGER
  TF    SQL_TABLE_VALUED_FUNCTION
  */
  
  -------------------------------------------------------------------------------
  -- define temp-tables
  -------------------------------------------------------------------------------
    -- primary and foreign keys
  DECLARE @Keys TABLE
  (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    TableName VARCHAR(255) NOT NULL,
    ColumnName VARCHAR(255) NOT NULL,
    ConstraintType VARCHAR(50) NOT NULL
  );
  
  -- database objects (tables, views, table functions)
  DECLARE @Object TABLE
  (
    ObjectName VARCHAR(255) NOT NULL PRIMARY KEY, -- store the object name
    ObjectType VARCHAR(10) NOT NULL,              -- store the object type as defined in [sys.objects].type
    EpDescription VARCHAR(1000),                  -- store the "MS_Description" extended property     - shorten if longer!
    EpNamespaceExtension VARCHAR(50),             -- store the "NamespaceExtension" extended property - shorten if longer!
    EpObsolete BIT NOT NULL DEFAULT(0)            -- store the "Obsolete" extended property
  );
  
  -- columns of objects
  DECLARE @Column TABLE
  (
    ObjectName VARCHAR(255) NOT NULL,             -- store the name of the belonging object
    ObjectType VARCHAR(10) NOT NULL,              -- store the object type as defined in [sys.objects].type
    ColumnName VARCHAR(255) NOT NULL,             -- store the column name
    ColumnID INT NOT NULL,                        -- store the id of the column within the table
    EpDescription VARCHAR(1000),                  -- store the "MS_Description" extended property     - shorten if longer!
    EpNamespaceExtension VARCHAR(50),             -- store the "NamespaceExtension" extended property - shorten if longer!
    EpObsolete BIT NOT NULL DEFAULT(0),           -- store the "Obsolete" extended property
    --
    SystemTypeID INT,
    DataTypeLength INT,
    IsNullable BIT,
    IsIdentity BIT
  );
  
  -------------------------------------------------------------------------------
  -- fill temporary table with all primary/foreign keys
  -------------------------------------------------------------------------------
  INSERT INTO @Keys (TableName, ColumnName, ConstraintType)
    SELECT DISTINCT                                           -- prevent douplicate rows!
           TableName      = SCCU.TABLE_NAME,
           ColumnName     = SCCU.COLUMN_NAME,
           ConstraintType = STCS.CONSTRAINT_TYPE
    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS               STCS
      INNER JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE SCCU ON SCCU.CONSTRAINT_NAME = STCS.CONSTRAINT_NAME
    WHERE STCS.CONSTRAINT_TYPE IN (@PRIMARYKEY, @FOREIGNKEY);
  
  -------------------------------------------------------------------------------
  -- fill temporary table with all objects found
  -------------------------------------------------------------------------------
  INSERT INTO @Object
    SELECT ObjectName           = OBJ.name,
           ObjectType           = OBJ.type,
           EpDescription        = LTRIM(RTRIM(dbo.fnGetShortedVarchar(CONVERT(VARCHAR(MAX), EPD.value), @MAXLENDESC, '...'))),
           EpNamespaceExtension = LTRIM(RTRIM(dbo.fnGetShortedVarchar(CONVERT(VARCHAR(MAX), EPN.value), @MAXLENNSE, '...'))),
           EpObsolete           = CASE
                                    WHEN CONVERT(VARCHAR(MAX), EPO.value) = '1' THEN 1  -- obsolete extended property set
                                    WHEN OBJ.name LIKE 'OLD\_%' ESCAPE '\'      THEN 1  -- name starts with "OLD_"
                                    WHEN OBJ.name LIKE '\_OLD\_%' ESCAPE '\'    THEN 1  -- name starts with "_OLD_"
                                    ELSE 0
                                  END
    FROM sys.objects                    OBJ
      -- MS_Description
      LEFT JOIN sys.extended_properties EPD ON EPD.major_id = OBJ.object_id         -- object
                                           AND EPD.minor_id = 0                     -- only major object
                                           AND EPD.name = @EXP_DESCRIPTION          -- extended property name
      
      -- NamespaceExtension 
      LEFT JOIN sys.extended_properties EPN ON EPN.major_id = OBJ.object_id         -- object
                                           AND EPN.minor_id = 0                     -- only major object
                                           AND EPN.name = @EXP_NAMESPACEEXTENSION   -- extended property name
      
      -- Obsolete
      LEFT JOIN sys.extended_properties EPO ON EPO.major_id = OBJ.object_id         -- object
                                           AND EPO.minor_id = 0                     -- only major object
                                           AND EPO.name = @EXP_OBSOLETE             -- extended property name
    
    WHERE OBJ.type IN ('U', 'V', 'P', 'TF', 'FN')                                   -- only 'USER_TABLE', 'VIEW', 'SQL_STORED_PROCEDURE', 'SQL_TABLE_VALUED_FUNCTION', 'SQL_SCALAR_FUNCTION'
      AND OBJ.is_ms_shipped = 0                                                     -- exclude default objects
      AND OBJ.name NOT IN ('sysdiagrams', 'XViewForeignKeys', 'XViewIndex')         -- exclude specific objects (FIX BELOW, TOO)
    ORDER BY ObjectName;
  
  -------------------------------------------------------------------------------
  -- fill temporary table with all columns found
  -------------------------------------------------------------------------------
  INSERT INTO @Column
    SELECT ObjectName           = OBJ.name,
           ObjectType           = OBJ.type,
           ColumnName           = COL.name,
           ColumnID             = COL.column_id,
           EpDescription        = LTRIM(RTRIM(dbo.fnGetShortedVarchar(CONVERT(VARCHAR(MAX), EPD.value), @MAXLENDESC, '...'))),
           EpNamespaceExtension = LTRIM(RTRIM(dbo.fnGetShortedVarchar(CONVERT(VARCHAR(MAX), EPN.value), @MAXLENNSE, '...'))),
           EpObsolete           = CASE 
                                    WHEN CONVERT(VARCHAR(MAX), EPO.value) = '1' THEN 1
                                    ELSE 0
                                  END,
           --
           SystemTypeID         = COL.system_type_id,
           DataTypeLength       = CASE 
                                    WHEN COL.max_length < 0 THEN NULL
                                    ELSE COL.max_length
                                  END,
           IsNullable           = COL.is_nullable,
           IsIdentity           = COL.is_identity
    FROM sys.columns                    COL
      -- Object
      INNER JOIN sys.objects            OBJ ON OBJ.object_id = COL.object_id
                                           AND OBJ.is_ms_shipped = 0
                                           AND OBJ.name NOT IN ('sysdiagrams', 'XViewForeignKeys', 'XViewIndex')  -- exclude specific objects (FIX ABOVE, TOO)
      
      -- MS_Description
      LEFT JOIN sys.extended_properties EPD ON EPD.class_desc = 'OBJECT_OR_COLUMN'    -- type
                                           AND EPD.name = @EXP_DESCRIPTION            -- extended property name
                                           AND EPD.major_id = COL.object_id           -- object of column
                                           AND EPD.minor_id = COL.column_id           -- column on object
      
      -- NamespaceExtension
      LEFT JOIN sys.extended_properties EPN ON EPN.class_desc = 'OBJECT_OR_COLUMN'    -- type
                                           AND EPN.name = @EXP_NAMESPACEEXTENSION     -- extended property name
                                           AND EPN.major_id = COL.object_id           -- object of column
                                           AND EPN.minor_id = COL.column_id           -- column on object
      
      -- Obsolete
      LEFT JOIN sys.extended_properties EPO ON EPO.class_desc = 'OBJECT_OR_COLUMN'    -- type
                                           AND EPO.name = @EXP_OBSOLETE               -- extended property name
                                           AND EPO.major_id = COL.object_id           -- object of column
                                           AND EPO.minor_id = COL.column_id           -- column on object
    ORDER BY ObjectName, ColumnID;
  
  -------------------------------------------------------------------------------
  -- override extended properties from major object definition
  -------------------------------------------------------------------------------
  UPDATE COL
  SET COL.EpNamespaceExtension = CASE 
                                   WHEN OBJ.EpNamespaceExtension IS NOT NULL THEN OBJ.EpNamespaceExtension    -- overwrite from object (only if set)
                                   ELSE COL.EpNamespaceExtension
                                 END,
      COL.EpObsolete           = CASE 
                                   WHEN OBJ.EpObsolete = 1 THEN OBJ.EpObsolete                                -- overwrite from object (only if set)
                                   ELSE COL.EpObsolete
                                 END
  FROM @Column         COL
    INNER JOIN @Object OBJ ON OBJ.ObjectName = COL.ObjectName
                          AND (OBJ.EpNamespaceExtension IS NOT NULL OR OBJ.EpObsolete = 1);
  
  -------------------------------------------------------------------------------
  -- filters
  -------------------------------------------------------------------------------
  -- filter columns - obsolete and namespace extension (first columns to keep objects that cannot be removed)
  DELETE COL
  FROM @Column COL
  WHERE COL.EpObsolete = 1                                                  -- remove all obsolete columns
     OR (@NamespaceExtension IS NOT NULL 
         AND @NamespaceExtension <> ISNULL(COL.EpNamespaceExtension, ''));  -- remove all columns with other namespace (if set)
  
  -- filter objects (I) - obsolete and namespace extension on U, V and TF 
  -- > remove only those that do not have any columns, otherwise a table will be removed even if columns exist (column with nse would loose its table)
  DELETE OBJ
  FROM @Object OBJ
  WHERE OBJ.ObjectType IN ('U', 'V', 'TF')                                      -- handle only those objects that can have columns
    AND (OBJ.EpObsolete = 1                                                     -- remove all obsolete objects
         OR (@NamespaceExtension IS NOT NULL 
             AND @NamespaceExtension <> ISNULL(OBJ.EpNamespaceExtension, '')))  -- remove all objects with other namespace (if set)
    AND NOT EXISTS (SELECT TOP 1 1
                    FROM @Column SCOL
                    WHERE SCOL.ObjectName = OBJ.ObjectName);                    -- remove all without reference in @Column 
  
  -- filter objects (II) - obsolete and namespace extension on P and FN
  DELETE OBJ
  FROM @Object OBJ
  WHERE OBJ.ObjectType IN ('P', 'FN')                                           -- handle only those objects that can have columns
    AND (OBJ.EpObsolete = 1                                                     -- remove all obsolete objects
         OR (@NamespaceExtension IS NOT NULL 
             AND @NamespaceExtension <> ISNULL(OBJ.EpNamespaceExtension, ''))); -- remove all objects with other namespace (if set)
  
  -------------------------------------------------------------------------------
  -- output first dataset: objects
  -------------------------------------------------------------------------------
  SELECT [ObjectName]         = OBJ.[ObjectName],
         [ObjectType]         = OBJ.[ObjectType],
         [Description]        = OBJ.[EpDescription],
         [NamespaceExtension] = OBJ.[EpNamespaceExtension]
  FROM @Object OBJ
  ORDER BY CASE OBJ.[ObjectType]                                           -- order first by type
             WHEN 'U'  THEN 0
             WHEN 'V'  THEN 1
             WHEN 'P'  THEN 2
             WHEN 'TF' THEN 3
             WHEN 'FN' THEN 4
             ELSE 5
           END,
           OBJ.[ObjectName];                                              -- order second by name
  
  -------------------------------------------------------------------------------
  -- output second dataset: columns
  -------------------------------------------------------------------------------
  SELECT [ObjectName]         = COL.[ObjectName],
         [ObjectType]         = OBJ.[ObjectType],
         [ColumnName]         = COL.[ColumnName],
         [DataType]           = TYP.[name],
         [Length]             = COL.[DataTypeLength], 
         [AllowNulls]         = COL.[IsNullable],
         [IsIdentity]         = COL.[IsIdentity],
         [DefaultValue]       = (SELECT SCOM.[text]
                                 FROM syscomments SCOM
                                 WHERE SCOM.[id] IN (SELECT SCOL.[cdefault]
                                                     FROM syscolumns SCOL
                                                     WHERE OBJECT_NAME(SCOL.[id]) = OBJ.[ObjectName]   -- object
                                                       AND SCOL.[name] = COL.[ColumnName]              -- column
                                                       AND SCOL.[cdefault] > 0)),
         [IsPrimaryKey]       = CONVERT(BIT, CASE 
                                               WHEN PKS.[TableName] IS NULL THEN 0
                                               ELSE 1
                                             END),
         [IsForeignKey]       = CONVERT(BIT, CASE 
                                               WHEN FKS.[TableName] IS NULL THEN 0
                                               ELSE 1
                                             END),
         [Description]        = COL.[EpDescription],
         [NamespaceExtension] = COL.[EpNamespaceExtension]
  FROM @Column             COL
    -- Objects
    INNER JOIN @Object     OBJ ON OBJ.[ObjectName] = COL.[ObjectName]         -- ensure objects exists
    
    -- Types
    INNER JOIN sys.types   TYP ON TYP.[system_type_id] = COL.[SystemTypeID]   -- get type
                              AND TYP.[name] NOT IN ('sysname')               -- system_type_id=231 is duplicated, therefore prevent duplicated rows
    
    -- Primary Keys
    LEFT  JOIN @Keys       PKS ON PKS.[TableName] = COL.[ObjectName]
                              AND PKS.[ColumnName] = COL.[ColumnName]
                              AND PKS.[ConstraintType] = @PRIMARYKEY
    
    -- Foreign Keys
    LEFT  JOIN @Keys       FKS ON FKS.[TableName] = COL.[ObjectName]
                              AND FKS.[ColumnName] = COL.[ColumnName]
                              AND FKS.[ConstraintType] = @FOREIGNKEY
  
  ORDER BY CASE OBJ.[ObjectType]                                              -- order first by type
             WHEN 'U'  THEN 0
             WHEN 'V'  THEN 1
             WHEN 'P'  THEN 2
             WHEN 'TF' THEN 3
             WHEN 'FN' THEN 4
             ELSE 5
           END,
           OBJ.[ObjectName],                                                  -- order second by object
           COL.[ColumnID];                                                    -- order third by column id on object
END;
