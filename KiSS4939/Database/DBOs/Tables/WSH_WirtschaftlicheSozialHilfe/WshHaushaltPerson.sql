CREATE TABLE [dbo].[WshHaushaltPerson](
	[WshHaushaltPersonID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Unterstuetzt] [bit] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshHaushaltPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshHaushaltPerson] PRIMARY KEY CLUSTERED 
(
	[WshHaushaltPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_WshHaushaltPerson_BaPersonID] ON [dbo].[WshHaushaltPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshHaushaltPerson_FaLeistungID] ON [dbo].[WshHaushaltPerson] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'WshHaushaltPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der WSH-Leistung, zu welcher die Haushalt-Person gehört' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Person, welche im Haushalt enthalten ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Person unterstützt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'Unterstuetzt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung der Haushalt-Person, Beginn des Aufenthaltes der Person im Haushalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fachliche Historisierung der Haushalt-Person, optionales Ende des Aufenthaltes der Person im Haushalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'COLUMN',@level2name=N'WshHaushaltPersonTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zuweisungstabelle für Personen in einem Haushalt. Der Datumsbereich gibt an, von wann bis wann eine Person einer bestimmten Leistung zugeteilt ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson'
GO

ALTER TABLE [dbo].[WshHaushaltPerson]  WITH CHECK ADD  CONSTRAINT [FK_WshHaushaltPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshHaushaltPerson] CHECK CONSTRAINT [FK_WshHaushaltPerson_BaPerson]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf BaPerson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'CONSTRAINT',@level2name=N'FK_WshHaushaltPerson_BaPerson'
GO

ALTER TABLE [dbo].[WshHaushaltPerson]  WITH CHECK ADD  CONSTRAINT [FK_WshHaushaltPerson_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[WshHaushaltPerson] CHECK CONSTRAINT [FK_WshHaushaltPerson_FaLeistung]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'CONSTRAINT',@level2name=N'FK_WshHaushaltPerson_FaLeistung'
GO

ALTER TABLE [dbo].[WshHaushaltPerson]  WITH CHECK ADD  CONSTRAINT [CK_WshHaushaltPerson_Integrity] CHECK  (([dbo].[fnCKWshHaushaltPersonIntegrity]([WshHaushaltPersonID],[FaLeistungID],[BaPersonID],[Unterstuetzt],[DatumVon],[DatumBis])=(0)))
GO

ALTER TABLE [dbo].[WshHaushaltPerson] CHECK CONSTRAINT [CK_WshHaushaltPerson_Integrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Integritätsprüfung für Daten (z.B. Datumsüberschneidungen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshHaushaltPerson', @level2type=N'CONSTRAINT',@level2name=N'CK_WshHaushaltPerson_Integrity'
GO

ALTER TABLE [dbo].[WshHaushaltPerson] ADD  CONSTRAINT [DF_WshHaushaltPerson_Unterstuetzt]  DEFAULT ((0)) FOR [Unterstuetzt]
GO

ALTER TABLE [dbo].[WshHaushaltPerson] ADD  CONSTRAINT [DF_WshHaushaltPerson_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshHaushaltPerson] ADD  CONSTRAINT [DF_WshHaushaltPerson_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

