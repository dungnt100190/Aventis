CREATE TABLE [dbo].[XTable] (
	[TableName] [varchar] (255) NOT NULL ,
	[Alias] [char] (3) NULL ,
	[System] [bit] NOT NULL CONSTRAINT [DF_XTable_System] DEFAULT ((0)),
	[ModulID] [int] NULL ,
	[DataWareHouse] [bit] NOT NULL CONSTRAINT [DF_XTable_DataWareHouse] DEFAULT ((0)),
	[Comment] [varchar] (2000) NULL ,
	[XTableTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XTable] PRIMARY KEY  Clustered
	(
		[TableName]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XTable_XModul] FOREIGN KEY
	(
		[ModulID]
	) REFERENCES [dbo].[XModul] (
		[ModulID]
	) ON UPDATE CASCADE
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XTable Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XTable', N'column', N'TableName'
GO

GO

GO

GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XTable_XModul) => XModul.ModulID', N'user', N'dbo', N'table', N'XTable', N'column', N'ModulID'
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
