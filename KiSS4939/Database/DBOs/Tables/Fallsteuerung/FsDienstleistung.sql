CREATE TABLE [dbo].[FsDienstleistung](
	[FsDienstleistungID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[StandardAufwand] [money] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FsDienstleistungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FsDienstleistung] PRIMARY KEY CLUSTERED 
(
	[FsDienstleistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'FsDienstleistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Bezeichnung der Dienstleistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standardaufwand in Stunden pro Monat und Dienstleistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'StandardAufwand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung', @level2type=N'COLUMN',@level2name=N'FsDienstleistungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die optionalen Dienstleistungen für die Zuweisung zu den Dienstleistungspaketen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallsteuerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung'
GO

ALTER TABLE [dbo].[FsDienstleistung] ADD  CONSTRAINT [DF_FsDienstleistung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FsDienstleistung] ADD  CONSTRAINT [DF_FsDienstleistung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO