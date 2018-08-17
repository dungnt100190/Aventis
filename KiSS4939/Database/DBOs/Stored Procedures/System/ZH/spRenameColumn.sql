SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spRenameColumn
GO
/*===============================================================================================
  $Revision: 1 $
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
 (@TableName varchar(200),
  @OldColumnName varchar(200),
  @NewColumnName varchar(200))
AS BEGIN
  IF EXISTS (SELECT * FROM syscolumns WHERE id = OBJECT_ID(@TableName) AND Name = @OldColumnName) BEGIN
    DECLARE @objname varchar(400)

    SET @objname = @TableName + '.' + @OldColumnName

    EXEC sp_rename @objname, @NewColumnName, 'column'
  END
END
