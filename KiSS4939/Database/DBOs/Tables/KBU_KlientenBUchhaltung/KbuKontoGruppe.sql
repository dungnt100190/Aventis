/****** Object:  Table [dbo].[KbuKontoGruppe]    Script Date: 04/11/2011 15:38:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KbuKontoGruppe](
	[KbuKontoGruppeID] [int] IDENTITY(1,1) NOT NULL,
	[KbuKontoGruppeID_Parent] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[GruppePosition] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuKontoGruppeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuKontoGruppe] PRIMARY KEY CLUSTERED 
(
	[KbuKontoGruppeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KbuKontoGruppe_KbuKontoGruppeID_Parent] ON [dbo].[KbuKontoGruppe] 
(
	[KbuKontoGruppeID_Parent] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'KbuKontoGruppeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur übergeordneten Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'KbuKontoGruppeID_Parent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung der Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung der Konto-Gruppe, Beginn der Gültigkeit dieser Konto-Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung der Konto-Gruppe, Ende der Gültigkeit dieser Konto-Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position der Gruppe innerhalb einer übergeordneten Gruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'GruppePosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'COLUMN',@level2name=N'KbuKontoGruppeTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle zum Gruppieren von KbuKonto Einträgen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'KBU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe'
GO

ALTER TABLE [dbo].[KbuKontoGruppe]  WITH CHECK ADD  CONSTRAINT [FK_KbuKontoGruppe_KbuKontoGruppe_Parent] FOREIGN KEY([KbuKontoGruppeID_Parent])
REFERENCES [dbo].[KbuKontoGruppe] ([KbuKontoGruppeID])
GO

ALTER TABLE [dbo].[KbuKontoGruppe] CHECK CONSTRAINT [FK_KbuKontoGruppe_KbuKontoGruppe_Parent]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf KbuKontoGruppe.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'CONSTRAINT',@level2name=N'FK_KbuKontoGruppe_KbuKontoGruppe_Parent'
GO

ALTER TABLE [dbo].[KbuKontoGruppe]  WITH CHECK ADD  CONSTRAINT [CK_KbuKontoGruppeID_Datum] CHECK  (([DatumVon]<=[DatumBis]))
GO

ALTER TABLE [dbo].[KbuKontoGruppe] CHECK CONSTRAINT [CK_KbuKontoGruppeID_Datum]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Überprüfung des Datumbereichs auf Gültigkeit und Überschneidungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuKontoGruppe', @level2type=N'CONSTRAINT',@level2name=N'CK_KbuKontoGruppeID_Datum'
GO

ALTER TABLE [dbo].[KbuKontoGruppe] ADD  CONSTRAINT [DF_KbuKontoGruppe_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuKontoGruppe] ADD  CONSTRAINT [DF_KbuKontoGruppe_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


