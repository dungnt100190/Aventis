CREATE TABLE [dbo].[PscdSentFaLeistung](
	[DBName] [varchar](50) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[FaLeistungTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO