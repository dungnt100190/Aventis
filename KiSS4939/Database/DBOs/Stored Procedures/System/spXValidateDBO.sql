SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXValidateDBO;
GO
/*===============================================================================================
  $Revision: 17 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this stored procedure to validate database object such as table, view, function,
            store procedure.
    @DBOName:    The name of database object to get definiton from 
                 (or only unique first part of the name)
    @OutputMode: (not used yet)
    @OnlyTypeOf: Specify a type to get only object definition of given type 
                 (e.g. 'U' for user-table, 'V' for view)
  -
  RETURNS: Print out messages of validated parts and result and returns 0 on success, 1 on failure
  -
  REMARKS: Get system types from SELECT * FROM sys.types;
=================================================================================================
  TEST:    EXEC dbo.spXValidateDBO BaPerson;
           EXEC dbo.spXValidateDBO BaAdresse;
           EXEC dbo.spXValidateDBO BaPerson_Relation;
           EXEC dbo.spXValidateDBO KbBuchung;
           EXEC dbo.spXValidateDBO XArchiv;
           EXEC dbo.spXValidateDBO XMenuItem;
           EXEC dbo.spXValidateDBO XTask;
           EXEC dbo.spXValidateDBO VmBewertung;
           EXEC dbo.spXValidateDBO XProfile;
=================================================================================================*/

CREATE PROCEDURE dbo.spXValidateDBO
(
  @DBOName VARCHAR(255),
  @OutputMode INT = NULL,
  @OnlyTypeOf VARCHAR(5) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  PRINT ('---- Script version: $Revision: 16 $ ----');
  PRINT ('Info: Database "' + DB_NAME() + '"');
  
  -----------------------------------------------------------------------------
  -- setup vars
  -----------------------------------------------------------------------------
  DECLARE @CountFound INT;
  DECLARE @DBOType VARCHAR(10);
  DECLARE @DBOObjectID BIGINT;
  DECLARE @ErrorCounter INT;
  DECLARE @FinalOutput VARCHAR(1000);
  --
  DECLARE @TableColName VARCHAR(255);
  DECLARE @TableColID INT;
  DECLARE @TableColSystemTypeID INT;
  DECLARE @TableColCollationName VARCHAR(255);
  DECLARE @TableColIsNullable BIT; 
  DECLARE @TableColIsIdentity BIT;
  DECLARE @TableColDefaultObjectID INT;
  
  -- constants
  DECLARE @COLLATION VARCHAR(255);
  DECLARE @DEBUGLEVEL INT;
  
  SET @COLLATION = 'Latin1_General_CI_AS';
  SET @DEBUGLEVEL = 0;
  
  -- set other vars
  SET @ErrorCounter = 0;
  
  -- fix name if not trimmed
  SET @DBOName = ISNULL(LTRIM(RTRIM(@DBOName)), '');
  
  -- fix output mode if emtpy
  SET @OutputMode = ISNULL(@OutputMode, 0);
  
  -----------------------------------------------------------------------------
  -- validate unique
  -----------------------------------------------------------------------------
  -- count entries that possibly match
  SELECT @CountFound = COUNT(1)
  FROM sys.objects OBJ
  WHERE OBJ.[name] LIKE @DBOName + '%'
    AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  
  -- check any found
  IF (@CountFound < 1)
  BEGIN
    PRINT ('>>> Error: No database object starting with "' + @DBOName + '" found, please check spelling');
    
    -- failure
    RETURN 1;
  END;
  
  IF (@CountFound = 1)
  BEGIN
    -- get propper name and definition (could be only a part of the name > this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] LIKE @DBOName + '%'
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: LIKE searching: @CountFound = 1');
    END;
  END
  ELSE
  BEGIN
    IF (@DEBUGLEVEL > 0)
    BEGIN
      PRINT ('Debug: Multiple with LIKE found, searching exact now: @CountFound = ' + CONVERT(VARCHAR(50), @CountFound));
    END;
    
    -- check without like
    SELECT @CountFound = COUNT(1)
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
    
    IF (@CountFound <> 1)
    BEGIN
      -- output candidates
      SELECT PossibleDBOs = OBJ.[name]
      FROM sys.objects OBJ
      WHERE OBJ.[name] LIKE @DBOName + '%'
        AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
      
      -- output message
      IF (@CountFound < 1)
      BEGIN
        PRINT ('>>> Error: No database object with exact name "' + @DBOName + '" found, please check spelling');
      END
      ELSE
      BEGIN
        PRINT ('>>> Error: Multiple database object with exact name "' + @DBOName + '" found, please check spelling');
      END;
      
      -- failure
      RETURN 1;
    END
    
    -- get propper name and definition (this way we set it exactly)
    SELECT @DBOName     = OBJ.[name],
           @DBOType     = LTRIM(RTRIM(OBJ.[type])),
           @DBOObjectID = OBJ.[object_id]
    FROM sys.objects OBJ
    WHERE OBJ.[name] = @DBOName
      AND (@OnlyTypeOf IS NULL OR OBJ.type = @OnlyTypeOf);
  END;

  -----------------------------------------------------------------------------
  -- type depending evaluation
  -----------------------------------------------------------------------------
  
  -- ==========================================================================
  -- TABLE:
  -- ==========================================================================
  IF (@DBOType = 'U')
  BEGIN
    PRINT ('Info: Table "' + @DBOName + '"');
    PRINT ('');

    ---------------------------------------------------------------------------
    -- validate table naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate table prefix
    ---------------------------------------------------------------------------
    IF (@DBOName NOT LIKE 'Ka%' AND 
        @DBOName NOT LIKE 'Ay%' AND 
        @DBOName NOT LIKE 'Ba%' AND 
        @DBOName NOT LIKE 'Bde%' AND 
        @DBOName NOT LIKE 'Bw%' AND 
        @DBOName NOT LIKE 'Bg%' AND 
        @DBOName NOT LIKE 'Cm%' AND 
        @DBOName NOT LIKE 'Ed%' AND 
        @DBOName NOT LIKE 'Fa%' AND 
        @DBOName NOT LIKE 'Fb%' AND 
        @DBOName NOT LIKE 'Fs%' AND 
        @DBOName NOT LIKE 'Gv%' AND 
        @DBOName NOT LIKE 'Ik%' AND 
        @DBOName NOT LIKE 'In%' AND 
        @DBOName NOT LIKE 'Kb%' AND 
        @DBOName NOT LIKE 'Kbu%' AND 
        @DBOName NOT LIKE 'Kes%' AND 
        @DBOName NOT LIKE 'Kg%' AND 
        @DBOName NOT LIKE 'Qry%' AND 
        @DBOName NOT LIKE 'Sst%' AND 
        @DBOName NOT LIKE 'Bfs%' AND 
        @DBOName NOT LIKE 'Sb%' AND 
        @DBOName NOT LIKE 'Wh%' AND 
        @DBOName NOT LIKE 'Wsh%' AND 
        @DBOName NOT LIKE 'Vm%' AND 
        @DBOName NOT LIKE 'X%')
    BEGIN
      PRINT ('>>> Error: The table prefix for table "' + @DBOName + '" is not valid');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate PK
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'ID';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The primary key column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the first column
      IF (@TableColID > 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" should be the first column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be INT
      IF (@TableColSystemTypeID <> 56)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must be typeof INT');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be identity
      IF (@TableColIsIdentity = 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" is not an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The primary key column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate TS
    ---------------------------------------------------------------------------
    SET @TableColName = @DBOName + 'TS';
    SET @TableColID = NULL;
    
    SELECT @TableColID              = column_id,
           @TableColSystemTypeID    = system_type_id,
           @TableColIsNullable      = is_nullable,
           @TableColIsIdentity      = is_identity,
           @TableColDefaultObjectID = default_object_id
    FROM sys.columns
    WHERE object_id = @DBOObjectID
      AND name = @TableColName;
    
    -- check found
    IF (@TableColID IS NULL)
    BEGIN
      PRINT ('>>> Error: The timestamp column "' + @TableColName + '" was not found');
      SET @ErrorCounter = @ErrorCounter + 1;
    END
    ELSE
    BEGIN
      -- must be the last column
      IF (@TableColID <> (SELECT MAX(column_id) 
                          FROM sys.columns
                          WHERE object_id = @DBOObjectID))
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" should be the last column of the table');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must be TIMESTAMP
      IF (@TableColSystemTypeID <> 189)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must be typeof TIMESTAMP');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be identity
      IF (@TableColIsIdentity = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be an identity column');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not be nullable
      IF (@TableColIsNullable = 1)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not be nullable');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
      
      -- must not have a default value
      IF (@TableColDefaultObjectID <> 0)
      BEGIN
        PRINT ('>>> Error: The timestamp column "' + @TableColName + '" must not have a default value');
        SET @ErrorCounter = @ErrorCounter + 1;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns existing: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Creator'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Creator" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- created
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Created'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Created" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modifier'
                      AND system_type_id = 167 -- VARCHAR
                      AND max_length = 50))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" as VARCHAR(50) is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modified
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.columns
                    WHERE object_id = @DBOObjectID
                      AND name = 'Modified'
                      AND system_type_id = 61 -- DATETIME
                      AND max_length = 8))
    BEGIN
      PRINT ('>>> Error: The column "Modified" as DATETIME is missing');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate columns defaults: creator, created, modifier, modified
    ---------------------------------------------------------------------------
    -- creator (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Creator'))
    BEGIN
      PRINT ('>>> Error: The column "Creator" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Creator'
    END;
    
    -- created (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Created'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Created" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- modifier (no default)
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.default_constraints
                WHERE parent_object_id = @DBOObjectID
                  AND name = 'DF_' + @DBOName + '_Modifier'))
    BEGIN
      PRINT ('>>> Error: The column "Modifier" should not have default constraint assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT CreatorDFName = name,
             DFContent     = definition
      FROM sys.default_constraints
      WHERE parent_object_id = @DBOObjectID
        AND name = 'DF_' + @DBOName + '_Modifier'
    END;
    
    -- modified (must have default)
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.default_constraints
                    WHERE parent_object_id = @DBOObjectID
                      AND name = 'DF_' + @DBOName + '_Modified'
                      AND definition LIKE '%GETDATE()%'))
    BEGIN
      PRINT ('>>> Error: The column "Modified" should have default constraint for "GETDATE()" assigned');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming [a-z],[A-Z],[0-9],[_]
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
                          REPLACE(REPLACE(
                            name, 'a', ''), 'b', ''), 'c', ''), 'd', ''), 'e', ''), 'f', ''), 'g', ''),
                                  'h', ''), 'i', ''), 'j', ''), 'k', ''), 'l', ''), 'm', ''), 'n', ''),
                                  'o', ''), 'p', ''), 'q', ''), 'r', ''), 's', ''), 't', ''), 'u', ''),
                                  'v', ''), 'w', ''), 'x', ''), 'y', ''), 'z', ''),
                                  '0', ''), '1', ''), '2', ''), '3', ''), '4', ''), '5', ''), '6', ''),
                                  '7', ''), '8', ''), '9', ''),
                                  '_', ''))
                            > 0))
    BEGIN
      PRINT ('>>> Error: There is at least one column name with wrong chars (not in [a-z],[A-Z],[0-9],[_])');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate column naming same as tablename
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE name = @DBOName))
    BEGIN
      PRINT ('>>> Error: There is a column with the same name as the table. This will be a problem with its C# class and property.');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND system_type_id = 104 -- BIT
                  AND default_object_id = 0))
    BEGIN
      PRINT ('>>> Error: There is at least one BIT column without a default value');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithoutBITDefault = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND system_type_id = 104 -- BIT
        AND default_object_id = 0
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate BIT defaults (0)
    ---------------------------------------------------------------------------
    -- TODO

    ---------------------------------------------------------------------------
    -- validate defaulted not null columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns
                WHERE object_id = @DBOObjectID
                  AND default_object_id > 0
                  AND is_nullable = 1))
    BEGIN
      PRINT ('>>> Error: There is at least one column with default value that is nullable');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameWithDefaultNullable = name
      FROM sys.columns
      WHERE object_id = @DBOObjectID
        AND default_object_id > 0
        AND is_nullable = 1
      ORDER BY column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Code
    ---------------------------------------------------------------------------
    -- INT
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND COL.system_type_id <> 56))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column not typeof INT');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeNotTypeOfINT = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND COL.system_type_id <> 56
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Code'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Code column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodeWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Code'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Code', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate *Codes
    ---------------------------------------------------------------------------
    -- VARCHAR
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND (COL.system_type_id <> 167 OR COL.max_length <> 255)))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column not typeof VARCHAR(255)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesNotTypeOfVARCHAR255 = COL.name,
             ColumnDataType                     = (SELECT TYP.NAME
                                                   FROM sys.types TYP
                                                   WHERE TYP.system_type_id = COL.system_type_id),
             ColumnDataLength                   = COL.max_length
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND (COL.system_type_id <> 167 OR COL.max_length <> 255)
      ORDER BY COL.column_id;
    END;
    
    -- LOVName
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE object_id = @DBOObjectID
                  AND COL.name LIKE '%Codes'
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                                  WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))))
    BEGIN
      PRINT ('>>> Error: There is at least one LOV-Codes column without a corresponding LOVName');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT ColumnNameCodesWithoutLOV = COL.name
      FROM sys.columns COL
      WHERE object_id = @DBOObjectID
        AND COL.name LIKE '%Codes'
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.XLOV LOV WITH (READUNCOMMITTED)
                        WHERE LOV.LOVName = REPLACE(COL.name, 'Codes', ''))
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- validate clustered index for PK
    ---------------------------------------------------------------------------
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.indexes IDX
                    WHERE IDX.object_id = @DBOObjectID
                      AND IDX.name = 'PK_' + @DBOName
                      AND IDX.type = 1                -- CLUSTERED
                      AND IDX.is_primary_key = 1
                      AND IDX.is_disabled = 0))
    BEGIN
      PRINT ('>>> Error: The primary key does not have a corresponding CLUSTERED index "PK_' + @DBOName + '"');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- validate FK columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_key_columns FKC
                  INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                                AND COL.column_id = FKC.parent_column_id
                WHERE FKC.parent_object_id = @DBOObjectID
                  AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
                  AND COL.name NOT IN (SELECT SCOL.name
                                       FROM sys.columns SCOL
                                       WHERE SCOL.object_id = FKC.referenced_object_id
                                         AND SCOL.column_id = FKC.referenced_column_id)))
    BEGIN
      PRINT ('>>> Error: There is at least one FK column with different naming compared to corresponding PK column');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKColumnName = COL.name
      FROM sys.foreign_key_columns FKC
        INNER JOIN sys.columns     COL ON COL.object_id = @DBOObjectID
                                      AND COL.column_id = FKC.parent_column_id
      WHERE FKC.parent_object_id = @DBOObjectID
        AND COL.name NOT LIKE '%\_%' ESCAPE '\' -- only those column without '_' > 99% of the others have a description (multi FKs to same table)
        AND COL.name NOT IN (SELECT SCOL.name
                             FROM sys.columns SCOL
                             WHERE SCOL.object_id = FKC.referenced_object_id
                               AND SCOL.column_id = FKC.referenced_column_id);
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys naming
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND (-- FK name
                       FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
                       -- PK table without description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
                    AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                              FROM sys.tables TBL))
                       -- PK table with description
                    OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                         CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
                    AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                                  CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                                         FROM sys.tables TBL)))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidFKName = FKS.name
      FROM sys.foreign_keys FKS
      WHERE FKS.parent_object_id = @DBOObjectID
        AND (-- FK name
             FKS.name NOT LIKE 'FK\_' + @DBOName + '\_%' ESCAPE '\'
             -- PK table without description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') = ''
          AND REPLACE(FKS.name, 'FK_' + @DBOName + '_', '') NOT IN (SELECT TBL.name
                                                                    FROM sys.tables TBL))
             -- PK table with description
          OR (ISNULL(SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                               CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))), '') <> ''
          AND SUBSTRING(REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''), 0, 
                        CHARINDEX('_', REPLACE(FKS.name, 'FK_' + @DBOName + '_', ''))) NOT IN (SELECT TBL.name
                                                                                               FROM sys.tables TBL)));
    END;
    
    ---------------------------------------------------------------------------
    -- validate foreignkeys having at least one index that starts with column
    -- --> valid are IX or UK
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.foreign_keys FKS
                  INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                                        AND FKC.constraint_object_id = FKS.object_id
                  INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                                        AND COL.column_id = FKC.parent_column_id
                WHERE FKS.parent_object_id = @DBOObjectID
                  AND NOT EXISTS (SELECT TOP 1 1
                                  FROM sys.indexes IDX
                                  WHERE IDX.object_id = @DBOObjectID
                                    AND IDX.type = 2            -- only NONCLUSTERED
                                    AND IDX.is_primary_key = 0  -- only FKs
                                    AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                                         IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                                         IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'))))
    BEGIN
      PRINT ('>>> Error: There is at least one FK which does not have an index assigned (each FK should have its IX or UK)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT MissingIXOrUKForFKCol = COL.name,
             MissingIXOrUKForFK    = FKS.name
      FROM sys.foreign_keys FKS
        INNER JOIN sys.foreign_key_columns FKC ON FKC.parent_object_id = FKS.parent_object_id
                                              AND FKC.constraint_object_id = FKS.object_id
        INNER JOIN sys.columns             COL ON COL.object_id = @DBOObjectID
                                              AND COL.column_id = FKC.parent_column_id
      WHERE FKS.parent_object_id = @DBOObjectID
        AND NOT EXISTS (SELECT TOP 1 1
                        FROM sys.indexes IDX
                        WHERE IDX.object_id = @DBOObjectID
                          AND IDX.type = 2            -- only NONCLUSTERED
                          AND IDX.is_primary_key = 0  -- only FKs
                          AND (IDX.name = 'IX_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'IX\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\' OR
                               IDX.name = 'UK_' + @DBOName + '_' + COL.name OR 
                               IDX.name LIKE 'UK\_' + @DBOName + '\_' + COL.name + '\_%' ESCAPE '\'));
    END;
    
    ---------------------------------------------------------------------------
    -- foreignkeys sorting just after PK in table
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate collation of columns
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.columns COL
                WHERE COL.object_id = @DBOObjectID
                  AND COL.collation_name IS NOT NULL
                  AND COL.collation_name <> @COLLATION))
    BEGIN
      PRINT ('>>> Error: There is at least one column with non-standard collation ("' + @COLLATION + '")');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidCollationColumnName = COL.name,
             CollationNameOfColumn      = COL.collation_name
      FROM sys.columns COL
      WHERE COL.object_id = @DBOObjectID
        AND COL.collation_name IS NOT NULL
        AND COL.collation_name <> @COLLATION
      ORDER BY COL.column_id;
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming IX_<TableName>
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 0  -- no UKs
                  AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one IX which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidIXName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 0  -- no UKs
        AND name NOT LIKE 'IX\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- indexes naming (IX, UK) IX_<TableName>[<_ColumnName]+
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- unique-key naming (UK) UK_<TableName>...
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.indexes
                WHERE object_id = @DBOObjectID
                  AND type = 2                  -- NONCLUSTERED
                  AND is_unique_constraint = 1  -- UKs
                  AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\'))
    BEGIN
      PRINT ('>>> Error: There is at least one UK which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidUKName = name
      FROM sys.indexes
      WHERE object_id = @DBOObjectID
        AND type = 2                  -- NONCLUSTERED
        AND is_unique_constraint = 1  -- UKs
        AND name NOT LIKE 'UK\_' + @DBOName + '\_%' ESCAPE '\';
    END;
    
    ---------------------------------------------------------------------------
    -- unique-key type (UK) UK_<TableName>... >> no unique indexes
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- validate IX/UK having same filegroup as table
    ---------------------------------------------------------------------------
    IF ((SELECT COUNT(DISTINCT IDX.groupid)
         FROM sys.tables        TBL WITH (NOLOCK)
           LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                                 AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
         WHERE TBL.object_id = @DBOObjectID) > 1)
    BEGIN
      PRINT ('>>> Error: There is at least one IX/UK with different filegroup (each of them should have same as table)');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT TableName    = TBL.name,
             IndexName    = ISNULL(IDX.[name], 'NA'),
             IndexType    = CASE 
                              WHEN IDX.indid = 0 THEN 'Table Row Data (table has no clustered index)'
                              WHEN IDX.indid = 1 THEN 'Clustered Index (and table row data)'
                              WHEN IDX.indid = 255 THEN 'TEXT/NTEXT/IMAGE/XML Column Data'
                              ELSE 'NonClustered Index'
                            END,
              IndexID     = ISNULL(IDX.indid, -1),
              FileGroup   = FILEGROUP_NAME(IDX.groupid),
              FileGroupID = IDX.groupid
      FROM sys.tables        TBL WITH (NOLOCK)
        LEFT JOIN sysindexes IDX WITH (NOLOCK) ON IDX.id = TBL.object_id
                                              AND INDEXPROPERTY(IDX.id, IDX.name, 'IsAutoStatistics') = 0
      WHERE TBL.object_id = @DBOObjectID
      ORDER BY IndexID;
    END;
    
    ---------------------------------------------------------------------------
    -- validating default constraints DF
    ---------------------------------------------------------------------------
    IF (EXISTS (SELECT TOP 1 1
                FROM sys.objects OBJ
                WHERE OBJ.parent_object_id = @DBOObjectID
                  AND type = 'D'
                  AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
                    OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                             FROM sys.columns COL
                                                                             WHERE COL.object_id = @DBOObjectID))))
    BEGIN
      PRINT ('>>> Error: There is at least one DF which does not match the naming conventions');
      SET @ErrorCounter = @ErrorCounter + 1;
      
      -- show
      SELECT InvalidDefaultConstraintName = OBJ.name
      FROM sys.objects OBJ
      WHERE OBJ.parent_object_id = @DBOObjectID
        AND type = 'D'
        AND (OBJ.name NOT LIKE 'DF\_' + @DBOName + '\_%' ESCAPE '\'
          OR REPLACE(OBJ.name, 'DF_' + @DBOName + '_', '') NOT IN (SELECT COL.name
                                                                   FROM sys.columns COL
                                                                   WHERE COL.object_id = @DBOObjectID))
    END;
    
    ---------------------------------------------------------------------------
    -- constraints CK
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- trigger
    ---------------------------------------------------------------------------
    -- TODO
    
    ---------------------------------------------------------------------------
    -- extended properties for table
    ---------------------------------------------------------------------------
    -- table description
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND EXT.name = 'MS_Description'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have a description assigned (extended property "MS_Description")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    -- table author
    IF (NOT EXISTS (SELECT TOP 1 1
                    FROM sys.extended_properties EXT
                    WHERE EXT.major_id = @DBOObjectID
                      AND name = 'Author'
                      AND EXT.minor_id = 0
                      AND ISNULL(EXT.value, '') NOT IN ('', '(null)')))
    BEGIN
      PRINT ('>>> Error: The table "' + @DBOName + '" does not have an author assigned (extended property "Author")');
      SET @ErrorCounter = @ErrorCounter + 1;
    END;
    
    ---------------------------------------------------------------------------
    -- error?
    ---------------------------------------------------------------------------
    IF (@ErrorCounter = 0)
    BEGIN
      SET @FinalOutput = 'Info: The table "' + @DBOName + '" survived the basic checks without any remarks!';
    END
    ELSE
    BEGIN
      SET @FinalOutput = 'Info: The script detected <' + CONVERT(VARCHAR(50), @ErrorCounter) + '> problem(s) for table "' + @DBOName + '"!';
    END;
    
    -- done
    GOTO DONE;
  END;
  -- ==========================================================================
  
  -- ==========================================================================
  -- type not supported
  -- ==========================================================================
  PRINT ('>>> Error: The given database object "' + @DBOName + '" with type "' + @DBOType + '" is not supported for validation yet')
  RETURN 1;
  -- ==========================================================================

-- ****************************************************************************
-- FINAL STUFF
-- ****************************************************************************
DONE:
  IF (@ErrorCounter > 0)
  BEGIN
    PRINT ('');
  END;

  PRINT ('--------------------------------------------------------------------------------');
  PRINT @FinalOutput;
  PRINT ('--------------------------------------------------------------------------------');

  IF (@ErrorCounter = 0)
  BEGIN
    -- no problems
    PRINT ('                        boing         boing         boing');
    PRINT ('          e-e           . - .         . - .         . - .');
    PRINT ('         (\_/)\       ''       `.   ,''       `.   ,''       .');
    PRINT ('          `-''\ `--.___,         . .           . .          .');
    PRINT ('             ''\( ,_.-''''');
    PRINT ('                \\               "             "            a:f');
  END
  ELSE
  BEGIN
    -- found problems
    PRINT ('          \|||/');
    PRINT ('          (o o)');
    PRINT ('  ,~~~ooO~~(_)~~~~~~~~~~,');
    PRINT ('  |       Please        |');
    PRINT ('  |  fix the problems!  |');
    PRINT ('  |       Thanks!       |');
    PRINT ('  ''~~~~~~~~~~~~~~ooO~~~~''');
    PRINT ('         |__|__|');
    PRINT ('          || ||');
    PRINT ('         ooO Ooo');
  END;
  
  PRINT ('--------------------------------------------------------------------------------');
  
  -- return value
  RETURN CASE
           WHEN @ErrorCounter = 0 THEN 0    -- ok
           ELSE 1                           -- failure
         END;
END;
GO