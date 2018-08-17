CREATE TABLE [dbo].[KbKonto](
	[KbKontoID] [int] IDENTITY(1,1) NOT NULL,
	[KbPeriodeID] [int] NULL,
	[GruppeKontoID] [int] NULL,
	[GruppePosition] [int] NULL,
	[KontoGruppe] [bit] NOT NULL,
	[KbKontoklasseCode] [int] NULL,
	[KbKontoartCodes] [varchar](20) NULL,
	[KontoNr] [varchar](10) NOT NULL,
	[KontoName] [varchar](100) NOT NULL,
	[BankKontoNummer] [varchar](20) NULL,
	[Vorsaldo] [money] NOT NULL CONSTRAINT [DF_KbKonto_EroeffnungsSaldo]  DEFAULT ((0)),
	[KbKontoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbKonto] PRIMARY KEY CLUSTERED 
(
	[KbKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbKonto_KbPeriodeID]    Script Date: 11/23/2011 15:56:14 ******/
CREATE NONCLUSTERED INDEX [IX_KbKonto_KbPeriodeID] ON [dbo].[KbKonto] 
(
	[KbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbKonto_Sicherung]    Script Date: 11/23/2011 15:56:14 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KbKonto_Sicherung] ON [dbo].[KbKonto] 
(
	[KbPeriodeID] ASC,
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KbKonto]  WITH CHECK ADD  CONSTRAINT [FK_KbKonto_KbPeriode] FOREIGN KEY([KbPeriodeID])
REFERENCES [dbo].[KbPeriode] ([KbPeriodeID])
GO
ALTER TABLE [dbo].[KbKonto] CHECK CONSTRAINT [FK_KbKonto_KbPeriode]