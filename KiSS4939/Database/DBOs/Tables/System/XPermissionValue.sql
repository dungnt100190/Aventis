CREATE TABLE [dbo].[XPermissionValue] (
	[PermissionValueID] [int] IDENTITY (1, 1) NOT NULL ,
	[PermissionGroupID] [int] NOT NULL ,
	[PermissionCode] [int] NULL ,
	[BgPositionsartID] [int] NULL ,
	[Value] [sql_variant] NULL ,
	[XPermissionValueTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XPermissionValue] PRIMARY KEY  NONCLUSTERED
	(
		[PermissionValueID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XPermissionValue_BgPositionsart] FOREIGN KEY
	(
		[BgPositionsartID]
	) REFERENCES [dbo].[BgPositionsart] (
		[BgPositionsartID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_XPermissionValue_XPermissionGroup] FOREIGN KEY
	(
		[PermissionGroupID]
	) REFERENCES [dbo].[XPermissionGroup] (
		[PermissionGroupID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [PRIMARY]
GO
 CREATE  Clustered  INDEX [IX_XPermissionValue] ON [dbo].[XPermissionValue]([PermissionGroupID], [PermissionCode], [BgPositionsartID]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XPermissionValue Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XPermissionValue', N'column', N'PermissionValueID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XPermissionValue_XPermissionGroup) => XPermissionGroup.PermissionGroupID', N'user', N'dbo', N'table', N'XPermissionValue', N'column', N'PermissionGroupID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XPermissionValue_BgPositionsart) => BgPositionsart.BgPositionsartID', N'user', N'dbo', N'table', N'XPermissionValue', N'column', N'BgPositionsartID'
GO

GO

GO

GO

GO

GO

GO

GO
