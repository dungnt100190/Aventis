CREATE TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket](
	[FsDienstleistung_FsDienstleistungspaketID] [int] IDENTITY(1,1) NOT NULL,
	[FsDienstleistungID] [int] NOT NULL,
	[FsDienstleistungspaketID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FsDienstleistung_FsDienstleistungspaketTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FsDienstleistung_FsDienstleistungspaket] PRIMARY KEY CLUSTERED 
(
	[FsDienstleistung_FsDienstleistungspaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungID_FsDienstleistungspaketID] UNIQUE NONCLUSTERED 
(
	[FsDienstleistungID] ASC,
	[FsDienstleistungspaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungID] ON [dbo].[FsDienstleistung_FsDienstleistungspaket] 
(
	[FsDienstleistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaketID] ON [dbo].[FsDienstleistung_FsDienstleistungspaket] 
(
	[FsDienstleistungspaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistung_FsDienstleistungspaketID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FsDienstleistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FsDienstleistungspaket' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistungspaketID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'COLUMN',@level2name=N'FsDienstleistung_FsDienstleistungspaketTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle für Zuweisung von Dienstleistungen zu Dienstleistungspaketen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallsteuerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket'
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket]  WITH CHECK ADD  CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung] FOREIGN KEY([FsDienstleistungID])
REFERENCES [dbo].[FsDienstleistung] ([FsDienstleistungID])
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] CHECK CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Dienstleistungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'CONSTRAINT',@level2name=N'FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistung'
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket]  WITH CHECK ADD  CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket] FOREIGN KEY([FsDienstleistungspaketID])
REFERENCES [dbo].[FsDienstleistungspaket] ([FsDienstleistungspaketID])
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] CHECK CONSTRAINT [FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Dienstleistungspakete' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsDienstleistung_FsDienstleistungspaket', @level2type=N'CONSTRAINT',@level2name=N'FK_FsDienstleistung_FsDienstleistungspaket_FsDienstleistungspaket'
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] ADD  CONSTRAINT [DF_FsDienstleistung_FsDienstleistungspaket_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FsDienstleistung_FsDienstleistungspaket] ADD  CONSTRAINT [DF_FsDienstleistung_FsDienstleistungspaket_Modified]  DEFAULT (getdate()) FOR [Modified]
GO