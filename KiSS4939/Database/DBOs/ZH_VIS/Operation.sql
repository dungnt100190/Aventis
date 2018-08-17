CREATE TABLE [kiss].[Operation](
	[MandateReportInfoId] [uniqueidentifier] NOT NULL,
	[VbDecision] [datetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [kiss].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_MandateReportInfo] FOREIGN KEY([MandateReportInfoId])
REFERENCES [kiss].[MandateReportInfo] ([Id])
GO

ALTER TABLE [kiss].[Operation] CHECK CONSTRAINT [FK_Operation_MandateReportInfo]
GO


