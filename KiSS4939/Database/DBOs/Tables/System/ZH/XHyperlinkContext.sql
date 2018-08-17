CREATE TABLE [dbo].[XHyperlinkContext](
	[XHyperlinkContextID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL,
	[System] [bit] NOT NULL CONSTRAINT [DF_XHyperlinkContext_System]  DEFAULT ((0)),
	[XHyperlinkContextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XHyperlinkContext] PRIMARY KEY CLUSTERED 
(
	[XHyperlinkContextID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON