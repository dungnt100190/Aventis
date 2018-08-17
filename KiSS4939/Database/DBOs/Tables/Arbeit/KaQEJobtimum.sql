CREATE TABLE [dbo].[KaQEJobtimum](
	[KaQEJobtimumID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ZielDat1] [datetime] NULL,
	[ZielDat2] [datetime] NULL,
	[ZielDat3] [datetime] NULL,
	[ZielDat4] [datetime] NULL,
	[ZielCode1] [int] NULL,
	[ZielCode2] [int] NULL,
	[ZielCode3] [int] NULL,
	[ZielCode4] [int] NULL,
	[Ziel1DokID] [int] NULL,
	[Ziel2DokID] [int] NULL,
	[Ziel3DokID] [int] NULL,
	[Ziel4DokID] [int] NULL,
	[ZwischenberichtDokID] [int] NULL,
	[SchlussberichtDokID] [int] NULL,
	[Schlussbericht1DokID] [int] NULL,
	[TeilnahmebestDokID] [int] NULL,
	[EinladungDat1] [datetime] NULL,
	[EinladungDat2] [datetime] NULL,
	[Einladung1DokID] [int] NULL,
	[Einladung2DokID] [int] NULL,
	[Einladung1Flag] [bit] NOT NULL,
	[Einladung2Flag] [bit] NOT NULL,
	[ProgBeginnOLD] [bit] NULL,
	[ProgBeginnCodeOLD] [int] NULL,
	[ChecklisteFlag] [bit] NOT NULL,
	[HausordnungFlag] [bit] NOT NULL,
	[HausrundgangFlag] [bit] NOT NULL,
	[UnterlagenFlag] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[TerminDat] [datetime] NULL,
	[Zusatzinfos] [varchar](max) NULL,
	[muendAuffordDat1] [datetime] NULL,
	[muendAuffordDat2] [datetime] NULL,
	[muendAuffordBem1] [varchar](max) NULL,
	[muendAuffordBem2] [varchar](max) NULL,
	[Verwarnung1DokID] [int] NULL,
	[Verwarnung2DokID] [int] NULL,
	[Verwarnung1aDokID] [int] NULL,
	[Verwarnung2aDokID] [int] NULL,
	[ProgAbbruchDokID] [int] NULL,
	[AustrittDatum] [datetime] NULL,
	[AustrittGrund] [int] NULL,
	[AustrittCode] [int] NULL,
	[AustrittBemerkung] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQEJobtimumTS] [timestamp] NOT NULL,
	[ProgAbbruch2DokID] [int] NULL,
 CONSTRAINT [PK_KaQEJobtimum] PRIMARY KEY CLUSTERED 
(
	[KaQEJobtimumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQEJobtimum_FaLeistungID] ON [dbo].[KaQEJobtimum] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQEJobtimum Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEJobtimum', @level2type=N'COLUMN',@level2name=N'KaQEJobtimumID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQEJobtimum_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEJobtimum', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQEJobtimum]  WITH CHECK ADD  CONSTRAINT [FK_KaQEJobtimum_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQEJobtimum] CHECK CONSTRAINT [FK_KaQEJobtimum_FaLeistung]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_Einladung1Flag]  DEFAULT ((0)) FOR [Einladung1Flag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_Einladung2Flag]  DEFAULT ((0)) FOR [Einladung2Flag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_ChecklisteFlag]  DEFAULT ((0)) FOR [ChecklisteFlag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_HausordnungFlag]  DEFAULT ((0)) FOR [HausordnungFlag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_HausrundgangFlag]  DEFAULT ((0)) FOR [HausrundgangFlag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_UnterlagenFlag]  DEFAULT ((0)) FOR [UnterlagenFlag]
GO

ALTER TABLE [dbo].[KaQEJobtimum] ADD  CONSTRAINT [DF_KaQEJobtimum_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO