CREATE TABLE [dbo].[XModulTree] (
	[ModulTreeID] [int] NOT NULL ,
	[ModulTreeID_Parent] [int] NULL ,
	[ModulID] [int] NOT NULL ,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_XModulTree_SortKey] DEFAULT ((9999)),
	[XIconID] [int] NOT NULL CONSTRAINT [DF_XModulTree_XIconID] DEFAULT ((0)),
	[Name] [varchar] (100) NULL ,
	[NameTID] [int] NULL ,
	[ClassName] [varchar] (255) NULL ,
	[MaskName] [varchar] (100) NULL ,
	[sqlPreExecute] [varchar] (2000) NULL ,
	[ModulTreeCode] [int] NOT NULL CONSTRAINT [DF_XModulTree_ModulTreeCode] DEFAULT ((1)),
	[sqlInsertTreeItem] [varchar] (2000) NULL ,
	[Active] [bit] NOT NULL CONSTRAINT [DF_XModulTree_Active] DEFAULT ((1)),
	[XModulTreeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XModulTree] PRIMARY KEY  NONCLUSTERED
	(
		[ModulTreeID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [IX_XModulTree_ModulTreeID] Unique  NONCLUSTERED
	(
		[ModulTreeID],
		[ModulID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XModulTree_DynaMask] FOREIGN KEY
	(
		[MaskName]
	) REFERENCES [dbo].[DynaMask] (
		[MaskName]
	),
	CONSTRAINT [FK_XModulTree_XClass] FOREIGN KEY
	(
		[ClassName]
	) REFERENCES [dbo].[XClass] (
		[ClassName]
	) ON UPDATE CASCADE ,
	CONSTRAINT [FK_XModulTree_XIcon] FOREIGN KEY
	(
		[XIconID]
	) REFERENCES [dbo].[XIcon] (
		[XIconID]
	) ON UPDATE CASCADE ,
	CONSTRAINT [FK_XModulTree_XModulTree] FOREIGN KEY
	(
		[ModulTreeID_Parent],
		[ModulID]
	) REFERENCES [dbo].[XModulTree] (
		[ModulTreeID],
		[ModulID]
	)
) ON [PRIMARY]
GO
 CREATE  Unique  Clustered  INDEX [IX_XModulTree] ON [dbo].[XModulTree]([ModulID], [ModulTreeID_Parent], [SortKey]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XModulTree Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XModulTree', N'column', N'ModulTreeID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XModulTree_XModulTree) => XModulTree.ModulTreeID', N'user', N'dbo', N'table', N'XModulTree', N'column', N'ModulTreeID_Parent'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XModulTree_XModulTree) => XModulTree.ModulID', N'user', N'dbo', N'table', N'XModulTree', N'column', N'ModulID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XModulTree_XIcon) => XIcon.XIconID', N'user', N'dbo', N'table', N'XModulTree', N'column', N'XIconID'
GO

GO

GO

GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XModulTree_XClass) => XClass.ClassName', N'user', N'dbo', N'table', N'XModulTree', N'column', N'ClassName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XModulTree_DynaMask) => DynaMask.MaskName', N'user', N'dbo', N'table', N'XModulTree', N'column', N'MaskName'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
