CREATE TABLE [dbo].[KaJobtimal](
	[KaJobtimalID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[ZuweiserID] [int] NULL,
	[AnmeldungCode] [int] NULL,
	[DocumentID_Faehigkeitsprofil] [int] NULL,
	[DocumentID_Rahmenvertrag] [int] NULL,
	[SozialhilfebezugAb] [datetime] NULL,
	[KaSozialhilfebezugCode] [int] NULL,
	[DocumentID_Schlussbericht] [int] NULL,
	[AbschlussDatum] [datetime] NULL,
    [AustrittgrundCode] [int] NULL, 
	[DossierRetourAnSDGrundCode] [int] NULL,
	[Bemerkungen] [varchar](1000) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaJobtimalTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaJobtimal] PRIMARY KEY CLUSTERED 
(
	[KaJobtimalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaJobtimal_FaLeistungID] ON [dbo].[KaJobtimal] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaJobtimal Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'KaJobtimalID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaJobtimal_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaInstitutionKontakt wenn es positiv ist und auf XUser wenn es negativ ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'ZuweiserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaVermittlungBiBIPSiAnmeldung"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'AnmeldungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Fähigkeitsprofil' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'DocumentID_Faehigkeitsprofil'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Rahmenvertrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'DocumentID_Rahmenvertrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Sozialhilfebezug ab' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'SozialhilfebezugAb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaSozialhilfebezug"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'KaSozialhilfebezugCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Schlussbericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'DocumentID_Schlussbericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlussdatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'AbschlussDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaVermittlungDossierRetourAnSDGrund"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'DossierRetourAnSDGrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaJobtimal', @level2type=N'COLUMN',@level2name=N'KaJobtimalTS'
GO

ALTER TABLE [dbo].[KaJobtimal]  WITH CHECK ADD  CONSTRAINT [FK_KaJobtimal_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaJobtimal] CHECK CONSTRAINT [FK_KaJobtimal_FaLeistung]
GO

ALTER TABLE [dbo].[KaJobtimal] ADD  CONSTRAINT [DF_KaJobtimal_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaJobtimal] ADD  CONSTRAINT [DF_KaJobtimal_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaJobtimal] ADD  CONSTRAINT [DF_KaJobtimal_Modified]  DEFAULT (getdate()) FOR [Modified]
GO