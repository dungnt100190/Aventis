CREATE TABLE [dbo].[XQueryContext] (
	[QueryContextID] [int] IDENTITY (1, 1) NOT NULL ,
	[ParentID] [int] NULL ,
	[ParentPosition] [int] NULL ,
	[FolderName] [varchar] (100) NULL ,
	[QueryCode] [int] NOT NULL ,
	[QueryName] [varchar] (100) NULL ,
	[XQueryContextTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XQueryContext] PRIMARY KEY  Clustered
	(
		[QueryContextID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XQueryContext Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XQueryContext', N'column', N'QueryContextID'
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
