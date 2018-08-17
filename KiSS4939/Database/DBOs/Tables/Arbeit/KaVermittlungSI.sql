CREATE TABLE [dbo].[KaVermittlungSI](
	[KaVermittlungSIID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[ZuweiserID] [int] NULL,
	[AnmeldungCode] [int] NULL,
	[Vermittelt] [bit] NOT NULL,
	[KaSiKategorieCode] [int] NULL,
	[DocumentID_Schlussbericht] [int] NULL,
	[AbschlussDatum] [datetime] NULL,
	[WechselKAIntern] [bit] NOT NULL,
	[WechselKAInternGrundCode] [int] NULL,
	[DossierRetourAnSD] [bit] NOT NULL,
	[DossierRetourAnSDGrundCode] [int] NULL,
	[Bemerkungen] [varchar](1000) NULL,
	[MigrationKA] [bit] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaVermittlungSITS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaVermittlungSI] PRIMARY KEY CLUSTERED 
(
	[KaVermittlungSIID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaVermittlungSI_FaLeistungID] ON [dbo].[KaVermittlungSI] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaVermittlungSI Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'KaVermittlungSIID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungSI_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaInstitutionKontakt wenn es positiv ist und auf XUser wenn es negativ ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'ZuweiserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaVermittlungBiBIPSiAnmeldung"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'AnmeldungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, sagt aus, ob STES vermittelt werden konnte.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'Vermittelt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibt die Art der Vermittlung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'KaSiKategorieCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Schlussbericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'DocumentID_Schlussbericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaVermittlungGrundWechselKaIntern"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'WechselKAInternGrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code der LOV "KaVermittlungDossierRetourAnSDGrund"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'DossierRetourAnSDGrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungSI', @level2type=N'COLUMN',@level2name=N'KaVermittlungSITS'
GO

ALTER TABLE [dbo].[KaVermittlungSI]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungSI_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaVermittlungSI] CHECK CONSTRAINT [FK_KaVermittlungSI_FaLeistung]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_Vermittelt]  DEFAULT ((0)) FOR [Vermittelt]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_WechselKAIntern]  DEFAULT ((0)) FOR [WechselKAIntern]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_DossierRetourAnSD]  DEFAULT ((0)) FOR [DossierRetourAnSD]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaVermittlungSI] ADD  CONSTRAINT [DF_KaVermittlungSI_Modified]  DEFAULT (getdate()) FOR [Modified]
GO