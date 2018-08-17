CREATE TABLE [dbo].[KgKonto](
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
	[SortKey] [int] NULL,
	[SaldoMT940] [money] NULL,
	[DatumSaldoAktualisierung] [datetime] NULL,
 CONSTRAINT [PK_KgKonto] PRIMARY KEY CLUSTERED 
(
	[KgKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgKonto_KgPeriode_KgKontoArtCode]    Script Date: 11/23/2011 16:01:49 ******/
CREATE NONCLUSTERED INDEX [IX_KgKonto_KgPeriode_KgKontoArtCode] ON [dbo].[KgKonto] 
(
	[KgPeriodeID] ASC,
	[KgKontoartCode] DESC
)
INCLUDE ( [KontoNr],
[KontoName]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgKonto_KgPeriodeID]    Script Date: 11/23/2011 16:01:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KgKonto_KgPeriodeID] ON [dbo].[KgKonto] 
(
	[KgPeriodeID] ASC,
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgKonto_KgPeriodeID_KontoNr]    Script Date: 11/23/2011 16:01:49 ******/
CREATE NONCLUSTERED INDEX [IX_KgKonto_KgPeriodeID_KontoNr] ON [dbo].[KgKonto] 
(
	[KgPeriodeID] ASC,
	[KontoNr] ASC
)
INCLUDE ( [KontoName],
[KgKontoklasseCode],
[Vorsaldo],
[KgKontoartCode],
[KontoGruppe],
[GruppeKontoID],
[GruppePosition],
[VorsaldoUebertrag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[KgKonto]  WITH CHECK ADD  CONSTRAINT [FK_KgKonto_KgPeriode] FOREIGN KEY([KgPeriodeID])
REFERENCES [dbo].[KgPeriode] ([KgPeriodeID])
GO
ALTER TABLE [dbo].[KgKonto] CHECK CONSTRAINT [FK_KgKonto_KgPeriode]