CREATE TABLE [dbo].[PscdSentFaLeistung_Person](
	[DBName] [varchar](50) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[SentToPscd] [datetime] NOT NULL,
	[PscdSentFaLeistung_PersonID] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO