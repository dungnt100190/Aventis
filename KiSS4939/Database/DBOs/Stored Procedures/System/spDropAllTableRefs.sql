SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDropAllTableRefs
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spDropAllTableRefs.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:16 $
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
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spDropAllTableRefs.sql $
 * 
 * 2     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spDropAllTableRefs
(
  @TableName      varchar(776),
  @DropDefaults   bit          = 0
)
AS BEGIN
  SET NOCOUNT ON

  DECLARE  @sql       varchar(512)
  DECLARE  @Table_ObjID     int

  SELECT   @Table_ObjID = object_id(@TableName)

  DECLARE Table_cursor CURSOR FORWARD_ONLY STATIC READ_ONLY FOR
    SELECT DISTINCT 'ALTER TABLE [dbo].[' + object_name(fkeyid) + '] DROP CONSTRAINT [' + object_name(constid) + ']'
    FROM   sysreferences
    WHERE  rkeyid = @Table_ObjID AND NOT (fkeyid = @Table_ObjID)

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + @TableName + '] DROP CONSTRAINT [' + name + ']'
    FROM   sysobjects
    WHERE  parent_obj = @Table_ObjID AND
      (xtype IN ('C ','UQ','F ')
        OR (xtype IN ('D ') AND @DropDefaults = 1))

    UNION ALL

    SELECT DISTINCT 'ALTER TABLE [dbo].[' + @TableName + '] DROP CONSTRAINT [' + name + ']'
    FROM   sysobjects
    WHERE  parent_obj = @Table_ObjID and
           xtype in ('PK')

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