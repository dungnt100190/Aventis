CREATE TABLE [dbo].[XHyperlinkContext] (
	[XHyperlinkContextID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[Description] [varchar] (500) NULL ,
	[System] [bit] NOT NULL CONSTRAINT [DF_XHyperlinkContext_System] DEFAULT (0),
	[XHyperlinkContextTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XHyperlinkContext] PRIMARY KEY  Clustered
	(
		[XHyperlinkContextID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XHyperlinkContext Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XHyperlinkContext', N'column', N'XHyperlinkContextID'
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
