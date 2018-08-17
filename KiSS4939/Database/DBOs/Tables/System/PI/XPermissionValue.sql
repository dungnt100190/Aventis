CREATE TABLE [dbo].[XPermissionValue](
	[PermissionValueID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionGroupID] [int] NOT NULL,
	[PermissionCode] [int] NULL,
	[BgPositionsartID] [int] NULL,
	[Value] [sql_variant] NULL,
	[XPermissionValueTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XPermissionValue] PRIMARY KEY CLUSTERED 
(
	[PermissionValueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_XPermissionValue] ON [dbo].[XPermissionValue] 
(
	[PermissionGroupID] ASC,
	[PermissionCode] ASC,
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[XPermissionValue]  WITH CHECK ADD  CONSTRAINT [FK_XPermissionValue_XPermissionGroup] FOREIGN KEY([PermissionGroupID])
REFERENCES [dbo].[XPermissionGroup] ([PermissionGroupID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XPermissionValue] CHECK CONSTRAINT [FK_XPermissionValue_XPermissionGroup]
GO