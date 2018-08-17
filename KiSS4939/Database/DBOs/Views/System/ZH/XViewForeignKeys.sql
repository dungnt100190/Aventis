SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject XViewForeignKeys
GO

CREATE VIEW dbo.XViewForeignKeys AS
SELECT DISTINCT ForeignKeyName = sob.[Name],
                PKTable = OBJECT_NAME( sfk.rkeyid ),
                PKColumns = dbo.fnGetReferencedKeyColumnsOfForeignKey( sfk.constid ),
                FKTable = OBJECT_NAME( sfk.fkeyid ),
                FKColumns = dbo.fnGetForeignKeyColumnsOfForeignKey( sfk.constid )
FROM sysforeignkeys sfk
  INNER JOIN sysobjects sob
  ON sfk.constid = sob.id

GO
GRANT SELECT ON [dbo].[XViewForeignKeys] TO [tools_access]