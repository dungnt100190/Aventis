CREATE TABLE [kiss].[ArrangementHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[ArrangementId] [uniqueidentifier] NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[DateOfRepeal] [datetime] NULL,
	[ArticleDescription] [varchar](100) NULL,
	[ArrangementDescription] [varchar](100) NULL,
 CONSTRAINT [PK_ArrangementHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[ArrangementHistory]  WITH CHECK ADD  CONSTRAINT [FK_ArrangementHistory_Arrangement] FOREIGN KEY([ArrangementId])
REFERENCES [kiss].[Arrangement] ([Id])
GO

ALTER TABLE [kiss].[ArrangementHistory] CHECK CONSTRAINT [FK_ArrangementHistory_Arrangement]
GO


