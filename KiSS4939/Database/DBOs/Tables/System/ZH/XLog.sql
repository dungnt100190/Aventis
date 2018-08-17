CREATE TABLE [dbo].[XLog](
	[XLogID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](255) NOT NULL,
	[SourceKey] [int] NULL,
	[XLogLevelCode] [int] NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Comment] [varchar](max) NULL,
	[ReferenceTable] [varchar](100) NULL,
	[ReferenceID] [int] NULL,
	[NonPurgeable] [bit] NOT NULL CONSTRAINT [DF_XLog_NonPurgeable]  DEFAULT ((0)),
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XLog_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XLog_Modified]  DEFAULT (getdate()),
	[XLogTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XLog] PRIMARY KEY CLUSTERED 
(
	[XLogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XLog Records (nach Primärschlüssel-Standards). Eindeutige ID des Log-Eintrags.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'XLogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Herkunft des Log-Eintrags: Namespace.Klassenname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher, optionaler Code innerhalb der Source. Dieser kann z.B. für Auswertungen eines bestimmten Typs aus gegebener Source verwendet werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'SourceKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log-Level (debug, info, warn, error, fatal)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'XLogLevelCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Log-Nachricht (z.B. Fehlermeldung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher Kommentar zum Log-Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der zum Logeintrag referenzierten Tabelle, welche zusammen mit ReferenceKey den betroffenen Datensatz beschreibt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'ReferenceTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutiger Schlüssel (PK) innerhalb der ReferenceTable. Diese ID ist z.B. beim Erzeugen eines neuen Logeintrags betroffen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'ReferenceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob ein Eintrag beim Säubern gelöscht werden darf (=0) oder erhalten bleiben soll (=1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'NonPurgeable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog', @level2type=N'COLUMN',@level2name=N'XLogTS'
GO
EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi (erstellt am 17.7.2009)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet alle Log-Einträge aus KiSS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLog'