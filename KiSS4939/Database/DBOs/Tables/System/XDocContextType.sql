CREATE TABLE [dbo].[XDocContextType] (
	[DocContextTypeID] [int] IDENTITY (1, 1) NOT NULL ,
	[NameDocContextType] [varchar] (50) NOT NULL ,
	[TemplateFolder] [varchar] (255) NOT NULL ,
	[DocumentFolder] [varchar] (255) NULL ,
	[Description] [varchar] (200) NOT NULL ,
	[XDocContextTypeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XDocContextType] PRIMARY KEY  NONCLUSTERED
	(
		[DocContextTypeID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [IX_XDocContextType] Unique  Clustered
	(
		[NameDocContextType]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für XDocContextType Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XDocContextType', N'column', N'DocContextTypeID'
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
