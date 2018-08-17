CREATE TABLE [dbo].[XModulTree_20081009](
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
	[sqlInsertTreeItem] [varchar](2000) NULL,
	[Active] [bit] NOT NULL,
	[XModulTreeTS] [timestamp] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON