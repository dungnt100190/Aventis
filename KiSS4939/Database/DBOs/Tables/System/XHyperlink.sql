CREATE TABLE [dbo].[XHyperlink] (
	[XHyperlinkID] [int] IDENTITY (1, 1) NOT NULL ,
	[Hyperlink] [varchar] (8000) NOT NULL ,
	[Name] [varchar] (100) NOT NULL ,
	[XHyperlinkTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XHyperlink] PRIMARY KEY  Clustered
	(
		[XHyperlinkID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XHyperlink Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XHyperlink', N'column', N'XHyperlinkID'
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
