CREATE TABLE [dbo].[KesAuftrag](
	[KesAuftragID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[IsKS] [bit] NOT NULL,
	[DatumAuftrag] [datetime] NULL,
	[DocumentID_Auftrag] [int] NULL,
	[UserID] [int] NULL,
	[DatumFrist] [datetime] NULL,
	[KesGefaehrdungsmeldungDurchCode] [int] NULL,
	[KesAuftragDurchCode] [int] NULL,
	[KesAuftragAbklaerungsartCode] [int] NULL,
	[Anlass] [varchar](max) NULL,
	[Auftrag] [varchar](max) NULL,
	[AbschlussDatum] [datetime] NULL,
	[KesAuftragAbschlussgrundCode] [int] NULL,
	[DocumentID_BeschlussRueckmeldung] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesAuftragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesAuftrag] PRIMARY KEY CLUSTERED 
(
	[KesAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesAuftrag_FaLeistungID] ON [dbo].[KesAuftrag] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesAuftrag_UserID] ON [dbo].[KesAuftrag] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KES-Aufträge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesAuftrag_FaLeistung) => FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kindesschutz oder Erwachsenenschutz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'IsKS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Auftrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'DatumAuftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument des Auftrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_Auftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SAR, Fremdschlüssel (FK_KesAuftrag_XUser) => UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fristdatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'DatumFrist'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gefährdungsmelder aus LOV KesGefaehrdungsmeldungDurchES oder KesGefaehrdungsmeldungDurchKS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesGefaehrdungsmeldungDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AuftragDurchCode aus LOV KesAuftragDurch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesAuftragDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AuftragAbklärungsartCode aus LOV KesAuftragAbklaerungsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesAuftragAbklaerungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anlass dieses Auftrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Anlass'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auftragsbeschreibung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Auftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlussdatum des Auftrags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'AbschlussDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AuftragsabschlussGrund aus LOV KesAuftragAbschlussgrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesAuftragAbschlussgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument der Beschlussrückmeldung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_BeschlussRueckmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag', @level2type=N'COLUMN',@level2name=N'KesAuftragTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Thomas Abegglen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet Aufträge für Kindes- und Erwachsenenschutzleistungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesAuftrag'
GO

ALTER TABLE [dbo].[KesAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_KesAuftrag_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KesAuftrag] CHECK CONSTRAINT [FK_KesAuftrag_FaLeistung]
GO

ALTER TABLE [dbo].[KesAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_KesAuftrag_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesAuftrag] CHECK CONSTRAINT [FK_KesAuftrag_XUser]
GO

ALTER TABLE [dbo].[KesAuftrag] ADD  CONSTRAINT [DF_KesAuftrag_IsKS]  DEFAULT ((0)) FOR [IsKS]
GO

ALTER TABLE [dbo].[KesAuftrag] ADD  CONSTRAINT [DF_KesAuftrag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesAuftrag] ADD  CONSTRAINT [DF_KesAuftrag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

