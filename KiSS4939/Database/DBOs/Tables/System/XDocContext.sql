CREATE TABLE [dbo].[XDocContext] (
	[DocContextID] [int] IDENTITY (1, 1) NOT NULL ,
	[DocContextName] [varchar] (50) NOT NULL ,
	[Description] [varchar] (500) NULL ,
	[System] [bit] NOT NULL CONSTRAINT [DF_XDocContext_System] DEFAULT (0),
	[XDocContextTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XDocContext] PRIMARY KEY  NONCLUSTERED
	(
		[DocContextID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO
 CREATE  Unique  Clustered  INDEX [IX_XDocContext] ON [dbo].[XDocContext]([DocContextName]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XDocContext Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XDocContext', N'column', N'DocContextID'
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
