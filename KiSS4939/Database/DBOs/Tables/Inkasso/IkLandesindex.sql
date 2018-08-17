CREATE TABLE [dbo].[IkLandesindex](
	[IkLandesindexID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkLandesindexTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkLandesindex] PRIMARY KEY CLUSTERED 
(
	[IkLandesindexID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2],
 CONSTRAINT [UK_IkLandesindex_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'IkLandesindexID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung des Indexes (z.B.: BFS2010)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'COLUMN',@level2name=N'IkLandesindexTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Inkasso-Landesindex mit Indexbezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Inkasso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Name des Landesindexes muss eindeutig sein.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindex', @level2type=N'CONSTRAINT',@level2name=N'UK_IkLandesindex_Name'
GO

ALTER TABLE [dbo].[IkLandesindex] ADD  CONSTRAINT [DF_IkLandesindex_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkLandesindex] ADD  CONSTRAINT [DF_IkLandesindex_Modified]  DEFAULT (getdate()) FOR [Modified]
GO