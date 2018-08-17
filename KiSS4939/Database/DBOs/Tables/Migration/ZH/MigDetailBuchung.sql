CREATE TABLE [dbo].[MigDetailBuchung](
	[MigDetailBuchungID] [int] IDENTITY(1,1) NOT NULL,
	[Laufnummer] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[FallProleist] [int] NULL,
	[PersonProleist] [int] NULL,
	[PNID] [int] NULL,
	[NummernKreisRef] [varchar](2) NULL,
	[BelegNummerRef] [int] NULL,
	[NummernKreis] [varchar](2) NULL,
	[BelegNummer] [int] NULL,
	[PositionsNummer] [int] NULL,
	[BelegPos] [int] NULL,
	[BuchungsStatusCode] [int] NULL,
	[BuchungsStatusText] [varchar](50) NULL,
	[KopfEinzelBuchung] [int] NULL,
	[SollKontoNr] [varchar](7) NULL,
	[HabenKontoNr] [varchar](7) NULL,
	[LeistungsArtNrProLeist] [int] NULL,
	[LeistungsArtCode] [int] NULL,
	[LeistungsArtText] [varchar](255) NULL,
	[Betrag] [money] NULL,
	[Kennzeichen] [varchar](2) NULL,
	[IRPBuchungsVorgang] [int] NULL,
	[BuchungsText] [varchar](35) NULL,
	[BuchungsSchluessel] [varchar](2) NULL,
	[JournalKennzeichen] [varchar](2) NULL,
	[Mitarbeiter] [int] NULL,
	[BuchungsDatum] [datetime] NULL,
	[ErfassungsDatum] [datetime] NULL,
	[FaelligkeitsDatum] [datetime] NULL,
	[VerwendungVon] [datetime] NULL,
	[VerwendungBis] [datetime] NULL,
	[KostenStelle] [varchar](10) NULL,
	[DEBKREPrefix] [numeric](2, 0) NULL,
	[DEBKREID] [numeric](6, 0) NULL,
	[DEBKREName] [nvarchar](70) NULL,
	[DEBKREZusatzzeile] [nvarchar](50) NULL,
	[DEBKREVorname] [nvarchar](30) NULL,
	[Fehlerhaft] [int] NULL,
	[Herkunft] [varchar](10) NULL,
	[Leistung] [int] NULL,
	[Person] [int] NULL,
	[KissLeistungsart] [varchar](10) NULL,
	[BetragAbsolut] [money] NULL,
	[Zinsperiode] [int] NULL,
 CONSTRAINT [PK_MigDetailBuchung] PRIMARY KEY CLUSTERED 
(
	[MigDetailBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
) ON [ARCHIV]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [ix_BaPersonID]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [ix_BaPersonID] ON [dbo].[MigDetailBuchung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [ix_FaLeistungID]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [ix_FaLeistungID] ON [dbo].[MigDetailBuchung] 
(
	[FaLeistungID] ASC
)
INCLUDE ( [VerwendungVon],
[VerwendungBis],
[Betrag],
[BuchungsStatusCode],
[KissLeistungsart],
[LeistungsArtNrProLeist],
[BaPersonID],
[NummernKreis],
[BelegNummer],
[FallProleist],
[PersonProleist],
[BelegPos],
[LeistungsArtText],
[BuchungsText],
[BuchungsDatum],
[ErfassungsDatum],
[FaelligkeitsDatum],
[DEBKREName],
[DEBKREVorname]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [IX_MigDetailBuchung_BelegNummer]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [IX_MigDetailBuchung_BelegNummer] ON [dbo].[MigDetailBuchung] 
(
	[BelegNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [IX_MigDetailBuchung_BetragAbsolut]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [IX_MigDetailBuchung_BetragAbsolut] ON [dbo].[MigDetailBuchung] 
(
	[BetragAbsolut] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [IX_MigDetailBuchung_Nummernkreis]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [IX_MigDetailBuchung_Nummernkreis] ON [dbo].[MigDetailBuchung] 
(
	[NummernKreis] ASC,
	[BelegNummer] ASC
)
INCLUDE ( [BaPersonID],
[KissLeistungsart]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [IX_MigDetailBuchung_VerwendungsPeriodeBis]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [IX_MigDetailBuchung_VerwendungsPeriodeBis] ON [dbo].[MigDetailBuchung] 
(
	[VerwendungBis] ASC
)
INCLUDE ( [MigDetailBuchungID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [IX_MigDetailBuchung_VerwendungsPeriodeVon]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [IX_MigDetailBuchung_VerwendungsPeriodeVon] ON [dbo].[MigDetailBuchung] 
(
	[VerwendungVon] ASC
)
INCLUDE ( [MigDetailBuchungID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO

/****** Object:  Index [ix_Person]    Script Date: 11/23/2011 16:13:56 ******/
CREATE NONCLUSTERED INDEX [ix_Person] ON [dbo].[MigDetailBuchung] 
(
	[Person] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [ARCHIV]
GO
ALTER TABLE [dbo].[MigDetailBuchung]  WITH CHECK ADD  CONSTRAINT [FK_MigDetailBuchung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[MigDetailBuchung] CHECK CONSTRAINT [FK_MigDetailBuchung_BaPerson]
GO
ALTER TABLE [dbo].[MigDetailBuchung]  WITH CHECK ADD  CONSTRAINT [FK_MigDetailBuchung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[MigDetailBuchung] CHECK CONSTRAINT [FK_MigDetailBuchung_FaLeistung]