CREATE TABLE [dbo].[FaDokumentAblage](
	[FaDokumentAblageID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[FaDokumentAblageInhaltCode] [int] NULL,
	[FaThemaDokAblageCodes] [varchar](250) NULL,
	[DatumErstellung] [datetime] NULL,
	[DatumGueltigVon] [datetime] NULL,
	[DatumGueltigBis] [datetime] NULL,
	[Stichwort] [varchar](max) NULL,
	[Bemerkung] [varchar](max) NULL,
	[DocumentID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaDokumentAblageTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaDokumentAblage] PRIMARY KEY CLUSTERED 
(
	[FaDokumentAblageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaDokumentAblage_BaInstitutionID_Adressat]    Script Date: 11/07/2013 15:52:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_BaInstitutionID_Adressat] ON [dbo].[FaDokumentAblage] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumentAblage_BaPersonID_Adressat]    Script Date: 11/07/2013 15:52:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_BaPersonID_Adressat] ON [dbo].[FaDokumentAblage] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumentAblage_DocumentID]    Script Date: 11/07/2013 15:52:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_DocumentID] ON [dbo].[FaDokumentAblage] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumentAblage_FaLeistungID]    Script Date: 11/07/2013 15:52:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_FaLeistungID] ON [dbo].[FaDokumentAblage] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaDokumentAblage_UserID]    Script Date: 11/07/2013 15:52:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaDokumentAblage_UserID] ON [dbo].[FaDokumentAblage] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'FaDokumentAblageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur FaLeistung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum User. Enthält den User, welcher das Dokument erstellt hat (wird zur Zeit nicht auf der Maske angezeigt).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf BaPerson, falls im Adressat eine Person ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'BaPersonID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign Key auf BaInstitution, falls im Adressat eine Institution ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werteliste FaDokumentAblageInhalt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'FaDokumentAblageInhaltCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV FaThemaDokAblage. Thema zum Dokument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'FaThemaDokAblageCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann das Dokument erstellt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'DatumErstellung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen über das Dokument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XDocument (=> DocumentId).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage', @level2type=N'COLUMN',@level2name=N'FaDokumentAblageTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Scrum-Team 1 + 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Diese Tabelle ist für die Dokumentablage. Zur Zeit wird diese Tabelle nur von SRK verwendet. Ist sehr änhlich wie FaDokumente, hat aber doch etwas andere Attribute wie eine many to many Verbindung zu BaPerson.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Fallführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaDokumentAblage'
GO

ALTER TABLE [dbo].[FaDokumentAblage]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_BaInstitution] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[FaDokumentAblage] CHECK CONSTRAINT [FK_FaDokumentAblage_BaInstitution]
GO

ALTER TABLE [dbo].[FaDokumentAblage]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_BaPerson] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaDokumentAblage] CHECK CONSTRAINT [FK_FaDokumentAblage_BaPerson]
GO

ALTER TABLE [dbo].[FaDokumentAblage]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaDokumentAblage] CHECK CONSTRAINT [FK_FaDokumentAblage_FaLeistung]
GO

ALTER TABLE [dbo].[FaDokumentAblage]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumentAblage_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaDokumentAblage] CHECK CONSTRAINT [FK_FaDokumentAblage_XUser]
GO

ALTER TABLE [dbo].[FaDokumentAblage] ADD  CONSTRAINT [DF_FaDokumentAblage_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaDokumentAblage] ADD  CONSTRAINT [DF_FaDokumentAblage_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

