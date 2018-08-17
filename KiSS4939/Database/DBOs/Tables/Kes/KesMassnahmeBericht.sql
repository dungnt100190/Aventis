CREATE TABLE [dbo].[KesMassnahmeBericht](
  [KesMassnahmeBerichtID] [int] IDENTITY(1,1) NOT NULL,
  [KesMassnahmeID] [int] NOT NULL,
  [KesMassnahmeBerichtsartCode] [int] NULL,
  [DatumVon] [datetime] NULL,
  [DatumBis] [datetime] NULL,
  [Bemerkung] [varchar](max) NULL,
  [DocumentID_Bericht] [int] NULL,
  [DocumentID_Rechnung] [int] NULL,
  [DocumentID_Versand] [int] NULL,
  [DatumVersand] [datetime] NULL,
  [DatumBelegeZurueck] [datetime] NULL,
  [DocumentID_VerfuegungKESB] [int] NULL,
  [DatumVerfuegungKESB] [datetime] NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KesMassnahmeBerichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMassnahmeBericht] PRIMARY KEY CLUSTERED 
(
  [KesMassnahmeBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesMassnahmeBericht_KesMassnahmeID] ON [dbo].[KesMassnahmeBericht] 
(
  [KesMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'KesMassnahmeBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle KesMassnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'KesMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesMassnahmeBerichtsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'KesMassnahmeBerichtsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Berichtsperiode von' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Berichtsperiode bis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Bericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DocumentID_Bericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Rechnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DocumentID_Rechnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DocumentID_Versand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Versands' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumVersand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Belege zurück am' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumBelegeZurueck'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument der KES-Verfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DocumentID_VerfuegungKESB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der KES-Verfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumVerfuegungKESB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'KesMassnahmeBerichtTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle zum Tab ''Berichte'', welche der Massnahme angehängt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Kes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht'
GO

ALTER TABLE [dbo].[KesMassnahmeBericht]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeBericht_KesMassnahme] FOREIGN KEY([KesMassnahmeID])
REFERENCES [dbo].[KesMassnahme] ([KesMassnahmeID])
GO

ALTER TABLE [dbo].[KesMassnahmeBericht] CHECK CONSTRAINT [FK_KesMassnahmeBericht_KesMassnahme]
GO

ALTER TABLE [dbo].[KesMassnahmeBericht] ADD  CONSTRAINT [DF_KesMassnahmeBericht_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMassnahmeBericht] ADD  CONSTRAINT [DF_KesMassnahmeBericht_Modified]  DEFAULT (getdate()) FOR [Modified]
GO