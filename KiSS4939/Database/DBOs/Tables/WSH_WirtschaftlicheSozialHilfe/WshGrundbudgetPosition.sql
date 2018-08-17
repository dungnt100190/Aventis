CREATE TABLE [dbo].[WshGrundbudgetPosition](
	[WshGrundbudgetPositionID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[KbuKontoID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[WshKategorieID] [int] NOT NULL,
	[WshBewilligungStatusCode] [int] NULL,
	[WshPeriodizitaetCode] [int] NULL,
	[KbuAuszahlungArtCode] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[DatumEntscheid] [datetime] NULL,
	[BetragMonatlich] [money] NOT NULL,
	[BetragTotal] [money] NULL,
	[FaelligAm] [datetime] NULL,
	[VerwaltungSD] [bit] NOT NULL,
	[Text] [varchar](100) NOT NULL,
	[Bemerkung] [varchar](1000) NULL,
	[Planwert] [bit] NOT NULL,
	[Berechnet] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshGrundbudgetPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshGrundbudgetPosition] PRIMARY KEY CLUSTERED 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WshGrundbudgetPosition_BaInstitutionID]    Script Date: 08/29/2011 17:20:41 ******/
CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPosition_BaInstitutionID] ON [dbo].[WshGrundbudgetPosition] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshGrundbudgetPosition_BaPersonID]    Script Date: 08/29/2011 17:20:41 ******/
CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPosition_BaPersonID] ON [dbo].[WshGrundbudgetPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshGrundbudgetPosition_FaLeistungID]    Script Date: 08/29/2011 17:20:41 ******/
CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPosition_FaLeistungID] ON [dbo].[WshGrundbudgetPosition] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshGrundbudgetPosition_KbuKontoID]    Script Date: 08/29/2011 17:20:41 ******/
CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPosition_KbuKontoID] ON [dbo].[WshGrundbudgetPosition] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshGrundbudgetPosition_WshKategorieID]    Script Date: 08/29/2011 17:20:41 ******/
CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPosition_WshKategorieID] ON [dbo].[WshGrundbudgetPosition] 
(
	[WshKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der WSH-FaLeistungID, zu welcher die Position gehört' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Person, welche die Einnahme/Ausgabe der Position verursacht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Konto/Kostenart, welche für die Position verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Institution, wo z.B. die Person platziert ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu WshKategorie. Formerly known as WshKategorieCode.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'WshKategorieID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewilligungsstatus, z.B. in Vorbereitung,  abgelehnt, angefragt, erteilt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'WshBewilligungStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlungstermin, z.B. 1x pro Monat, wöchentlich, Valuta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'WshPeriodizitaetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlungsart, z.B. Elektronisch, Barauszahlung, Check, Papierverfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'KbuAuszahlungArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Startdatum, ab wann die Einnahme/Ausgabe gültig ist und für die Generierung der Monatsbuget-Positionen verwendet werden darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enddatum, bis wann die Einnahme/Ausgabe gültig ist und für die Generierung der Monatsbuget-Positionen verwendet werden darf. Wenn leer, dann gilt die Verwendung bis zum Abschluss der WSH-Leistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum für die Auszahlung bei Splittingart Entscheid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'DatumEntscheid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der monatliche Betrag, welcher eingenommen oder ausbezahlt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'BetragMonatlich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der totale Betrag einer Auszahlung über mehrere Monate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'BetragTotal'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fälligkeitsdatum für die Einnahme/Ausgabe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'FaelligAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wenn die Einnahme durch den Sozialdienst verwaltet werden soll, muss es mit 1 gesetzt werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'VerwaltungSD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text der als Buchungstext übernommen wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen der Grundbudget-Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert ob die Position bloss als Planwert erfasst wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Planwert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert ob die Position automatisch berechnet oder manuell eingetragen wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Berechnet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die WSH-Masterbudget-Positionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition'
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPosition_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [FK_WshGrundbudgetPosition_BaInstitution]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [FK_WshGrundbudgetPosition_BaPerson]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPosition_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [FK_WshGrundbudgetPosition_FaLeistung]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPosition_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [FK_WshGrundbudgetPosition_KbuKonto]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPosition_WshKategorie] FOREIGN KEY([WshKategorieID])
REFERENCES [dbo].[WshKategorie] ([WshKategorieID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [FK_WshGrundbudgetPosition_WshKategorie]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition]  WITH CHECK ADD  CONSTRAINT [CK_WshGrundbudgetPosition_Datum] CHECK  (([DatumVon]<=[DatumBis]))
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] CHECK CONSTRAINT [CK_WshGrundbudgetPosition_Datum]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Überprüfung des Datumbereichs auf Gültigkeit und Überschneidungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPosition', @level2type=N'CONSTRAINT',@level2name=N'CK_WshGrundbudgetPosition_Datum'
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] ADD  CONSTRAINT [DF_WshGrundbudgetPosition_VerwaltungSD]  DEFAULT ((0)) FOR [VerwaltungSD]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] ADD  CONSTRAINT [DF_WshGrundbudgetPosition_Planwert]  DEFAULT ((0)) FOR [Planwert]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] ADD  CONSTRAINT [DF_WshGrundbudgetPosition_Berechnet]  DEFAULT ((0)) FOR [Berechnet]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] ADD  CONSTRAINT [DF_WshGrundbudgetPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshGrundbudgetPosition] ADD  CONSTRAINT [DF_WshGrundbudgetPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


