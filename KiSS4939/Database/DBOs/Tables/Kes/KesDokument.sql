CREATE TABLE [dbo].[KesDokument](
	[KesDokumentID] [int] IDENTITY(1,1) NOT NULL,
	[KesAuftragID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[UserID] [int] NULL,
	[BaPersonID_Adressat] [int] NULL,
	[BaInstitutionID_Adressat] [int] NULL,
	[Stichwort] [varchar](max) NULL,
	[KesDokumentResultatCode] [int] NULL,
	[KesDokumentArtCode] [int] NULL,
	[XDocumentID_Dokument] [int] NULL,
	[XDocumentID_Versand] [int] NULL,
	[KesDokumentTypCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesDokumentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesDokument] PRIMARY KEY CLUSTERED 
(
	[KesDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_BaInstitutionID_Adressat] ON [dbo].[KesDokument] 
(
	[BaInstitutionID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_BaPersonID_Adressat] ON [dbo].[KesDokument] 
(
	[BaPersonID_Adressat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_FaLeistungID] ON [dbo].[KesDokument] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_KesAuftragID] ON [dbo].[KesDokument] 
(
	[KesAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_UserID] ON [dbo].[KesDokument] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_XDocumentID_Dokument] ON [dbo].[KesDokument] 
(
	[XDocumentID_Dokument] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesDokument_XDocumentID_Versand] ON [dbo].[KesDokument] 
(
	[XDocumentID_Versand] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KES-Auftragsdokumente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesDokumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesDokument_KesAuftrag) => KesAuftragID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesDokument_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VerfasserIn, Fremdschlüssel (FK_KesDokument_XUser) => XUserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID des Adressats' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'BaPersonID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaInstitutionID des Adressats' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stichwort' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'Stichwort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Resultat aus LOV KesDokumentResultat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesDokumentResultatCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus LOV KesDokumentart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesDokumentArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument, Fremdschlüssel (FK_KesDokument_XDocument) => XDocumentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'XDocumentID_Dokument'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Versand, Fremdschlüssel (FK_KesDokument_XDocument1) => XDocumentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'XDocumentID_Versand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesDokumentTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesDokumentTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument', @level2type=N'COLUMN',@level2name=N'KesDokumentTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet Auftragsdokumente für Kindes- und Erwachsenenschutzleistungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesDokument'
GO

ALTER TABLE [dbo].[KesDokument]  WITH CHECK ADD  CONSTRAINT [FK_KesDokument_BaInstitution_Adressat] FOREIGN KEY([BaInstitutionID_Adressat])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesDokument] CHECK CONSTRAINT [FK_KesDokument_BaInstitution_Adressat]
GO

ALTER TABLE [dbo].[KesDokument]  WITH CHECK ADD  CONSTRAINT [FK_KesDokument_BaPerson_Adressat] FOREIGN KEY([BaPersonID_Adressat])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KesDokument] CHECK CONSTRAINT [FK_KesDokument_BaPerson_Adressat]
GO

ALTER TABLE [dbo].[KesDokument]  WITH CHECK ADD  CONSTRAINT [FK_KesDokument_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesDokument] CHECK CONSTRAINT [FK_KesDokument_FaLeistung]
GO

ALTER TABLE [dbo].[KesDokument]  WITH CHECK ADD  CONSTRAINT [FK_KesDokument_KesAuftrag] FOREIGN KEY([KesAuftragID])
REFERENCES [dbo].[KesAuftrag] ([KesAuftragID])
GO

ALTER TABLE [dbo].[KesDokument] CHECK CONSTRAINT [FK_KesDokument_KesAuftrag]
GO

ALTER TABLE [dbo].[KesDokument]  WITH CHECK ADD  CONSTRAINT [FK_KesDokument_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesDokument] CHECK CONSTRAINT [FK_KesDokument_XUser]
GO

ALTER TABLE [dbo].[KesDokument] ADD  CONSTRAINT [DF_KesDokument_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesDokument] ADD  CONSTRAINT [DF_KesDokument_Modified]  DEFAULT (getdate()) FOR [Modified]
GO