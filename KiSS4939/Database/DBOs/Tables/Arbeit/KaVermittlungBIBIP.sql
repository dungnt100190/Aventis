CREATE TABLE [dbo].[KaVermittlungBIBIP](
	[KaVermittlungBIBIPID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[AnmeldungCode] [int] NULL,
	[Priorisiert] [bit] NOT NULL,
	[ZuweiserID] [int] NULL,
	[DossierAnCoach] [datetime] NULL,
	[DossierInaktiv] [bit] NOT NULL,
	[DocumentID_Schlussbericht] [int] NULL,
	[AbschlussDatum] [datetime] NULL,
	[WechselKAIntern] [bit] NOT NULL,
	[WechselKAInternGrundCode] [int] NULL,
	[DossierRetourAnSD] [bit] NOT NULL,
	[DossierRetourAnSDGrundCode] [int] NULL,
	[Bemerkungen] [varchar](1000) NULL,
	[MigrationKA] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaVermittlungBIBIPTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaVermittlungBIBIP] PRIMARY KEY CLUSTERED 
(
	[KaVermittlungBIBIPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaVermittlungBIBIP_FaLeistungID]    Script Date: 10/02/2013 10:31:24 ******/
CREATE NONCLUSTERED INDEX [IX_KaVermittlungBIBIP_FaLeistungID] ON [dbo].[KaVermittlungBIBIP] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaVermittlungBIBIP Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungBIBIP', @level2type=N'COLUMN',@level2name=N'KaVermittlungBIBIPID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungBIBIP_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungBIBIP', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaVermittlungBiBIPSiAnmeldung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungBIBIP', @level2type=N'COLUMN',@level2name=N'AnmeldungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaVermittlungGrundWechselKaIntern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungBIBIP', @level2type=N'COLUMN',@level2name=N'WechselKAInternGrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaVermittlungDossierRetourAnSDGrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungBIBIP', @level2type=N'COLUMN',@level2name=N'DossierRetourAnSDGrundCode'
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungBIBIP_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] CHECK CONSTRAINT [FK_KaVermittlungBIBIP_FaLeistung]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_Priorisiert]  DEFAULT ((0)) FOR [Priorisiert]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_DossierInaktiv]  DEFAULT ((0)) FOR [DossierInaktiv]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_WechselKAIntern]  DEFAULT ((0)) FOR [WechselKAIntern]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_DossierRetourAnSD]  DEFAULT ((0)) FOR [DossierRetourAnSD]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaVermittlungBIBIP] ADD  CONSTRAINT [DF_KaVermittlungBIBIP_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

