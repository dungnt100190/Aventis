SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDropTableRef
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Create KiSS4_TestDB/02_spDropTableRef.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:46 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Create KiSS4_TestDB/02_spDropTableRef.sql $
 * 
 * 2     25.06.09 11:44 Ckaeser
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
CREATE PROCEDURE dbo.spDropTableRef
 (@TableName      sysname,
  @FieldName      sysname = NULL,
  @DropDefaults   bit     = 0,
  @DropPrimaryKey bit     = 1,
  @DropConstraint bit     = 1,
  @DropIndex      bit     = 1,
  @DropTrigger    bit     = 0)
AS 

BEGIN
  SET NOCOUNT ON

  DECLARE @sql         varchar(8000),
          @Table_ObjID int

  SET @Table_ObjID = OBJECT_ID(@TableName)


  DECLARE cSQL CURSOR FORWARD_ONLY STATIC READ_ONLY FOR
    SELECT DISTINCT 'ALTER TABLE [dbo].[' + OBJECT_NAME(fks.fkeyid) + '] DROP CONSTRAINT [' + OBJECT_NAME(fks.constid) + ']'
    FROM sysforeignkeys       fks
      INNER JOIN syscolumns   rcol ON fks.rkeyid = rcol.id AND fks.rkey = rcol.colid
    WHERE fks.rkeyid = @Table_ObjID AND @DropConstraint = 1 AND fks.fkeyid <> fks.rkeyid
      AND rcol.name  = IsNull(@FieldName, rcol.name)

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + OBJECT_NAME(fks.fkeyid) + '] DROP CONSTRAINT [' + OBJECT_NAME(fks.constid) + ']'
    FROM sysforeignkeys       fks
      INNER JOIN syscolumns   fcol ON fks.fkeyid = fcol.id AND fks.fkey = fcol.colid
    WHERE fks.fkeyid = @Table_ObjID AND @DropConstraint = 1
      AND fcol.name  = IsNull(@FieldName, fcol.name)

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + OBJECT_NAME(def.parent_obj) + '] DROP CONSTRAINT [' + def.name + ']'
    FROM sysobjects              def
      INNER JOIN sysconstraints  cnt ON cnt.constid = def.id AND cnt.id = def.parent_obj
      INNER JOIN syscolumns      col ON col.id = def.parent_obj AND col.colid = cnt.colid
    WHERE def.parent_obj = @Table_ObjID AND def.xtype IN ('D ') AND @DropDefaults = 1
      AND col.name = IsNull(@FieldName, col.name)

    UNION ALL

    SELECT DISTINCT CASE WHEN cnt.id IS NULL
                      THEN 'DROP  INDEX [dbo].[' + OBJECT_NAME(idx.id) + '].[' + idx.name + ']'
                      ELSE 'ALTER TABLE [dbo].[' + OBJECT_NAME(idx.id) + '] DROP CONSTRAINT [' + idx.name + ']'
                    END
    FROM sysindexes           idx
      INNER JOIN sysindexkeys idk ON idk.id = idx.id AND idk.indid  = idx.indid
      INNER JOIN syscolumns   col ON col.id = idk.id AND col.colid = idk.colid
      LEFT  JOIN sysobjects   cnt ON cnt.parent_obj = idx.id AND cnt.name = idx.name
    WHERE idx.status & 2050 <> 2050 AND ((cnt.id IS NULL AND @DropIndex = 1) OR (cnt.id IS NOT NULL AND @DropConstraint = 1))
      AND idx.id = @Table_ObjID AND col.name  = IsNull(@FieldName, col.name)
      AND idx.name NOT LIKE '_WA_Sys_%'

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + OBJECT_NAME(idx.id) + '] DROP CONSTRAINT [' + idx.name + ']'
    FROM sysindexes           idx
      INNER JOIN sysindexkeys idk ON idk.id = idx.id AND idk.indid  = idx.indid
      INNER JOIN syscolumns   col ON col.id = idk.id AND col.colid = idk.colid
    WHERE idx.status & 2050 = 2050 AND @DropPrimaryKey = 1
      AND idx.id = @Table_ObjID AND col.name = IsNull(@FieldName, col.name)
      AND idx.name NOT LIKE '_WA_Sys_%'

    UNION ALL

    SELECT DISTINCT 'DROP TRIGGER [dbo].[' + obj.name + ']'
    FROM sysobjects           obj
    WHERE obj.xtype = 'TR' AND @DropTrigger = 1
      AND obj.parent_obj = @Table_ObjID

  OPEN cSQL
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cSQL INTO @sql
    IF @@FETCH_STATUS < 0 BREAK

    PRINT '          ' + @sql
    EXECUTE (@sql)
  END

  CLOSE cSQL
  DEALLOCATE cSQL
END

GO