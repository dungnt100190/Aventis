CREATE TABLE [dbo].[WshPosition](
	[WshPositionID] [int] IDENTITY(1,1) NOT NULL,
	[WshGrundbudgetPositionID] [int] NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[KbuKontoID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[WshKategorieID] [int] NOT NULL,
	[WshSteuerungID] [int] NULL,
	[WshBewilligungStatusCode] [int] NULL,
	[WshPeriodizitaetCode] [int] NULL,
	[FaelligAm] [datetime] NULL,
	[WshSammelrechnungID] [int] NULL,
	[SammelrechnungPosition] [int] NULL,
	[KbuAuszahlungArtCode] [int] NULL,
	[VerwPeriodeVon] [datetime] NOT NULL,
	[VerwPeriodeBis] [datetime] NOT NULL,
	[MonatVon] [datetime] NOT NULL,
	[MonatBis] [datetime] NOT NULL,
	[BetragAnfrage] [money] NULL,
	[Betrag] [money] NOT NULL,
	[BetragTotal] [money] NULL,
	[EinnahmeEffektiv] [money] NULL,
	[DatumEffektiv] [datetime] NULL,
	[VerwaltungSD] [bit] NOT NULL,
	[Text] [varchar](100) NOT NULL,
	[Bemerkung] [varchar](1000) NULL,
	[DauerauftragAktiv] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshPosition] PRIMARY KEY CLUSTERED 
(
	[WshPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WshPosition_BaInstitutionID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_BaInstitutionID] ON [dbo].[WshPosition] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_BaPersonID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_BaPersonID] ON [dbo].[WshPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_FaLeistungID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_FaLeistungID] ON [dbo].[WshPosition] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_KbuKontoID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_KbuKontoID] ON [dbo].[WshPosition] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_WshGrundbudgetPositionID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_WshGrundbudgetPositionID] ON [dbo].[WshPosition] 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_WshGrundbudgetPositionID_Betrag]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_WshGrundbudgetPositionID_Betrag] ON [dbo].[WshPosition] 
(
	[WshGrundbudgetPositionID] ASC,
	[Betrag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshPosition_WshKategorieID]    Script Date: 09/14/2011 08:34:31 ******/
CREATE NONCLUSTERED INDEX [IX_WshPosition_WshKategorieID] ON [dbo].[WshPosition] 
(
	[WshKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die ursprüngliche WSH-Grundbudget-Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der WSH-FaLeistungID, zu welcher die Position gehört' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Person, welche die Einnahme/Ausgabe der Position verursacht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Konto/Kostenart, welche für die Position verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Institution, wo z.B. die Person platziert ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu WshKategorie. Formerly known as WshKategorieCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshKategorieID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf WSH-Steuerungstabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshSteuerungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewilligungsstatus, z.B. in Vorbereitung,  abgelehnt, angefragt, erteilt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshBewilligungStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlungstermin, z.B. 1x pro Monat, wöchentlich, Valuta' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshPeriodizitaetCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bei Auszahlungen nur für AuszahlTerminCode ''Valuta'': Das geplante Valutadatum. Bei Einnahmen das Fälligkeitsdatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'FaelligAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf WSH-Tabelle für Sammelrechnungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshSammelrechnungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Position (Reihenfolge) in einer WSH-Sammelrechnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'SammelrechnungPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlungsart, z.B. Elektronisch, Barauszahlung, Check, Papierverfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'KbuAuszahlungArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Verwendungsperiode der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'VerwPeriodeVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Verwendungsperiode der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'VerwPeriodeBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monat und Jahr in welchem die erste Auszahlung gemacht wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'MonatVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monat und Jahr in welchem die letzte Auszahlung gemacht wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'MonatBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der bewilligte Betrag, welcher eingenommen oder ausbezahlt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der totale Betrag einer Auszahlung über mehrere Monate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'BetragTotal'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der effektiv eingenommene/ausbezahlte Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'EinnahmeEffektiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das effektive Datum der Einnahme oder Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'DatumEffektiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert, ob die Einnahme durch den Sozialdienst verwaltet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'VerwaltungSD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text der als Buchungstext übernommen wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob für diese Position automatisch eine KbuBelegPosition angelegt werden soll.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'DauerauftragAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'COLUMN',@level2name=N'WshPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die WSH-Masterbudget-Positionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition'
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_BaInstitution]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf BaInstitution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'CONSTRAINT',@level2name=N'FK_WshPosition_BaInstitution'
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_BaPerson]
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_FaLeistung]
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_KbuKonto]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf KbuKonto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'CONSTRAINT',@level2name=N'FK_WshPosition_KbuKonto'
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_WshGrundbudgetPosition] FOREIGN KEY([WshGrundbudgetPositionID])
REFERENCES [dbo].[WshGrundbudgetPosition] ([WshGrundbudgetPositionID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_WshGrundbudgetPosition]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf WshGrundbudgetPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'CONSTRAINT',@level2name=N'FK_WshPosition_WshGrundbudgetPosition'
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [FK_WshPosition_WshKategorie] FOREIGN KEY([WshKategorieID])
REFERENCES [dbo].[WshKategorie] ([WshKategorieID])
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [FK_WshPosition_WshKategorie]
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [CK_WshPosition_Datum] CHECK  (([VerwPeriodeVon]<=[VerwPeriodeBis]))
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [CK_WshPosition_Datum]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Überprüfung des Datumbereichs auf Gültigkeit und Überschneidungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'CONSTRAINT',@level2name=N'CK_WshPosition_Datum'
GO

ALTER TABLE [dbo].[WshPosition]  WITH CHECK ADD  CONSTRAINT [CK_WshPosition_Sammelrechnung] CHECK  (([WshSammelrechnungID] IS NULL OR [SammelrechnungPosition] IS NOT NULL))
GO

ALTER TABLE [dbo].[WshPosition] CHECK CONSTRAINT [CK_WshPosition_Sammelrechnung]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wenn eine WshSammelrechnungID angegeben ist, muss auch eine SammelrechnungPosition gesetzt sein' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPosition', @level2type=N'CONSTRAINT',@level2name=N'CK_WshPosition_Sammelrechnung'
GO

ALTER TABLE [dbo].[WshPosition] ADD  CONSTRAINT [DF_WshPosition_VerwaltungSD]  DEFAULT ((0)) FOR [VerwaltungSD]
GO

ALTER TABLE [dbo].[WshPosition] ADD  CONSTRAINT [DF_WshPosition_DauerauftragAktiv]  DEFAULT ((0)) FOR [DauerauftragAktiv]
GO

ALTER TABLE [dbo].[WshPosition] ADD  CONSTRAINT [DF_WshPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshPosition] ADD  CONSTRAINT [DF_WshPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


