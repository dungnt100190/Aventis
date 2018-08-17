CREATE TABLE [dbo].[KbWVEinzelposten](
	[KbWVEinzelpostenID] [int] IDENTITY(1,1) NOT NULL,
	[StorniertKbWVEinzelpostenID] [int] NULL,
	[KbWVLaufID] [int] NOT NULL,
	[UnterstuetzungstraegerBaPersonID] [int] NOT NULL,
	[WVCode] [int] NOT NULL,
	[BEDCode] [int] NOT NULL,
	[WhWVEinheitMitgliedID] [int] NULL,
	[BeguenstigterBaPersonID] [int] NOT NULL,
	[KbBuchungBruttoPersonID] [int] NULL,
	[BgSplittingArtCode] [int] NULL,
	[Betrag] [money] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NOT NULL,
	[SplittingDurchWVLaufDatumBis] [bit] NOT NULL CONSTRAINT [DF_KbWVEinzelposten_AbgeschnittenDurchWVLauf]  DEFAULT ((0)),
	[PscdBelegNr] [bigint] NULL,
	[KbWVEinzelpostenStatusCode] [int] NOT NULL,
	[Ungueltig] [bit] NOT NULL CONSTRAINT [DF_KbWVEinzelposten_Ungueltig]  DEFAULT ((0)),
	[UnterstuetzungsanzeigeDocumentID] [int] NULL,
	[TransferDatum] [datetime] NULL,
	[Hauptvorgang] [int] NULL,
	[Teilvorgang] [int] NULL,
	[WohnHeimatKanton] [varchar](1) NULL,
	[Buchungstext] [varchar](200) NULL,
	[PscdFehlermeldung] [varchar](500) NULL,
	[SKZNummer] [varchar](50) NULL,
	[HeimatkantonNr] [varchar](50) NULL,
	[KbWVEinzelpositionTS] [timestamp] NOT NULL,
	[WVCodeVon] [datetime] NULL,
	[WVCodeBis] [datetime] NULL,
 CONSTRAINT [PK_KbWVEinzelposten] PRIMARY KEY CLUSTERED 
(
	[KbWVEinzelpostenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KbWVEinzelposten_BeguenstigterBaPersonID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_BeguenstigterBaPersonID] ON [dbo].[KbWVEinzelposten] 
(
	[BeguenstigterBaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_KbBuchungBruttoPersonID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_KbBuchungBruttoPersonID] ON [dbo].[KbWVEinzelposten] 
(
	[KbBuchungBruttoPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_KbWVLaufID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_KbWVLaufID] ON [dbo].[KbWVEinzelposten] 
(
	[KbWVLaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_StorniertKbWVEinzelpostenID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_StorniertKbWVEinzelpostenID] ON [dbo].[KbWVEinzelposten] 
(
	[StorniertKbWVEinzelpostenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_UnterstuetzungsanzeigeDocumentID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_UnterstuetzungsanzeigeDocumentID] ON [dbo].[KbWVEinzelposten] 
(
	[UnterstuetzungsanzeigeDocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_UnterstuetzungstraegerBaPersonID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_UnterstuetzungstraegerBaPersonID] ON [dbo].[KbWVEinzelposten] 
(
	[UnterstuetzungstraegerBaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KbWVEinzelposten_WhWVEinheitMitgliedID]    Script Date: 11/23/2011 15:58:16 ******/
CREATE NONCLUSTERED INDEX [IX_KbWVEinzelposten_WhWVEinheitMitgliedID] ON [dbo].[KbWVEinzelposten] 
(
	[WhWVEinheitMitgliedID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_BeguenstigterBaPersonID_BaPerson] FOREIGN KEY([BeguenstigterBaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_BeguenstigterBaPersonID_BaPerson]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_KbBuchungBruttoPerson] FOREIGN KEY([KbBuchungBruttoPersonID])
REFERENCES [dbo].[KbBuchungBruttoPerson] ([KbBuchungBruttoPersonID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_KbBuchungBruttoPerson]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_KbWVEinzelposten] FOREIGN KEY([StorniertKbWVEinzelpostenID])
REFERENCES [dbo].[KbWVEinzelposten] ([KbWVEinzelpostenID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_KbWVEinzelposten]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_KbWVLauf] FOREIGN KEY([KbWVLaufID])
REFERENCES [dbo].[KbWVLauf] ([KbWVLaufID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_KbWVLauf]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_UnterstuetzungstraegerBaPersonID_BaPerson] FOREIGN KEY([UnterstuetzungstraegerBaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_UnterstuetzungstraegerBaPersonID_BaPerson]
GO
ALTER TABLE [dbo].[KbWVEinzelposten]  WITH CHECK ADD  CONSTRAINT [FK_KbWVEinzelposten_WhWVEinheitMitglied] FOREIGN KEY([WhWVEinheitMitgliedID])
REFERENCES [dbo].[WhWVEinheitMitglied] ([WhWVEinheitMitgliedID])
GO
ALTER TABLE [dbo].[KbWVEinzelposten] CHECK CONSTRAINT [FK_KbWVEinzelposten_WhWVEinheitMitglied]