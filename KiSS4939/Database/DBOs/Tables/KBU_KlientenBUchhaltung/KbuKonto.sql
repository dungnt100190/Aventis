CREATE TABLE [dbo].[KbuKonto](
	[KbuKontoID] [int] IDENTITY(1,1) NOT NULL,
	[KbuKontoGruppeID] [int] NULL,
	[KontoNr] [varchar](10) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ExterneKontoNr] [varchar](50) NULL,
	[ExternerName] [varchar](100) NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[GruppePosition] [int] NULL,
	[Quoting] [bit] NOT NULL,
	[WshSplittingartCode] [int] NULL,
	[KbuKontoklasseCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuKontoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuKonto] PRIMARY KEY CLUSTERED 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbuKonto_KbuKontoGruppeID] ON [dbo].[KbuKonto] 
(
	[KbuKontoGruppeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Konto-Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'KbuKontoGruppeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die KontoNr des Kontos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'KontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Bezeichnung des Kontos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die KontoNr des Kontos in einem externen Buchungssystem.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'ExterneKontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Bezeichnung des Kontos in einem externen Buchungssystem.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'ExternerName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung des Kontos, Beginn der Gültigkeit dieses Kontos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung des Kontos, Ende der Gültigkeit dieses Kontos.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position des Kontos innerhalb einer Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'GruppePosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert, ob dieser Aufwand auf alle Personen einer Unterstützungseinheit aufgeteilt werden muss.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Quoting'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Splittingart des Kontos (Aufteilund des Betrags innerhalb der Verwendungsperiode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'WshSplittingartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Klasse des Kontos (Aufwand, Ertrag, Aktiven, Passiven...).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'KbuKontoklasseCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'COLUMN',@level2name=N'KbuKontoTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für Konten in der Klientenbuchhaltung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'KBU,WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto'
GO

ALTER TABLE [dbo].[KbuKonto]  WITH CHECK ADD  CONSTRAINT [FK_KbuKonto_KbuKontoGruppe] FOREIGN KEY([KbuKontoGruppeID])
REFERENCES [dbo].[KbuKontoGruppe] ([KbuKontoGruppeID])
GO

ALTER TABLE [dbo].[KbuKonto] CHECK CONSTRAINT [FK_KbuKonto_KbuKontoGruppe]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Konto-Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'CONSTRAINT',@level2name=N'FK_KbuKonto_KbuKontoGruppe'
GO

ALTER TABLE [dbo].[KbuKonto]  WITH CHECK ADD  CONSTRAINT [CK_KbuKonto_Datum] CHECK  (([DatumVon]<=[DatumBis]))
GO

ALTER TABLE [dbo].[KbuKonto] CHECK CONSTRAINT [CK_KbuKonto_Datum]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Überprüfung des Datumbereichs auf Gültigkeit und Überschneidungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKonto', @level2type=N'CONSTRAINT',@level2name=N'CK_KbuKonto_Datum'
GO

ALTER TABLE [dbo].[KbuKonto] ADD  CONSTRAINT [DF_KbuKonto_Quoting]  DEFAULT ((0)) FOR [Quoting]
GO

ALTER TABLE [dbo].[KbuKonto] ADD  CONSTRAINT [DF_KbuKonto_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuKonto] ADD  CONSTRAINT [DF_KbuKonto_Modified]  DEFAULT (getdate()) FOR [Modified]
GO