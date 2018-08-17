CREATE TABLE [kiss].[MandateReportInfo](
	[Id] [uniqueidentifier] NOT NULL,
	[MandateId] [uniqueidentifier] NOT NULL,
	[Number] [int] NOT NULL,
	[ReportStart] [datetime] NULL,
	[ReportEnd] [datetime] NULL,
	[ReportDate] [datetime] NULL,
	[Dunning1] [datetime] NULL,
	[Dunning2] [datetime] NULL,
	[Dunning3] [datetime] NULL,
	[TimelimitExtension] [datetime] NULL,
	[ClearingOfficeEntry] [datetime] NULL,
	[ClearingOfficeExit] [datetime] NULL,
	[Demandnote] [datetime] NULL,
	[Receipt] [datetime] NULL,
	[MandateReportCategory] [varchar](255) NOT NULL,
 CONSTRAINT [PK_MandateReportInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [kiss].[MandateReportInfo]  WITH CHECK ADD  CONSTRAINT [FK_MandateReportInfo_Mandate] FOREIGN KEY([MandateId])
REFERENCES [kiss].[Mandate] ([Id])
GO

ALTER TABLE [kiss].[MandateReportInfo] CHECK CONSTRAINT [FK_MandateReportInfo_Mandate]
GO


