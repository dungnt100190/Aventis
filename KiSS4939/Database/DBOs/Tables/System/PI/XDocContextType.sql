CREATE TABLE [dbo].[XDocContextType](
	[DocContextTypeID] [int] IDENTITY(1,1) NOT NULL,
	[NameDocContextType] [varchar](50) NOT NULL,
	[TemplateFolder] [varchar](255) NOT NULL,
	[DocumentFolder] [varchar](255) NULL,
	[Description] [varchar](200) NOT NULL,
	[XDocContextTypeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDocContextType] PRIMARY KEY CLUSTERED 
(
	[DocContextTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO