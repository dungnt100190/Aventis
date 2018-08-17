SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXCreateTableScript;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script table as CREATE
    @TableName:      The name of the table to script
    @IncludeFKs:     Flag if foreign keys have to be scripted, too
    @IncludeIndexes: Flag if indexes have to be scripted, too
  -
  RETURNS: The CREATE script of the table
  -
  TEST:    DECLARE @Output VARCHAR(MAX); SET @Output = dbo.fnXCreateTableScript('BaAdresse', 0, 0); PRINT (@Output);
           DECLARE @Output VARCHAR(MAX); SET @Output = dbo.fnXCreateTableScript('BaAdresse', 1, 0); PRINT (@Output);
           DECLARE @Output VARCHAR(MAX); SET @Output = dbo.fnXCreateTableScript('BaAdresse', 1, 1); PRINT (@Output);
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE FUNCTION dbo.fnXCreateTableScript
(
  @TableName VARCHAR(255),
  @IncludeFKs BIT = 0,
  @IncludeIndexes BIT = 0
) 
RETURNS VARCHAR(MAX) 
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init
  ----------------------------------------------------------------------------- 
  DECLARE @Id   INT;
  DECLARE @i    INT; 
  DECLARE @i2   INT; 
  DECLARE @Sql  VARCHAR(MAX);
  DECLARE @Sql2 VARCHAR(MAX); 
  DECLARE @f1   VARCHAR(5);
  DECLARE @f2   VARCHAR(5); 
  DECLARE @f3   VARCHAR(5); 
  DECLARE @f4   VARCHAR(5); 
  DECLARE @T    VARCHAR(5);

  SELECT @Id = OBJECT_ID(@TableName), 
         @f1 = CHAR(13) + CHAR(10), 
         @f2 = ' ', 
         @f3 = @f1 + @f2, 
         @f4 = ',' + @f3;
  
  IF (@Id IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  DECLARE @Data TABLE
  ( 
    id INT IDENTITY PRIMARY KEY, 
    d  VARCHAR(MAX) NOT NULL, 
    ic INT NULL, 
    re INT NULL, 
    o  INT NOT NULL
  ); 

  -----------------------------------------------------------------------------
  -- columns
  -----------------------------------------------------------------------------
  WITH c 
  AS (SELECT c.column_id, 
             nr = ROW_NUMBER() OVER(ORDER BY c.column_id), 
             clr= COUNT(*) OVER(), 
             d = QUOTENAME(c.name) + ' ' + CASE 
                                             WHEN s.name = 'sys' OR c.is_computed = 1 THEN '' 
                                             ELSE QUOTENAME(s.name) + '.'
                                           END + 
                                           UPPER (CASE 
                                                    WHEN c.is_computed = 1 THEN '' 
                                                    WHEN s.name = 'sys' THEN t.name 
                                                    ELSE QUOTENAME(t.name) 
                                                  END) + 
                                           CASE 
                                             WHEN c.user_type_id != c.system_type_id OR c.is_computed = 1 THEN '' 
                                             WHEN t.name IN ('xml', 'uniqueidentifier', 'tinyint', 'timestamp', 
                                                             'time', 'text', 'sysname', 'sql_variant', 
                                                             'smallmoney', 'smallint', 'smalldatetime', 
                                                             'ntext', 'money', 'int', 'image', 'hierarchyid', 
                                                             'geometry', 'geography', 'float', 'datetimeoffset', 
                                                             'datetime2', 'datetime', 'date', 'bigint', 'bit') THEN '' 
                                             WHEN t.name IN ('varchar', 'varbinary', 'real', 'numeric', 'decimal', 'char', 'binary') 
                                               THEN  '(' + ISNULL(CONVERT(VARCHAR, NULLIF(c.max_length, -1)), 'MAX') + 
                                                     ISNULL(',' + CONVERT(VARCHAR, NULLIF(c.scale, 0)), '') + ')' 
                                             WHEN t.name IN ('nvarchar', 'nchar') 
                                               THEN '(' + ISNULL(CONVERT(VARCHAR, NULLIF(c.max_length, -1) / 2), 'MAX') + 
                                                    ISNULL(',' + CONVERT(VARCHAR, NULLIF(c.scale, 0)), '') + ')'
                                               ELSE '??' 
                                           END + 
                                           CASE 
                                             WHEN ic.object_id IS NOT NULL THEN ' IDENTITY(' + 
                                                  CONVERT(VARCHAR, ic.seed_value) + ',' + 
                                                  CONVERT(VARCHAR, ic.increment_value) + ')' 
                                             ELSE '' 
                                           END + 
                                           CASE 
                                             WHEN c.is_computed = 1 THEN 'AS' + cc.definition 
                                             WHEN c.is_nullable = 1 THEN ' NULL' 
                                             ELSE ' NOT NULL' 
                                           END + 
                                           CASE c.is_rowguidcol 
                                             WHEN 1 THEN ' ROWGUIDCOL' 
                                             ELSE '' 
                                           END + 
                                           CASE 
                                             WHEN d.object_id IS NOT NULL THEN ' DEFAULT ' + d.definition 
                                             ELSE '' 
                                           END 
      FROM sys.columns                          c 
        INNER JOIN sys.types                    t  ON t.user_type_id = c.user_type_id 
        INNER JOIN sys.schemas                  s  ON s.schema_id = t.schema_id 
        LEFT OUTER JOIN sys.computed_columns    cc ON cc.object_id = c.object_id 
                                                  AND cc.column_id = c.column_id 
        LEFT OUTER JOIN sys.default_constraints d  ON d.parent_object_id = @id 
                                                  AND d.parent_column_id = c.column_id 
        LEFT OUTER JOIN sys.identity_columns    ic ON ic.object_id = c.object_id 
                                                  AND ic.column_id = c.column_id 
      WHERE c.object_id = @Id)
  
  INSERT INTO @Data (d, o) 
    SELECT d = ' ' + d + CASE nr 
                           WHEN clr THEN '' 
                           ELSE ',' + @f1 
                         END, 
           o = 0
    FROM c 
    ORDER BY column_id;

  -----------------------------------------------------------------------------
  -- sub-objects
  -----------------------------------------------------------------------------
  SET @i=0;
  
  WHILE (1 = 1)
  BEGIN
    SELECT TOP 1 
           @i  = c.object_id, 
           @T  = c.type, 
           @i2 = i.index_id
    FROM sys.objects c 
      LEFT OUTER JOIN sys.indexes i ON i.object_id = @Id 
                                   AND i.name = c.name
    WHERE parent_object_id = @Id 
      AND c.object_id > @i 
      AND c.type NOT IN('D')
    ORDER BY c.object_id;
    
    IF (@@ROWCOUNT = 0)
    BEGIN
      BREAK;
    END;
    
    IF (@T = 'C')
    BEGIN
      INSERT INTO @Data 
        SELECT @f4 + 
               'CHECK ' + 
               CASE is_not_for_replication 
                 WHEN 1 THEN 'NOT FOR REPLICATION ' 
                 ELSE '' 
               END + 
               definition, 
               null, 
               null, 
               10
        FROM sys.check_constraints 
        WHERE object_id = @i;
    END
    ELSE IF (@T = 'Pk')
    BEGIN
      INSERT INTO @Data 
        SELECT @f4 + 'PRIMARY KEY' + ISNULL(' ' + NULLIF(UPPER(i.type_desc), 'CLUSTERED'), ''), 
               @i2, 
               NULL, 
               20
        FROM sys.indexes i
        WHERE i.object_id = @Id 
          AND i.index_id = @i2;
    END
    ELSE IF (@T = 'uq')
    BEGIN
      INSERT INTO @Data 
      VALUES (@f4 + 'UNIQUE', @i2, NULL, 30);
    END
    ELSE IF (@T = 'f')
    BEGIN
      IF (@IncludeFKs = 1)
      BEGIN
        INSERT INTO @Data 
          SELECT @f4 + 'FOREIGN KEY', 
                 -1, 
                 @i, 
                 40
          FROM sys.foreign_keys f
          WHERE f.object_id = @i;
        
        INSERT INTO @Data 
          SELECT ' REFERENCES ' + QUOTENAME(s.name) + '.' + QUOTENAME(o.name), 
                 -2, 
                 @i, 
                 41
          FROM sys.foreign_keys    f
            INNER JOIN sys.objects o ON o.object_id = f.referenced_object_id
            INNER JOIN sys.schemas s ON s.schema_id = o.schema_id
          WHERE f.object_id = @i;
        
        INSERT INTO @Data 
          SELECT ' NOT FOR REPLICATION', 
                 -3, 
                 @i, 
                 42
          FROM sys.foreign_keys    f
            INNER JOIN sys.objects o ON o.object_id = f.referenced_object_id
            INNER JOIN sys.schemas s ON s.schema_id = o.schema_id
          WHERE f.object_id = @i 
            AND f.is_not_for_replication = 1;
      END;
    END
    ELSE IF (@T = 'TR')
    BEGIN
      -- Triggers are not supported yet
      INSERT INTO @Data 
        SELECT '', -1, '', -1
        WHERE 1 = 2;
    END
    ELSE
    BEGIN
      INSERT INTO @Data 
      VALUES (@f4 + 'Unknow SubObject [' + @T + ']', NULL, NULL, 99);
    END;
  END;
  
  INSERT INTO @Data 
  VALUES (@f1 + ')', NULL, NULL, 100);
  
  -----------------------------------------------------------------------------
  -- Indexes
  -----------------------------------------------------------------------------
  IF (@IncludeIndexes = 1)
  BEGIN
    INSERT INTO @Data 
      SELECT @f1 + 'CREATE ' + 
                   CASE is_unique 
                     WHEN 1 THEN 'UNIQUE ' 
                     ELSE '' 
                   END + 
                   UPPER(s.type_desc) + ' INDEX ' + QUOTENAME(s.name) + 
                   ' ON ' + 
                   QUOTENAME(sc.name) + '.' + QUOTENAME(o.name), 
             index_id, 
             NULL, 
             1000 
      FROM sys.indexes         s 
        INNER JOIN sys.objects o  ON o.object_id = s.object_id 
        INNER JOIN sys.schemas sc ON sc.schema_id = o.schema_id 
      WHERE s.object_id = @Id 
        AND is_unique_constraint = 0 
        AND is_primary_key = 0 
        AND s.type_desc != 'heap';
  END;
  
  -----------------------------------------------------------------------------
  -- columns
  -----------------------------------------------------------------------------
  SET @i = 0;

  WHILE (1 = 1)
  BEGIN 
    SELECT TOP 1 
           @i = ic 
    FROM @Data 
    WHERE ic > @i 
    ORDER BY ic;

    IF (@@ROWCOUNT = 0)
      BREAK 

    SELECT @i2 = 0, 
           @Sql = NULL, 
           @Sql2 = NULL;

    WHILE (1 = 1)
    BEGIN 
      SELECT @i2   = index_column_id, 
             @Sql  = CASE c.is_included_column 
                       WHEN 1 THEN @Sql 
                       ELSE ISNULL(@Sql + ', ', '(') + cc.name + CASE c.is_descending_key 
                                                                   WHEN 1 THEN ' DESC' 
                                                                   ELSE '' 
                                                                 END 
                     END, 
             @Sql2 = CASE c.is_included_column 
                       WHEN 0 THEN @Sql2 
                       ELSE ISNULL(@Sql2 + ', ', '(') + cc.name + CASE c.is_descending_key 
                                                                    WHEN 1 THEN ' DESC' 
                                                                    ELSE '' 
                                                                  END 
                     END 
      FROM sys.index_columns   c 
        INNER JOIN sys.columns cc ON c.column_id = cc.column_id 
                                 AND cc.object_id = c.object_id 
      WHERE c.object_id = @Id 
        AND index_id = @i 
        AND index_column_id > @i2 
      ORDER BY index_column_id;

      IF (@@ROWCOUNT = 0)
      BEGIN
        BREAK;
      END;
    END;

    UPDATE @Data 
    SET d = d + @Sql + ')' + ISNULL(' INCLUDE' + @Sql2 + ')', '') 
    WHERE ic = @i;
  END;
  
  -----------------------------------------------------------------------------
  -- references 
  -----------------------------------------------------------------------------
  SET @i = 0;

  WHILE (1 = 1)
  BEGIN 
    SELECT TOP 1 
           @i = re 
    FROM @Data 
    WHERE re > @i 
    ORDER BY re 
    
    IF (@@ROWCOUNT = 0)
    BEGIN
      BREAK;
    END;
    
    SELECT @i2   = 0, 
           @Sql  = NULL, 
           @Sql2 = NULL;
    
    WHILE (1 = 1)
    BEGIN 
      SELECT @i2   = f.constraint_column_id, 
             @Sql  = ISNULL(@Sql + ', ', '(') + c1.name, 
             @Sql2 = ISNULL(@Sql2 + ', ', '(') + c2.name 
      FROM sys.foreign_key_columns f 
        INNER JOIN sys.columns     c1 ON c1.column_id = f.parent_column_id 
                                     AND c1.object_id = f.parent_object_id 
        INNER JOIN sys.columns     c2 ON c2.column_id = f.referenced_column_id 
                                     AND c2.object_id = f.referenced_object_id 
       WHERE  f.constraint_object_id = @i 
          AND f.constraint_column_id > @i2 
       ORDER BY f.constraint_column_id;
       
       IF (@@ROWCOUNT = 0)
       BEGIN
         BREAK;
       END;
     END;
       
     UPDATE @Data 
     SET d = d + @Sql + ')' 
     WHERE re = @i 
       AND ic = -1;

     UPDATE @Data 
     SET d = d + @Sql2 + ')' 
     WHERE re = @i 
       AND ic = -2; 
  END;

  -----------------------------------------------------------------------------
  -- render
  -----------------------------------------------------------------------------
  WITH x 
  AS (SELECT id = d.id - 1, 
             d  = d.d + ISNULL(d2.d, '') 
      FROM @Data              d 
        LEFT OUTER JOIN @Data d2 ON d.re = d2.re 
                                AND d2.o = 42 
      WHERE  d.o = 41)
  
  UPDATE @Data 
  SET d = d.d + x.d 
  FROM @Data d 
    INNER JOIN x ON x.id = d.id;
  
  DELETE @Data
  WHERE o IN (41, 42);
  
  SELECT @Sql = 'CREATE TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(o.name) + @f1 + '(' + @f1 
  FROM sys.objects         o 
    INNER JOIN sys.schemas s ON o.schema_id = s.schema_id 
  WHERE o.object_id = @Id;
  
  SET @i=0;
  
  WHILE 1 = 1 
  BEGIN 
    SELECT TOP 1 
           @I = id, 
           @Sql = @Sql + d 
    FROM   @Data 
    ORDER BY o, 
             CASE 
               WHEN o = 0 THEN RIGHT('0000' + CONVERT(VARCHAR, id), 5) 
               ELSE d 
             END, 
             id;

    IF (@@ROWCOUNT = 0)
    BEGIN
      BREAK;
    END;
    
    DELETE @Data 
    WHERE id = @i;
  END;
  
  -----------------------------------------------------------------------------
  -- done, return result
  -----------------------------------------------------------------------------
  RETURN @Sql;
END
GO