CREATE TABLE [dbo].[FsReduktion](
	[FsReduktionID] [int] IDENTITY(1,1) NOT NULL,
	[BDELeistungsartID] [int] NULL,
	[Name] [varchar](255) NOT NULL,
	[StandardAufwand] [money] NOT NULL,
	[AbhaengigVonBG] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FsReduktionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FsReduktion] PRIMARY KEY CLUSTERED 
(
	[FsReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FsReduktion_BDELeistungsartID]    Script Date: 04/07/2011 08:38:22 ******/
CREATE NONCLUSTERED INDEX [IX_FsReduktion_BDELeistungsartID] ON [dbo].[FsReduktion] 
(
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'FsReduktionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Tabelle BDELeistungsart. Ist im Idealfall eine 1 zu 1 Beziehung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'BDELeistungsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Bezeichnung des Reduktion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Standardaufwand welcher dieser Reduktion für die MA generiert. Einheit: Stunden pro Monat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'StandardAufwand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob der Reduktion (konkret der StandardAuwand) in Abhängigkeit des Beschäftigungsgrades des MA berechnet werden muss oder konstant für alle MA gleich ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'AbhaengigVonBG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion', @level2type=N'COLUMN',@level2name=N'FsReduktionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für die Fallarbeitszeit-Reduktionen. Diese werden benötigt, um von der verfügbaren Zeit eines MA statische oder berechnete Stunden pro Monat abzuziehen und anschliessend als Rest die Fallarbezeitszeit auszugeben.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallsteuerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktion'
GO

ALTER TABLE [dbo].[FsReduktion]  WITH CHECK ADD  CONSTRAINT [FK_FsReduktion_BDELeistungsart] FOREIGN KEY([BDELeistungsartID])
REFERENCES [dbo].[BDELeistungsart] ([BDELeistungsartID])
GO

ALTER TABLE [dbo].[FsReduktion] CHECK CONSTRAINT [FK_FsReduktion_BDELeistungsart]
GO

ALTER TABLE [dbo].[FsReduktion] ADD  CONSTRAINT [DF_FsReduktion_AbhaengigVonBG]  DEFAULT ((0)) FOR [AbhaengigVonBG]
GO

ALTER TABLE [dbo].[FsReduktion] ADD  CONSTRAINT [DF_FsReduktion_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FsReduktion] ADD  CONSTRAINT [DF_FsReduktion_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
