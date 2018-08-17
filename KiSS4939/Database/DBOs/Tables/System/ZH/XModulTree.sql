CREATE TABLE [dbo].[XModulTree](
	[ModulTreeID] [int] NOT NULL,
	[ModulTreeID_Parent] [int] NULL,
	[ModulID] [int] NOT NULL,
	[SortKey] [int] NOT NULL,
	[XIconID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[NameTID] [int] NULL,
	[ClassName] [varchar](255) NULL,
	[MaskName] [varchar](100) NULL,
	[sqlPreExecute] [varchar](2000) NULL,
	[ModulTreeCode] [int] NOT NULL,
	[sqlInsertTreeItem] [varchar](4000) NULL,
	[Active] [bit] NOT NULL,
	[XModulTreeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XModulTree] PRIMARY KEY NONCLUSTERED 
(
	[ModulTreeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM],
 CONSTRAINT [IX_XModulTree_ModulTreeID] UNIQUE NONCLUSTERED 
(
	[ModulTreeID] ASC,
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
) ON [SYSTEM]

GO

SET ANSI_PADDING ON
GO


CREATE UNIQUE CLUSTERED INDEX [IX_XModulTree] ON [dbo].[XModulTree] 
(
	[ModulID] ASC,
	[ModulTreeID_Parent] ASC,
	[SortKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [SYSTEM]
GO

ALTER TABLE [dbo].[XModulTree]  WITH CHECK ADD  CONSTRAINT [FK_XModulTree_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[XModulTree] CHECK CONSTRAINT [FK_XModulTree_XClass]
GO

ALTER TABLE [dbo].[XModulTree]  WITH CHECK ADD  CONSTRAINT [FK_XModulTree_XIcon] FOREIGN KEY([XIconID])
REFERENCES [dbo].[XIcon] ([XIconID])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[XModulTree] CHECK CONSTRAINT [FK_XModulTree_XIcon]
GO

ALTER TABLE [dbo].[XModulTree]  WITH CHECK ADD  CONSTRAINT [FK_XModulTree_XModulTree] FOREIGN KEY([ModulTreeID_Parent], [ModulID])
REFERENCES [dbo].[XModulTree] ([ModulTreeID], [ModulID])
GO

ALTER TABLE [dbo].[XModulTree] CHECK CONSTRAINT [FK_XModulTree_XModulTree]
GO

ALTER TABLE [dbo].[XModulTree] ADD  CONSTRAINT [DF_XModulTree_SortKey]  DEFAULT ((9999)) FOR [SortKey]
GO

ALTER TABLE [dbo].[XModulTree] ADD  CONSTRAINT [DF_XModulTree_XIconID]  DEFAULT ((0)) FOR [XIconID]
GO

ALTER TABLE [dbo].[XModulTree] ADD  CONSTRAINT [DF_XModulTree_ModulTreeCode]  DEFAULT ((1)) FOR [ModulTreeCode]
GO

ALTER TABLE [dbo].[XModulTree] ADD  CONSTRAINT [DF_XModulTree_Active]  DEFAULT ((1)) FOR [Active]
GO


