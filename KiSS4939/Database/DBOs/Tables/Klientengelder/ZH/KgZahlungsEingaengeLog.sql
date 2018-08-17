CREATE TABLE [dbo].[KgZahlungsEingaengeLog](
	[KgZahlungsEingaengeLogID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](3) NULL,
	[VerbuchteEingaenge] [int] NOT NULL,
	[ErstelltDatum] [datetime] NOT NULL CONSTRAINT [DF_KgZahlungsEingaengeLog_ErstelltDatum]  DEFAULT (getdate()),
	[Fehlermeldung] [varchar](300) NULL,
 CONSTRAINT [PK_KgZahlungsEingaengeLog] PRIMARY KEY CLUSTERED 
(
	[KgZahlungsEingaengeLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON