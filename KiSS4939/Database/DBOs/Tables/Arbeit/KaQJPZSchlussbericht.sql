CREATE TABLE [dbo].[KaQJPZSchlussbericht](
	[KaQJPZSchlussberichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AQualitaetCode] [int] NULL,
	[ATempoCode] [int] NULL,
	[AOrganisationCode] [int] NULL,
	[LernfaehigkeitCode] [int] NULL,
	[LandesspracheCode] [int] NULL,
	[SelbstaendigCode] [int] NULL,
	[ZuverlaessigCode] [int] NULL,
	[PuenktlichCode] [int] NULL,
	[AusdauerCode] [int] NULL,
	[OrdnungCode] [int] NULL,
	[SorgfaltCode] [int] NULL,
	[AuftretenCode] [int] NULL,
	[KommunikationCode] [int] NULL,
	[TeamfaehigCode] [int] NULL,
	[KritikfaehigCode] [int] NULL,
	[FlexibilitaetCode] [int] NULL,
	[MotivationCode] [int] NULL,
	[ErscheinungCode] [int] NULL,
	[DeutschFlag] [bit] NOT NULL,
	[FranzFlag] [bit] NOT NULL,
	[BemKompetenz] [varchar](max) NULL,
	[BemBildung] [varchar](max) NULL,
	[BemZielvereinbarung] [varchar](max) NULL,
	[BemAbsenzen] [varchar](max) NULL,
	[BemEmpfehlung] [varchar](max) NULL,
	[EingVermittelbarFlag] [bit] NOT NULL,
	[EingVermittelbar] [varchar](max) NULL,
	[SchlussberichtDokID] [int] NULL,
	[BeurteilungDat] [datetime] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaQJPZSchlussberichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJPZSchlussbericht] PRIMARY KEY CLUSTERED 
(
	[KaQJPZSchlussberichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQJPZSchlussbericht_FaLeistungID] ON [dbo].[KaQJPZSchlussbericht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJPZSchlussbericht Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZSchlussbericht', @level2type=N'COLUMN',@level2name=N'KaQJPZSchlussberichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJPZSchlussbericht_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJPZSchlussbericht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht]  WITH CHECK ADD  CONSTRAINT [FK_KaQJPZSchlussbericht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht] CHECK CONSTRAINT [FK_KaQJPZSchlussbericht_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht] ADD  CONSTRAINT [DF_KaQJPZSchlussbericht_DeutschFlag]  DEFAULT ((0)) FOR [DeutschFlag]
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht] ADD  CONSTRAINT [DF_KaQJPZSchlussbericht_FranzFlag]  DEFAULT ((0)) FOR [FranzFlag]
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht] ADD  CONSTRAINT [DF_KaQJPZSchlussbericht_EingVermittelbarFlag]  DEFAULT ((0)) FOR [EingVermittelbarFlag]
GO

ALTER TABLE [dbo].[KaQJPZSchlussbericht] ADD  CONSTRAINT [DF_KaQJPZSchlussbericht_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO