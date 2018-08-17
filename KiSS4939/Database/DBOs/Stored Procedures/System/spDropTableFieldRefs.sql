SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDropTableFieldRefs
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spDropTableFieldRefs.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:15 $
  $Revision: 2 $
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
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spDropTableFieldRefs.sql $
 * 
 * 2     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spDropTableFieldRefs
(
  @TableName      varchar(776),
  @FieldName      varchar(776)
)
AS BEGIN
  SET NOCOUNT ON

  DECLARE  @sql         varchar(512)
  DECLARE  @Table_ObjID int
  DECLARE  @Field_ObjID int

  SELECT   @Table_ObjID = object_id(@TableName)
  SELECT   @Field_ObjID = object_id(@FieldName)

  DECLARE Table_cursor CURSOR FORWARD_ONLY STATIC READ_ONLY FOR
    SELECT DISTINCT 'ALTER TABLE [dbo].[' + object_name(fks.rkeyid) + '] DROP CONSTRAINT [' + object_name(fks.constid) + ']'
    FROM sysforeignkeys       fks
      INNER JOIN syscolumns   rcol ON fks.rkeyid = rcol.id AND fks.rkey = rcol.colid
    WHERE fks.rkeyid = @Table_ObjID AND fks.fkeyid <> fks.rkeyid
      AND rcol.name  = @FieldName

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + object_name(fks.fkeyid) + '] DROP CONSTRAINT [' + object_name(fks.constid) + ']'
    FROM sysforeignkeys       fks
      INNER JOIN syscolumns   fcol ON fks.fkeyid = fcol.id AND fks.fkey = fcol.colid
    WHERE fks.fkeyid = @Table_ObjID
      AND fcol.name  = @FieldName

    UNION ALL

    SELECT DISTINCT CASE WHEN cnt.id IS NULL
                      THEN 'DROP  INDEX [dbo].[' + object_name(idx.id) + '].[' + idx.name + ']'
                      ELSE 'ALTER TABLE [dbo].[' + object_name(idx.id) + '] DROP CONSTRAINT [' + idx.name + ']'
                    END
    FROM sysindexes           idx
      INNER JOIN sysindexkeys idk ON idk.id = idx.id AND idk.indid  = idx.indid
      INNER JOIN syscolumns   col ON col.id = idk.id AND col.colid = idk.colid
      LEFT  JOIN sysobjects   cnt ON cnt.parent_obj = idx.id AND cnt.name = idx.name
    WHERE idx.status & 2050 <> 2050
      AND idx.id = @Table_ObjID AND col.name  = @FieldName
      AND idx.name NOT LIKE '_WA_Sys_%'

    UNION ALL

    SELECT DISTINCT CASE WHEN cnt.id IS NULL
                      THEN 'DROP  INDEX [dbo].[' + object_name(idx.id) + '].[' + idx.name + ']'
                      ELSE 'ALTER TABLE [dbo].[' + object_name(idx.id) + '] DROP CONSTRAINT [' + idx.name + ']'
                    END
    FROM sysindexes           idx
      INNER JOIN sysindexkeys idk ON idk.id = idx.id AND idk.indid  = idx.indid
      INNER JOIN syscolumns   col ON col.id = idk.id AND col.colid = idk.colid
      LEFT  JOIN sysobjects   cnt ON cnt.parent_obj = idx.id AND cnt.name = idx.name
    WHERE idx.status & 2050 = 2050
      AND idx.id = @Table_ObjID AND col.name = @FieldName
      AND idx.name NOT LIKE '_WA_Sys_%'

  OPEN Table_cursor
  FETCH NEXT FROM Table_cursor INTO @sql
  WHILE @@FETCH_STATUS = 0 BEGIN
    PRINT '          ' + @sql
    EXECUTE (@sql)
    FETCH NEXT FROM Table_cursor INTO @sql
  END

  CLOSE Table_cursor
  DEALLOCATE Table_cursor
END
GO