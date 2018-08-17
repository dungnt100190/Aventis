CREATE TABLE [dbo].[XHyperlinkContext](
	[XHyperlinkContextID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XHyperlinkContext_System]  DEFAULT (0),
	[XHyperlinkContextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XHyperlinkContext] PRIMARY KEY CLUSTERED 
(
	[XHyperlinkContextID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO