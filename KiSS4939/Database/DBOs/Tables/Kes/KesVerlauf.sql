CREATE TABLE [dbo].[KesVerlauf](
	[KesVerlaufID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[KesVerlaufTypCode] [int] NOT NULL,
	[UserID] [int] NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[DocumentID] [int] NULL,
	[Datum] [datetime] NULL,
	[KesKontaktartCode] [int] NULL,
	[KesDienstleistungCode] [int] NULL,
	[Stichwort] [varchar](max) NULL,
	[FaDauerCode] [int] NULL,
	[Inhalt] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesVerlaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesVerlauf] PRIMARY KEY CLUSTERED 
(
	[KesVerlaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesVerlauf_BaInstitutionID_Adressat] ON [dbo].[KesVerlauf] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesVerlauf_BaPersonID_Adressat] ON [dbo].[KesVerlauf] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesVerlauf_FaLeistungID] ON [dbo].[KesVerlauf] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesVerlauf_UserID] ON [dbo].[KesVerlauf] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'KesVerlaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FaLeistung, Fremdschlüssel (FK_KesVerlauf_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesVerlaufTyp (Maske PriMa/FaMa oder Pflegekinderaufsicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'KesVerlaufTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VerfasserIn, Fremdschlüssel (FK_KesVerlauf_XUser) => XUserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID des Adressats' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'BaPersonID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaInstitutionID des Adressats' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dazugehöriges Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Eintrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesKontaktart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'KesKontaktartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesDienstleistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'KesDienstleistungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stichwort/Titel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Stichwort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV FaDauer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'FaDauerCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Inhalt der Besprechung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Inhalt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf', @level2type=N'COLUMN',@level2name=N'KesVerlaufTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KES Verlauf (Fachstelle PriMa/FaMa - PriMa-Begleitung / Pflegekinderaufsicht - Aufsicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'KES' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesVerlauf'
GO

ALTER TABLE [dbo].[KesVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KesVerlauf_BaInstitution] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesVerlauf] CHECK CONSTRAINT [FK_KesVerlauf_BaInstitution]
GO

ALTER TABLE [dbo].[KesVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KesVerlauf_BaPerson] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KesVerlauf] CHECK CONSTRAINT [FK_KesVerlauf_BaPerson]
GO

ALTER TABLE [dbo].[KesVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KesVerlauf_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesVerlauf] CHECK CONSTRAINT [FK_KesVerlauf_FaLeistung]
GO

ALTER TABLE [dbo].[KesVerlauf]  WITH CHECK ADD  CONSTRAINT [FK_KesVerlauf_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesVerlauf] CHECK CONSTRAINT [FK_KesVerlauf_XUser]
GO

ALTER TABLE [dbo].[KesVerlauf] ADD  CONSTRAINT [DF_KesVerlauf_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesVerlauf] ADD  CONSTRAINT [DF_KesVerlauf_Modified]  DEFAULT (getdate()) FOR [Modified]
GO