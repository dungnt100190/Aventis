CREATE TABLE [dbo].[PscdSentBaZahlungsweg](
	[DBName] [varchar](50) NOT NULL,
	[BaZahlungswegID] [int] NOT NULL,
	[BaZahlungswegTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL,
	[SapID] [int] NULL,
	[SapIDAddress] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO
