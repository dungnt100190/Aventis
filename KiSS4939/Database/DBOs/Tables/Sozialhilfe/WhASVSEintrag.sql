CREATE TABLE [dbo].[WhASVSEintrag](
	[WhASVSEintragID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[ASVSEintragStatusCode] [int] NOT NULL,
	[Bemerkung] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [varchar](50) NOT NULL,
	[WhASVSEintragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhASVSEintrag] PRIMARY KEY CLUSTERED 
(
	[WhASVSEintragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhASVSEintrag_BaPersonID]    Script Date: 12/10/2012 08:46:12 ******/
CREATE NONCLUSTERED INDEX [IX_WhASVSEintrag_BaPersonID] ON [dbo].[WhASVSEintrag] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhASVSEintrag_FaLeistungID]    Script Date: 12/10/2012 08:46:12 ******/
CREATE NONCLUSTERED INDEX [IX_WhASVSEintrag_FaLeistungID] ON [dbo].[WhASVSEintrag] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Primary Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'WhASVSEintragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die ASVS-Einträge werden pro Person und Leistung erzeugt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die ASVS-Einträge werden pro Person und Leistung erzeugt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ASVS-Anmelde-Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ASVS-Abmelde-Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Zustand des Eintrages (neu erstellt, zu exportieren, ...; siehe entsprechenden LOV-Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'ASVSEintragStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung zum ASVS Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Ersteller des Eintrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt als der Eintrag erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der letzte Benutzer, welcher den Datensatz verändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Zeitpunkt der letzten Änderung am Datensatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für den Datensatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag', @level2type=N'COLUMN',@level2name=N'WhASVSEintragTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Speichert die ASVS Anmelde- und Abmelde-Daten pro Klient und Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhASVSEintrag'
GO

ALTER TABLE [dbo].[WhASVSEintrag]  WITH CHECK ADD  CONSTRAINT [FK_WhASVSEintrag_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WhASVSEintrag] CHECK CONSTRAINT [FK_WhASVSEintrag_BaPerson]
GO

ALTER TABLE [dbo].[WhASVSEintrag]  WITH CHECK ADD  CONSTRAINT [FK_WhASVSEintrag_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[WhASVSEintrag] CHECK CONSTRAINT [FK_WhASVSEintrag_FaLeistung]
GO

ALTER TABLE [dbo].[WhASVSEintrag] ADD  CONSTRAINT [DF_WhASVSEintrag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WhASVSEintrag] ADD  CONSTRAINT [DF_WhASVSEintrag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO



