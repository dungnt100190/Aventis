SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spRenameColumn;
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

CREATE PROCEDURE dbo.spRenameColumn
(
  @TableName VARCHAR(200),
  @OldColumnName VARCHAR(200),
  @NewColumnName VARCHAR(200)
)
AS 
BEGIN
  DECLARE @OldName VARCHAR(200);
  DECLARE @NewName VARCHAR(200);
  DECLARE @ObjectType VARCHAR(200);
  
  DECLARE cRename CURSOR FAST_FORWARD FOR
    SELECT @TableName + '.' + @OldColumnName, @NewColumnName, 'COLUMN'
    FROM syscolumns
    WHERE id = OBJECT_ID(@TableName) 
      AND name = @OldColumnName
    
    UNION ALL
    
    SELECT obj.name, 'DF_' + OBJECT_NAME(obj.parent_obj) + '_' + @NewColumnName, 'OBJECT'
    FROM sysobjects              obj
      INNER JOIN sysconstraints  cnt ON cnt.constid = obj.id 
                                    AND cnt.id = obj.parent_obj
      INNER JOIN syscolumns      col ON col.id = cnt.id 
                                    AND col.colid = cnt.colid
    WHERE obj.xtype IN ('D') 
      AND obj.parent_obj = OBJECT_ID(@TableName)
      AND col.name IN (@OldColumnName, @NewColumnName);
  
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
GO