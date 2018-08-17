SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spRenameTable;
GO
/*===============================================================================================
  $Revision: 3 $
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

CREATE PROCEDURE dbo.spRenameTable
(
  @OldTableName VARCHAR(200),
  @NewTableName VARCHAR(200)
)
AS 
BEGIN
  IF (EXISTS (SELECT TOP 1 1 
              FROM sysobjects 
              WHERE name = @OldTableName 
                AND xtype = 'U'))
  BEGIN
    EXECUTE sp_rename @OldTableName, @NewTableName, 'object';
    
    IF (@NewTableName NOT LIKE 'OLD[_][0-9][0-9][_]%')
    BEGIN
      DECLARE @OldName VARCHAR(200);
      DECLARE @NewName VARCHAR(200);
      DECLARE @ObjectType VARCHAR(200);
      
      SELECT @OldName = @OldTableName + 'ID', @NewName = @NewTableName + 'ID';
      EXECUTE spRenameColumn @NewTableName, @OldName, @NewName;
      
      SELECT @OldName = @OldTableName + 'TS', @NewName = @NewTableName + 'TS';
      EXECUTE spRenameColumn @NewTableName, @OldName, @NewName;
      
      DECLARE cRename CURSOR FAST_FORWARD FOR
        SELECT obj.name,
               CASE
                 WHEN obj.xtype = 'D'                                                    THEN 'DF_' + OBJECT_NAME(obj.parent_obj) + '_' + col.name
                 WHEN obj.name LIKE '%[_]' + REPLACE(@OldTableName, '_', '[_]') + '[_]%' THEN REPLACE(obj.name, '_' + @OldTableName + '_', '_' + @NewTableName + '_')
                 WHEN obj.name LIKE '%[_]' + REPLACE(@OldTableName, '_', '[_]')          THEN SUBSTRING(obj.name, 1, LEN(obj.name) - LEN(@OldTableName)) + @NewTableName
                 ELSE NULL
               END,
               'OBJECT'
        FROM sysobjects              obj
          INNER JOIN sysconstraints  cnt ON cnt.constid = obj.id 
                                        AND cnt.id = obj.parent_obj
          LEFT  JOIN syscolumns      col ON col.id = cnt.id 
                                        AND col.colid = cnt.colid
          LEFT  JOIN sysforeignkeys  fks ON fks.constid = cnt.constid
        WHERE obj.xtype IN ('F', 'D')
          AND OBJECT_ID(@NewTableName) IN (obj.parent_obj, fks.rkeyid, fks.fkeyid)
        
        UNION
        
        SELECT @NewTableName + '.' + name,
               CASE
                 WHEN name = 'PK_' + @OldTableName THEN 'PK_' + @NewTableName
                 WHEN name = 'IX_' + @OldTableName THEN 'IX_' + @NewTableName
                 ELSE 'IX_' + @NewTableName + SUBSTRING(name, LEN(@OldTableName) + 4, 1000)
               END,
               'INDEX'
        FROM sysindexes
        WHERE id = OBJECT_ID(@NewTableName)
          AND (name = 'PK_' + @OldTableName OR name LIKE 'IX[_]' + REPLACE(@OldTableName, '_', '[_]') + '%');
      
      OPEN cRename
      WHILE (1 = 1) 
      BEGIN
        FETCH NEXT 
        FROM cRename 
        INTO @OldName, @NewName, @ObjectType;
        
        IF (@@FETCH_STATUS < 0)
        BEGIN
          BREAK;
        END;
        
        IF (@OldName <> @NewName AND @NewName IS NOT NULL) 
        BEGIN
          PRINT '          EXECUTE sp_rename ''' + @OldName + ''', ''' + @NewName + ''', ''' + @ObjectType + '''';
          EXECUTE sp_rename @OldName, @NewName, @ObjectType;
        END;
      END;
      
      CLOSE cRename;
      DEALLOCATE cRename;
    END;
  END;
END;
GO