CREATE TABLE [dbo].[BFSLOVCode] (
	[LOVName] [varchar] (100) NOT NULL ,
	[Code] [int] NOT NULL ,
	[Text] [varchar] (200) NOT NULL ,
	[TextTID] [int] NULL ,
	[KurzText] [varchar] (20) NULL ,
	[KurzTextTID] [int] NULL ,
	[Filter] [varchar] (50) NULL ,
	[SortKey] [int] NULL ,
	[BFSLOVCodeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BFSLOVCode] PRIMARY KEY  Clustered
	(
		[LOVName],
		[Code]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_BFSLOVCode_BFSLOV] FOREIGN KEY
	(
		[LOVName]
	) REFERENCES [dbo].[BFSLOV] (
		[LOVName]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BFSLOVCode Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BFSLOVCode', N'column', N'LOVName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BFSLOVCode Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BFSLOVCode', N'column', N'Code'
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

GO

GO

GO

GO

GO

GO
