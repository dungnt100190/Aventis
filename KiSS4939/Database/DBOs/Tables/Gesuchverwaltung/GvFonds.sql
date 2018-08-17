CREATE TABLE [dbo].[GvFonds](
	[GvFondsID] [int] IDENTITY(1,1) NOT NULL,
	[KbZahlungskontoID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[NameKurz] [varchar](200) NOT NULL,
	[NameLang] [varchar](500) NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[BemerkungTID] [int] NULL,
	[GvFondsTypCode] [int] NOT NULL,
  [IstCH] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvFondsTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvFonds] PRIMARY KEY CLUSTERED 
(
	[GvFondsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_GvFonds_KbZahlungskontoID] ON [dbo].[GvFonds]
(
	[KbZahlungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fonds DatumVon' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fonds DatumBis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvFonds Records (nach Primärschlüssel-Standards' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'GvFondsID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kurze Version der Bezeichnung des Fonds. Wird typischerweise in Controls verwendet zur Auswahl eines Fonds.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'NameKurz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vollständige Bezeichnung des Fonds. Wird typischerweise in Reports verwendet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'NameLang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hinweis zur Verwendung des Fonds.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID für die Übersetzung des Felds Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'BemerkungTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvFondsTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'GvFondsTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ist schweizerische oder kantonalische Fonds' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'IstCH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds', @level2type=N'COLUMN',@level2name=N'GvFondsTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu den Fonds in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds'
GO

ALTER TABLE [dbo].[GvFonds]  WITH CHECK ADD  CONSTRAINT [FK_GvFonds_KbZahlungskonto] FOREIGN KEY([KbZahlungskontoID])
REFERENCES [dbo].[KbZahlungskonto] ([KbZahlungskontoID])
GO

ALTER TABLE [dbo].[GvFonds] CHECK CONSTRAINT [FK_GvFonds_KbZahlungskonto]
GO

ALTER TABLE [dbo].[GvFonds] ADD  CONSTRAINT [DF_GvFonds_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvFonds] ADD  CONSTRAINT [DF_GvFonds_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[GvFonds] ADD  CONSTRAINT [DF_GvFonds_IstCH]  DEFAULT ((0)) FOR [IstCH]
GO