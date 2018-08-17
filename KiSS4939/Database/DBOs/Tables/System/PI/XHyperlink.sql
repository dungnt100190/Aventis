CREATE TABLE [dbo].[XHyperlink](
	[XHyperlinkID] [int] IDENTITY(1,1) NOT NULL,
	[Hyperlink] [varchar](8000) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[XHyperlinkTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XHyperlink] PRIMARY KEY CLUSTERED 
(
	[XHyperlinkID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO