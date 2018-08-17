CREATE TABLE [dbo].[KbuBelegKreis](
	[KbuBelegKreisID] [int] IDENTITY(1,1) NOT NULL,
	[KbuBelegKreisCode] [int] NOT NULL,
	[NaechsteBelegNr] [int] NULL,
	[BelegNrVon] [int] NULL,
	[BelegNrBis] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuBelegKreisTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuBelegKreis] PRIMARY KEY CLUSTERED 
(
	[KbuBelegKreisID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KbuBelegKreis Records (nach Primärschlüssel-Standards)', 
                                @level0type=N'SCHEMA', @level0name=N'dbo', 
								@level1type=N'TABLE', @level1name=N'KbuBelegKreis', 
								@level2type=N'COLUMN', @level2name=N'KbuBelegKreisID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art des Belegkreises (nach LOV KbuBelegKreis)', 
                                @level0type=N'SCHEMA', @level0name=N'dbo', 
								@level1type=N'TABLE', @level1name=N'KbuBelegKreis', 
								@level2type=N'COLUMN', @level2name=N'KbuBelegKreisCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nächste freie Belegnummer', 
                                @level0type=N'SCHEMA', @level0name=N'dbo', 
								@level1type=N'TABLE', @level1name=N'KbuBelegKreis', 
								@level2type=N'COLUMN', @level2name=N'NaechsteBelegNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erste Belegnummer des Belegkreises', 
                                @level0type=N'SCHEMA', @level0name=N'dbo', 
								@level1type=N'TABLE', @level1name=N'KbuBelegKreis', 
								@level2type=N'COLUMN', @level2name=N'BelegNrVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Letzte Belegnummer des Belegkreises', 
                                @level0type=N'SCHEMA', @level0name=N'dbo', 
								@level1type=N'TABLE', @level1name=N'KbuBelegKreis', 
								@level2type=N'COLUMN', @level2name=N'BelegNrBis'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuBelegKreis', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuBelegKreis', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuBelegKreis', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuBelegKreis', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KbuBelegKreis', 
                                @level2type = N'COLUMN', @level2name = N'KbuBelegKreisTS';
