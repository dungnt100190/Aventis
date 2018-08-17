CREATE TABLE [kiss].[ArrangementArticleUsage](
	[Id] [uniqueidentifier] NOT NULL,
	[ArrangementId] [uniqueidentifier] NOT NULL,
	[ArticleName] [varchar](255) NOT NULL,
	[ArrangementCategoryName] [varchar](255) NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[DateOfRepeal] [datetime] NULL,
 CONSTRAINT [PK_ArrangementArticleUsage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[ArrangementArticleUsage]  WITH CHECK ADD  CONSTRAINT [FK_ArrangementArticleUsage_Arrangement] FOREIGN KEY([ArrangementId])
REFERENCES [kiss].[Arrangement] ([Id])
GO

ALTER TABLE [kiss].[ArrangementArticleUsage] CHECK CONSTRAINT [FK_ArrangementArticleUsage_Arrangement]
GO

