CREATE TABLE [dbo].[FsDienstleistungspaket](
	[FsDienstleistungspaketID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[MaximaleLaufzeit] [money] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FsDienstleistungspaketTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FsDienstleistungspaket] PRIMARY KEY CLUSTERED 
(
	[FsDienstleistungspaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistungspaketID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Bezeichnung des Dienstleistungspakets' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Maximale Laufzeit vom Dienstleistungspaket. Die Einheit ist Monat. Es ist die maximale Dauer einer Phase (Intake, Beratungsphase ...).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'MaximaleLaufzeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistungspaketTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Loreggia Lucas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für Dienstleistungspakete, zum optionalen Gruppieren von Dienstleistungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallsteuerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistungspaket'
GO

ALTER TABLE [dbo].[FsDienstleistungspaket] ADD  CONSTRAINT [DF_FsDienstleistungspaket_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FsDienstleistungspaket] ADD  CONSTRAINT [DF_FsDienstleistungspaket_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

