CREATE TABLE [dbo].[PscdSentBaAdresse](
	[DBName] [varchar](50) NOT NULL,
	[BaAdresseID] [int] NOT NULL,
	[BaAdresseTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO