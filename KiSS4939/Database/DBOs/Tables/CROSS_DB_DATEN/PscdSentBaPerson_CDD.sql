CREATE TABLE [dbo].[PscdSentBaPerson](
	[DBName] [varchar](50) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaPersonTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO