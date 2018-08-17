CREATE TABLE [dbo].[KbuBelegPosition](
	[KbuBelegPositionID] [int] IDENTITY(1,1) NOT NULL,
	[KbuBelegID] [int] NOT NULL,
	[KbuKontoID] [int] NOT NULL,
	[WshPositionID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[BaPersonID] [int] NULL,
	[PositionImBeleg] [int] NOT NULL,
	[KbuBelegPositionID_Umbuchung] [int] NULL,
	[SollHaben] [varchar](1) NOT NULL,
	[Kostenstelle] [varchar](20) NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[KbuSplittingartCode] [int] NULL,
	[Text] [varchar](200) NOT NULL,
	[BetragBrutto] [money] NOT NULL,
	[BetragNetto] [money] NOT NULL,
	[Weiterverrechenbar] [bit] NOT NULL,
	[Quoting] [bit] NOT NULL,
	[KbuStornoCode] [int] NULL,
	[HauptPosition] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuBelegPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuBelegPosition] PRIMARY KEY CLUSTERED 
(
	[KbuBelegPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbuBelegPosition_BaPersonID]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_BaPersonID] ON [dbo].[KbuBelegPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_FaLeistungID]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_FaLeistungID] ON [dbo].[KbuBelegPosition] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_KbuBelegID]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_KbuBelegID] ON [dbo].[KbuBelegPosition] 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_KbuBelegPositionID_Umbuchung]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_KbuBelegPositionID_Umbuchung] ON [dbo].[KbuBelegPosition] 
(
	[KbuBelegPositionID_Umbuchung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_KbuKontoID]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_KbuKontoID] ON [dbo].[KbuBelegPosition] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_WshPositionID]    Script Date: 06/20/2011 09:13:10 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_WshPositionID] ON [dbo].[KbuBelegPosition] 
(
	[WshPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegPosition_KbuBelegID_PositionImBeleg]    Script Date: 06/27/2011 01:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegPosition_KbuBelegID_PositionImBeleg] ON [dbo].[KbuBelegPosition] 
(
	[KbuBelegID] ASC,
	[PositionImBeleg] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuBelegPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu KbuBeleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu KbuKonto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu WshPosition, zu welcher die Belegposition gehört' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'WshPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu BaPerson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu Umbuchungen in KbuBelegPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuBelegPositionID_Umbuchung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position im Beleg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'PositionImBeleg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SollHaben der Belegposition (S=SOLL, H=HABEN)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'SollHaben'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenstelle der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Kostenstelle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verwendungsperiode VON der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'VerwPeriodeVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verwendungsperiode BIS der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'VerwPeriodeBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Splittungsart der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuSplittingartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstext der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BetragBrutto der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'BetragBrutto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag Netto der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'BetragNetto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt ab, ob die Position weiterverrechenbar ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Weiterverrechenbar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt ab, ob die Position gequotet ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Quoting'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stornocode der Belegposition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuStornoCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pro Beleg hat es eine Hauptposition. Der Gesamtbetrag wird in der Hauptposition abgelegt, so dass die Summe der Positionen 0 ergibt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'HauptPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition', @level2type=N'COLUMN',@level2name=N'KbuBelegPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Rolf Hesterberg' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Positionen zu KBU Buchungstabelle (früher KbBuchungKostenart)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Klientenbuchhaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegPosition'
GO

ALTER TABLE [dbo].[KbuBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KbuBelegPosition] CHECK CONSTRAINT [FK_KbuBelegPosition_BaPerson]
GO

ALTER TABLE [dbo].[KbuBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegPosition_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KbuBelegPosition] CHECK CONSTRAINT [FK_KbuBelegPosition_FaLeistung]
GO

ALTER TABLE [dbo].[KbuBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegPosition_KbuBeleg] FOREIGN KEY([KbuBelegID])
REFERENCES [dbo].[KbuBeleg] ([KbuBelegID])
GO

ALTER TABLE [dbo].[KbuBelegPosition] CHECK CONSTRAINT [FK_KbuBelegPosition_KbuBeleg]
GO

ALTER TABLE [dbo].[KbuBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegPosition_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[KbuBelegPosition] CHECK CONSTRAINT [FK_KbuBelegPosition_KbuKonto]
GO

ALTER TABLE [dbo].[KbuBelegPosition]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegPosition_WshPosition] FOREIGN KEY([WshPositionID])
REFERENCES [dbo].[WshPosition] ([WshPositionID])
GO

ALTER TABLE [dbo].[KbuBelegPosition] CHECK CONSTRAINT [FK_KbuBelegPosition_WshPosition]
GO

ALTER TABLE [dbo].[KbuBelegPosition] ADD  CONSTRAINT [DF_KbuBelegPosition_Weiterverrechenbar]  DEFAULT ((0)) FOR [Weiterverrechenbar]
GO

ALTER TABLE [dbo].[KbuBelegPosition] ADD  CONSTRAINT [DF_KbuBelegPosition_Quoting]  DEFAULT ((0)) FOR [Quoting]
GO

ALTER TABLE [dbo].[KbuBelegPosition] ADD  CONSTRAINT [DF_KbuBelegPosition_HauptPosition]  DEFAULT ((0)) FOR [HauptPosition]
GO

ALTER TABLE [dbo].[KbuBelegPosition] ADD  CONSTRAINT [DF_KbuBelegPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuBelegPosition] ADD  CONSTRAINT [DF_KbuBelegPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
