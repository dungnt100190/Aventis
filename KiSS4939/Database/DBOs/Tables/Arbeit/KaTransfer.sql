CREATE TABLE [dbo].[KaTransfer](
	[KaTransferID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[TelErstkontaktDat] [datetime] NULL,
	[RueckmeldungRAVDokID] [int] NULL,
	[DatumVG] [datetime] NULL,
	[SituationserfassungVGDokID] [int] NULL,
	[EntwicklungsverlaufDokID] [int] NULL,
	[PersonalblattDokID] [int] NULL,
	[FaehigkeitsprofilDokID] [int] NULL,
	[ArbeitsprobenDokID] [int] NULL,
	[SchlussberichtDokID] [int] NULL,
	[TeilnahmebestaetigungDokID] [int] NULL,
	[AllgZiele] [varchar](max) NULL,
	[AllgZieleDokID] [int] NULL,
	[Bewerbungsstrategie] [varchar](max) NULL,
	[MuendAufforderungDat1] [datetime] NULL,
	[MuendAufforderungDat2] [datetime] NULL,
	[MuendAufforderungBem1] [varchar](max) NULL,
	[MuendAufforderungBem2] [varchar](max) NULL,
	[Aufforderung1DokID] [int] NULL,
	[Aufforderung2DokID] [int] NULL,
	[Aufforderung3DokID] [int] NULL,
	[Vereinbarung1DokID] [int] NULL,
	[Vereinbarung2DokID] [int] NULL,
	[RegelverstossDokID] [int] NULL,
	[NichterscheinenDokID] [int] NULL,
	[ProgrammabbruchDokID] [int] NULL,
	[AustrittDat] [datetime] NULL,
	[AustrittGrund] [int] NULL,
	[AustrittCode] [int] NULL,
	[AustrittBem] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaTransferTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaTransfer] PRIMARY KEY CLUSTERED 
(
	[KaTransferID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaTransfer_FaLeistungID] ON [dbo].[KaTransfer] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaTransfer Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'KaTransferID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQEEPQ_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag für die Sichtbarkeit für SD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'SichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Telefons des Erstkontakts (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'TelErstkontaktDat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für die Rückmeldung RAV (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'RueckmeldungRAVDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum VG (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'DatumVG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für die Situationserfassung VG (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'SituationserfassungVGDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für den Entwicklungsverlauf (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'EntwicklungsverlaufDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für das Personalblatt (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'PersonalblattDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für das Faehigkeitsprofil (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'FaehigkeitsprofilDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des ersten Dokuments für die Arbeitsproben (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'ArbeitsprobenDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des zweiten Dokuments für den Schlussbericht (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'SchlussberichtDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für die Teilnahmebestätigung (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'TeilnahmebestaetigungDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text für allgemeine Zielsetzungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AllgZiele'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument-ID für die allgemeine Zielsetzungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AllgZieleDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text für die Bewerbungsstrategie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Bewerbungsstrategie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erstes Datum für die mündliche Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'MuendAufforderungDat1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zweites Datum für die mündliche Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'MuendAufforderungDat2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erste Bemerkung für das Feld der mündlichen Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'MuendAufforderungBem1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zweite Bemerkung für das Feld der mündlichen Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'MuendAufforderungBem2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des ersten Dokuments für die Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Aufforderung1DokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des zweiten Dokuments für die Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Aufforderung2DokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des dritten Dokuments für die Aufforderung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Aufforderung3DokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des ersten Dokuments für die Vereinbarung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Vereinbarung1DokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des zweiten Dokuments für die Vereinbarung (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Vereinbarung2DokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des  Dokuments für den Regelverstoss (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'RegelverstossDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des  Dokuments fürs Nichterscheinen (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'NichterscheinenDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des  Dokuments für den Programmabbruch (Interventionen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'ProgrammabbruchDokID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austrittsdatum (Austritt)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AustrittDat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austrittsgrund (Austritt)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AustrittGrund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austrittscode (Austritt)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AustrittCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung für den Austritt (Austritt)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'AustrittBem'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer', @level2type=N'COLUMN',@level2name=N'KaTransferTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enthält die Daten für KA - Transfer - Prozess' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaTransfer'
GO

ALTER TABLE [dbo].[KaTransfer]  WITH CHECK ADD  CONSTRAINT [FK_KaTransfer_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaTransfer] CHECK CONSTRAINT [FK_KaTransfer_FaLeistung]
GO

ALTER TABLE [dbo].[KaTransfer] ADD  CONSTRAINT [DF_KaTransfer_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaTransfer] ADD  CONSTRAINT [DF_KaTransfer_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaTransfer] ADD  CONSTRAINT [DF_KaTransfer_Modified]  DEFAULT (getdate()) FOR [Modified]
GO