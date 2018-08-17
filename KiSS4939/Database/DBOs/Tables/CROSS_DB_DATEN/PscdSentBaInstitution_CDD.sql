CREATE TABLE [dbo].[PscdSentBaInstitution](
	[DBName] [varchar](50) NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[BaInstitutionTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO