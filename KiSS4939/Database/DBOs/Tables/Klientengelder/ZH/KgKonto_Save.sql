CREATE TABLE [dbo].[KgKonto_Save](
	[KgKontoID] [int] IDENTITY(1,1) NOT NULL,
	[KgPeriodeID] [int] NULL,
	[GruppeKontoID] [int] NULL,
	[GruppePosition] [int] NULL,
	[KontoGruppe] [bit] NOT NULL,
	[KgKontoklasseCode] [int] NULL,
	[KgKontoartCode] [int] NULL,
	[KontoNr] [varchar](10) NOT NULL,
	[KontoName] [varchar](100) NOT NULL,
	[Vorsaldo] [money] NOT NULL,
	[VorsaldoUebertrag] [bit] NULL,
	[KgKontoTS] [timestamp] NOT NULL,
	[SortKey] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON