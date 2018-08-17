CREATE TABLE [dbo].[KaIntegBildung](
	[KaIntegBildungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[KaKurserfassungID] [int] NULL,
	[Eintritt] [datetime] NULL,
	[Austritt] [datetime] NULL,
	[AbschlussCode] [int] NULL,
	[AbschlussDokID] [int] NULL,
	[RueckmeldungDokID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[KursbestFlag] [bit] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaProgrammCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaIntegBildungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaIntegBildung] PRIMARY KEY CLUSTERED 
(
	[KaIntegBildungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaIntegBildung_BaPersonID]    Script Date: 10/27/2011 11:13:46 ******/
CREATE NONCLUSTERED INDEX [IX_KaIntegBildung_BaPersonID] ON [dbo].[KaIntegBildung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_KaIntegBildung_FaLeistungID]    Script Date: 10/27/2011 11:13:46 ******/
CREATE NONCLUSTERED INDEX [IX_KaIntegBildung_FaLeistungID] ON [dbo].[KaIntegBildung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_KaIntegBildung_KaKurserfassungID]    Script Date: 10/27/2011 11:13:46 ******/
CREATE NONCLUSTERED INDEX [IX_KaIntegBildung_KaKurserfassungID] ON [dbo].[KaIntegBildung] 
(
	[KaKurserfassungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaIntegBildung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'KaIntegBildungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaIntegBildung_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaIntegBildung_KaKurserfassung) => KaKurserfassung.KaKurserfassungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'KaKurserfassungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaIntegBildung', @level2type=N'COLUMN',@level2name=N'KaIntegBildungTS'
GO

ALTER TABLE [dbo].[KaIntegBildung]  WITH CHECK ADD  CONSTRAINT [FK_KaIntegBildung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KaIntegBildung] CHECK CONSTRAINT [FK_KaIntegBildung_BaPerson]
GO

ALTER TABLE [dbo].[KaIntegBildung]  WITH CHECK ADD  CONSTRAINT [FK_KaIntegBildung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaIntegBildung] CHECK CONSTRAINT [FK_KaIntegBildung_FaLeistung]
GO

ALTER TABLE [dbo].[KaIntegBildung]  WITH NOCHECK ADD  CONSTRAINT [FK_KaIntegBildung_KaKurserfassung] FOREIGN KEY([KaKurserfassungID])
REFERENCES [dbo].[KaKurserfassung] ([KaKurserfassungID])
GO

ALTER TABLE [dbo].[KaIntegBildung] CHECK CONSTRAINT [FK_KaIntegBildung_KaKurserfassung]
GO

ALTER TABLE [dbo].[KaIntegBildung] ADD  CONSTRAINT [DF_KaIntegBildung_KursbestFlag]  DEFAULT ((0)) FOR [KursbestFlag]
GO

ALTER TABLE [dbo].[KaIntegBildung] ADD  CONSTRAINT [DF_KaIntegBildung_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaIntegBildung] ADD  CONSTRAINT [DF_KaIntegBildung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaIntegBildung] ADD  CONSTRAINT [DF_KaIntegBildung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
