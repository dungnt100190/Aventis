CREATE TABLE [dbo].[KaExterneBildung](
	[KaExterneBildungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[Kurstyp] [int] NULL,
	[Bezeichnung] [varchar](200) NULL,
	[Kursort] [varchar](200) NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[AnzahlKurstage] [int] NULL,
	[Kursbestaetigung] [bit] NOT NULL,
	[AnteilKA] [money] NULL,
	[AnteilDritte] [money] NULL,
	[KaProgrammCode] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaExterneBildungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaExterneBildung] PRIMARY KEY CLUSTERED 
(
	[KaExterneBildungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaExterneBildung_BaPersonID]    Script Date: 10/27/2011 13:52:15 ******/
CREATE NONCLUSTERED INDEX [IX_KaExterneBildung_BaPersonID] ON [dbo].[KaExterneBildung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_KaExterneBildung_FaLeistungID]    Script Date: 10/27/2011 13:52:15 ******/
CREATE NONCLUSTERED INDEX [IX_KaExterneBildung_FaLeistungID] ON [dbo].[KaExterneBildung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaExterneBildung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'KaExterneBildungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaExterneBildung_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'COLUMN',@level2name=N'KaExterneBildungTS'
GO

ALTER TABLE [dbo].[KaExterneBildung]  WITH CHECK ADD  CONSTRAINT [FK_KaExterneBildung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KaExterneBildung] CHECK CONSTRAINT [FK_KaExterneBildung_BaPerson]
GO

ALTER TABLE [dbo].[KaExterneBildung]  WITH CHECK ADD  CONSTRAINT [FK_KaExterneBildung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaExterneBildung] CHECK CONSTRAINT [FK_KaExterneBildung_FaLeistung]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaExterneBildung', @level2type=N'CONSTRAINT',@level2name=N'FK_KaExterneBildung_FaLeistung'
GO

ALTER TABLE [dbo].[KaExterneBildung] ADD  CONSTRAINT [DF_KaExterneBildung_Kursbestaetigung]  DEFAULT ((0)) FOR [Kursbestaetigung]
GO

ALTER TABLE [dbo].[KaExterneBildung] ADD  CONSTRAINT [DF_KaExterneBildung_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaExterneBildung] ADD  CONSTRAINT [DF_KaExterneBildung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaExterneBildung] ADD  CONSTRAINT [DF_KaExterneBildung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
