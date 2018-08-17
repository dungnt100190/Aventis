SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXRowMerge;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXRowMerge
(
 @TableName VARCHAR(1000),
 @RowID INT,
 @RowID_Delete INT,
 @DeleteRow BIT = 1,
 @DebugOn BIT = 0
)
AS 
BEGIN
  SET NOCOUNT ON;
  
  DECLARE @PKeyName VARCHAR(1000);

  -- FIND PrimaryKey
  SELECT @PKeyName = MIN(col.Name)
  FROM sysobjects           tbl
    INNER JOIN syscolumns   col ON tbl.id = col.id
    INNER JOIN sysindexkeys idk ON idk.id = tbl.id
                               AND idk.colid = col.colid
    INNER JOIN sysindexes   idx ON idx.id = tbl.id
                               AND idk.indid = idx.indid
                               AND IDX.status & 2050 = 2050
  WHERE tbl.type = 'u'
    AND tbl.Name = @TableName
  GROUP BY tbl.Name
  HAVING COUNT(*) = 1;

  IF @PKeyName IS NOT NULL 
    BEGIN
      DECLARE @fTableName VARCHAR(400),
        @fColumnName VARCHAR(400),
        @sql VARCHAR(8000)

      -- Update FKeys
      DECLARE cur_SQLText CURSOR
        FOR SELECT  ftbl.name AS TableName,
                    fcol.name AS fColumnName,
                    'UPDATE [' + OBJECT_SCHEMA_NAME(FTBL.id) + '].[' + ftbl.name + '] SET [' + fcol.name + '] = ' + CONVERT(VARCHAR, @RowID) + '
      WHERE [' + fcol.name + '] = ' + CONVERT(VARCHAR, @RowID_Delete) AS sql
            FROM    sysforeignkeys fks
            INNER JOIN sysobjects fksn ON fks.constid = fksn.id
            INNER JOIN sysobjects rtbl ON fks.rkeyid = rtbl.id
            INNER JOIN syscolumns rcol ON rtbl.id = rcol.id
                                          AND fks.rkey = rcol.colid
            INNER JOIN sysobjects ftbl ON fks.fkeyid = ftbl.id
            INNER JOIN syscolumns fcol ON ftbl.id = fcol.id
                                          AND fks.fkey = fcol.colid
            WHERE   rtbl.name = @TableName
                    AND rcol.name = @PKeyName

      OPEN cur_SQLText

      FETCH FROM cur_SQLText INTO @fTableName, @fColumnName, @sql
      WHILE @@FETCH_STATUS = 0 
        BEGIN
          -- Delete Dublicate
          DECLARE @IndexName VARCHAR(500),
            @DeletePart VARCHAR(1000),
            @WherePart VARCHAR(1000)

          DECLARE cur_UniqueIndex CURSOR
            FOR SELECT  IDX.name AS IndexName,
                        'DELETE TBL1
          FROM [' + OBJECT_SCHEMA_NAME(TBL.id) + '].[' + TBL.name + ']  TBL1, [' + TBL.name + ']  TBL2 
          WHERE TBL1.[' + COL2.name + '] = ' + CONVERT(VARCHAR, @RowID_Delete) + ' AND TBL2.[' + COL2.name + '] = '
                        + CONVERT(VARCHAR, @RowID) AS DeletePart,
                        CASE WHEN COL.name != @fColumnName THEN ' AND TBL1.[' + COL.name + '] = TBL2.[' + COL.name + ']'
                             ELSE ''
                        END AS WherePart
                FROM    sysobjects TBL
                INNER JOIN syscolumns COL ON TBL.id = COL.id
                INNER JOIN sysindexes IDX ON IDX.id = TBL.id
                                             AND IDX.Status & 2 = 2
                INNER JOIN sysindexkeys IDK ON IDK.id = TBL.id
                                               AND IDK.indid = IDX.indid
                                               AND IDK.colid = COL.colid
                INNER JOIN sysindexkeys IDK2 ON IDK2.id = TBL.id
                                                AND IDK2.indid = IDX.indid
                INNER JOIN syscolumns COL2 ON TBL.id = COL2.id
                                              AND IDK2.colid = COL2.colid
                WHERE   TBL.name = @fTableName
                        AND COL2.name = @fColumnName
                ORDER BY 1

          DECLARE @PrevIndexName VARCHAR(500),
            @Uniquesql VARCHAR(4000)

          OPEN cur_UniqueIndex

          FETCH FROM cur_UniqueIndex INTO @IndexName, @DeletePart, @WherePart
          SET @PrevIndexName = @IndexName
          SET @Uniquesql = @DeletePart

          WHILE @@FETCH_STATUS = 0 
            BEGIN
              IF @PrevIndexName != @IndexName 
                BEGIN
                  IF @DebugOn = 1 
                    PRINT @Uniquesql
                  EXECUTE (@Uniquesql)

                  SET @PrevIndexName = @IndexName
                  SET @Uniquesql = @DeletePart
                END

              SET @Uniquesql = @Uniquesql + @WherePart

              FETCH FROM cur_UniqueIndex INTO @IndexName, @DeletePart, @WherePart
            END

          CLOSE cur_UniqueIndex
          DEALLOCATE cur_UniqueIndex

          IF @IndexName IS NOT NULL 
            BEGIN
              SET @sql = ISNULL(@Uniquesql + CHAR(13), '') + @sql
              SET @IndexName = NULL
            END

          IF @DebugOn = 1 
            PRINT @sql
          EXECUTE (@sql)

          FETCH FROM cur_SQLText INTO @fTableName, @fColumnName, @sql
        END

      CLOSE cur_SQLText
      DEALLOCATE cur_SQLText

      -- Delete Row
      IF @DeleteRow = 1 
        BEGIN
          DECLARE @SchemaName VARCHAR(50);
          SELECT @SchemaName = OBJECT_SCHEMA_NAME(object_id)
          FROM sys.tables T
          WHERE name = @TableName;

          SET @sql = 'DELETE FROM [' + @SchemaName + '].[' + @TableName + '] WHERE [' + @PKeyName + '] = ' + CONVERT(VARCHAR, @RowID_Delete)
      
          IF @DebugOn = 1 
            PRINT @sql
          EXECUTE (@sql)
        END;
    END;
END;
GO