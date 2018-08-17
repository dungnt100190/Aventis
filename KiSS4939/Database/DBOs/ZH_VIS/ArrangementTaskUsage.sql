CREATE TABLE [kiss].[ArrangementTaskUsage](
	[Id] [uniqueidentifier] NOT NULL,
	[ArrangementArticleUsageId] [uniqueidentifier] NOT NULL,
	[TaskName] [varchar](255) NOT NULL,
	[DateOfOrder] [datetime] NULL,
	[DateOfRepeal] [datetime] NULL,
	[MandateId] [uniqueidentifier] NULL,
	[HU] [bit] NULL,
 CONSTRAINT [PK_ArrangementTaskUsage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[ArrangementTaskUsage]  WITH CHECK ADD  CONSTRAINT [FK_ArrangementTaskUsage_ArrangementArticleUsage] FOREIGN KEY([ArrangementArticleUsageId])
REFERENCES [kiss].[ArrangementArticleUsage] ([Id])
GO

ALTER TABLE [kiss].[ArrangementTaskUsage] CHECK CONSTRAINT [FK_ArrangementTaskUsage_ArrangementArticleUsage]
GO

ALTER TABLE [kiss].[ArrangementTaskUsage]  WITH CHECK ADD  CONSTRAINT [FK_ArrangementTaskUsage_Mandate] FOREIGN KEY([MandateId])
REFERENCES [kiss].[Mandate] ([Id])
GO

ALTER TABLE [kiss].[ArrangementTaskUsage] CHECK CONSTRAINT [FK_ArrangementTaskUsage_Mandate]
GO


