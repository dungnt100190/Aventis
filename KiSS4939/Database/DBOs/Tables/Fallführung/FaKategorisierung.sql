CREATE TABLE [dbo].[FaKategorisierung](
	[FaKategorisierungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[FaKategorisierungEksProduktID] [int] NULL,
	[UserID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[FaKategorisierungEksOptionCode] [int] NULL,
	[FaKategorisierungKiStatusCode] [int] NULL,
	[FaKategorisierungIntakeCode] [int] NULL,
	[FaKategorisierungKooperationCode] [int] NULL,
	[FaKategorisierungRessourcenCode] [int] NULL,
	[FaKategorisierungAbschlussgrundCode] [int] NULL,
	[FaKategorieCode]  AS ([dbo].[fnFaGetKategorie]([FaKategorisierungEksProduktID],[FaKategorisierungEksOptionCode],[FaKategorisierungKiStatusCode],[FaKategorisierungIntakeCode],[FaKategorisierungKooperationCode],[FaKategorisierungRessourcenCode],[FaKategorisierungAbschlussgrundCode])),
	[Abschlussdatum] [datetime] NULL,
	[Begruendung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaKategorisierungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaKategorisierung] PRIMARY KEY CLUSTERED 
(
	[FaKategorisierungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaKategorisierung_BaPersonID]    Script Date: 10/17/2012 16:33:28 ******/
CREATE NONCLUSTERED INDEX [IX_FaKategorisierung_BaPersonID] ON [dbo].[FaKategorisierung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_FaKategorisierung_FaKategorisierungEksProduktID]    Script Date: 10/17/2012 16:33:28 ******/
CREATE NONCLUSTERED INDEX [IX_FaKategorisierung_FaKategorisierungEksProduktID] ON [dbo].[FaKategorisierung] 
(
	[FaKategorisierungEksProduktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_FaKategorisierung_UserID]    Script Date: 10/17/2012 16:33:28 ******/
CREATE NONCLUSTERED INDEX [IX_FaKategorisierung_UserID] ON [dbo].[FaKategorisierung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK auf BaPerson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK auf FaKategorisierungEksProdukt (Wertelistenersatztabelle)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungEksProduktID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK auf XUser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Datum der Kategorisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungEksOption' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungEksOptionCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungKiStatus (N, F)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungKiStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungIntake (A,B,C)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungIntakeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungKooperation (1,2,...,9,10)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungKooperationCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungRessourcen (1,2,...,9,10)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungRessourcenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaKategorisierungAbschlussgrund (ähnlich Abschlussgrund Intake-Phase)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungAbschlussgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dynamisch berechnete Spalte. Enthält die aus den Kategorisierungs-Kriterien resultierende Kategorie.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorieCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Kategorisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Abschlussdatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung der Kategorisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Begruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung', @level2type=N'COLUMN',@level2name=N'FaKategorisierungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für die Maske Fa - Kategorisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaKategorisierung'
GO

ALTER TABLE [dbo].[FaKategorisierung]  WITH CHECK ADD  CONSTRAINT [FK_FaKategorisierung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaKategorisierung] CHECK CONSTRAINT [FK_FaKategorisierung_BaPerson]
GO

ALTER TABLE [dbo].[FaKategorisierung]  WITH CHECK ADD  CONSTRAINT [FK_FaKategorisierung_FaKategorisierungEksProdukt] FOREIGN KEY([FaKategorisierungEksProduktID])
REFERENCES [dbo].[FaKategorisierungEksProdukt] ([FaKategorisierungEksProduktID])
GO

ALTER TABLE [dbo].[FaKategorisierung] CHECK CONSTRAINT [FK_FaKategorisierung_FaKategorisierungEksProdukt]
GO

ALTER TABLE [dbo].[FaKategorisierung]  WITH CHECK ADD  CONSTRAINT [FK_FaKategorisierung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaKategorisierung] CHECK CONSTRAINT [FK_FaKategorisierung_XUser]
GO

ALTER TABLE [dbo].[FaKategorisierung] ADD  CONSTRAINT [DF_FaKategorisierung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaKategorisierung] ADD  CONSTRAINT [DF_FaKategorisierung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
