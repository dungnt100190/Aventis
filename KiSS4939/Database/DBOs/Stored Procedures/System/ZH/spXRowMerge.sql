SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXRowMerge
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spXRowMerge.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:49 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spXRowMerge.sql $
 * 
 * 3     11.12.09 12:51 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spXRowMerge]
 (@TableName    varchar(1000),
  @RowID        int,
  @RowID_Delete int,
  @DeleteRow    bit = 1,
  @DebugOn      bit = 0)
AS BEGIN
  SET NOCOUNT ON

  --mim für FAMOZ: Bereits an PSCD übertragene Personen/Institutionen dürfen nicht gelöscht werden
  DECLARE @msg varchar(400)
  IF @TableName = 'BaPerson' AND EXISTS (SELECT * FROM PscdSentBaPerson WHERE BaPersonID = @RowID_Delete)  BEGIN
    SET @msg = 'Die Person mit ID ' + CAST(@RowID_Delete AS varchar) + ' ist bereits in PSCD angelegt und kann nicht mehr gelöscht werden'
    RAISERROR(@msg, 18, 1)
  END
  IF @TableName = 'BaInstitution' AND EXISTS (SELECT * FROM PscdSentBaInstitution WHERE BaInstitutionID = @RowID_Delete)  BEGIN
    SET @msg = 'Die Institution mit ID ' + CAST(@RowID_Delete AS varchar) + ' ist bereits in PSCD angelegt und kann nicht mehr gelöscht werden'
    RAISERROR(@msg, 18, 1)
  END

  DECLARE @PKeyName  varchar(1000)

  -- FIND PrimaryKey
  SELECT @PKeyName = MIN(col.Name)
  FROM sysobjects             tbl
    INNER JOIN syscolumns     col ON tbl.id  = col.id
    INNER JOIN sysindexkeys   idk ON idk.id  = tbl.id AND idk.colid = col.colid
    INNER JOIN sysindexes     idx ON idx.id  = tbl.id AND idk.indid = idx.indid  AND IDX.Status & 2050 = 2050
  WHERE tbl.TYPE = 'u' AND tbl.Name = @TableName
  GROUP BY tbl.Name
  HAVING Count(*) = 1

  IF @PKeyName IS NOT NULL BEGIN
    DECLARE @fTableName  varchar(400),
            @fColumnName varchar(400),
            @SQL         varchar(8000)

    -- Update FKeys
    DECLARE cur_SQLText CURSOR FOR
      SELECT
        ftbl.Name AS TableName,
        fcol.Name AS fColumnName,
        'UPDATE [' + OBJECT_SCHEMA_NAME(FTBL.id) + '].[' + ftbl.Name + '] SET [' + fcol.Name + '] = ' + CONVERT(varchar, @RowID) + '
         WHERE [' + fcol.Name + '] = ' + CONVERT(varchar, @RowID_Delete) AS SQL
      FROM sysforeignkeys       fks
        INNER JOIN sysobjects   fksn ON fks.constid = fksn.id

        INNER JOIN sysobjects   rtbl ON fks.rkeyid = rtbl.id
        INNER JOIN syscolumns   rcol ON rtbl.id    = rcol.id AND fks.rkey = rcol.colid

        INNER JOIN sysobjects   ftbl ON fks.fkeyid = ftbl.id
        INNER JOIN syscolumns   fcol ON ftbl.id    = fcol.id AND fks.fkey = fcol.colid
      WHERE rtbl.Name = @TableName AND rcol.Name = @PKeyName

    OPEN cur_SQLText

    FETCH FROM cur_SQLText INTO @fTableName, @fColumnName, @SQL
    WHILE @@FETCH_STATUS = 0 BEGIN

      -- Delete Dublicate
      DECLARE @IndexName   varchar(500),
              @DeletePart  varchar(1000),
              @WherePart   varchar(1000)

      DECLARE cur_UniqueIndex CURSOR FOR
        SELECT
          IDX.Name                                                                 AS IndexName,
          'DELETE TBL1
           FROM [' + OBJECT_SCHEMA_NAME(TBL.id) + '].[' + TBL.Name + ']  TBL1, [' + TBL.Name + ']  TBL2 
           WHERE TBL1.[' + COL2.Name + '] = ' + CONVERT(varchar, @RowID_Delete) +
           ' AND TBL2.[' + COL2.Name + '] = ' + CONVERT(varchar, @RowID)           AS DeletePart,
          CASE WHEN COL.Name != @fColumnName THEN
            ' AND TBL1.[' + COL.Name + '] = TBL2.[' + COL.Name + ']'
          ELSE '' END                                                              AS WherePart
        FROM sysobjects           TBL
          INNER JOIN syscolumns   COL ON TBL.id = COL.id

          INNER JOIN sysindexes   IDX ON IDX.id = TBL.id AND IDX.Status & 2 = 2
          INNER JOIN sysindexkeys IDK ON IDK.id = TBL.id AND IDK.indid  = IDX.indid AND IDK.colid = COL.colid

          INNER JOIN sysindexkeys IDK2 ON IDK2.id = TBL.id AND IDK2.indid  = IDX.indid
          INNER JOIN syscolumns   COL2 ON TBL.id = COL2.id AND IDK2.colid = COL2.colid
        WHERE TBL.Name = @fTableName AND COL2.Name = @fColumnName
        ORDER BY 1

      DECLARE @PrevIndexName  varchar(500),
              @Uniquesql      varchar(4000)

      OPEN cur_UniqueIndex

      FETCH FROM cur_UniqueIndex INTO @IndexName, @DeletePart, @WherePart
      SET @PrevIndexName = @IndexName
      SET @Uniquesql = @DeletePart

      WHILE @@FETCH_STATUS = 0 BEGIN
        IF @PrevIndexName != @IndexName BEGIN
          IF @DebugOn = 1 PRINT @Uniquesql
          EXECUTE(@Uniquesql)

          SET @PrevIndexName = @IndexName
          SET @Uniquesql = @DeletePart
        END

        SET @Uniquesql = @Uniquesql + @WherePart

        FETCH FROM cur_UniqueIndex INTO @IndexName, @DeletePart, @WherePart
      END

      CLOSE cur_UniqueIndex
      DEALLOCATE cur_UniqueIndex

      IF @IndexName IS NOT NULL BEGIN
        SET @SQL = IsNull(@Uniquesql + char(13), '')
                 + @SQL
        SET @IndexName = NULL
      END

      IF @DebugOn = 1 PRINT @SQL
      EXECUTE(@SQL)

      FETCH FROM cur_SQLText INTO @fTableName, @fColumnName, @SQL
    END

    CLOSE cur_SQLText
    DEALLOCATE cur_SQLText

    -- Delete Row
    IF @DeleteRow = 1 BEGIN
      DECLARE @SchemaName VARCHAR(50);
      SELECT @SchemaName = OBJECT_SCHEMA_NAME(object_id)
      FROM sys.tables T
      WHERE name = @TableName;

      SET @SQL = 'DELETE FROM [' + @SchemaName + '].[' + @TableName + '] WHERE [' + @PKeyName + '] = ' + CONVERT(varchar, @RowID_Delete)

      IF @DebugOn = 1 PRINT @SQL
      EXECUTE(@SQL)
    END
  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
