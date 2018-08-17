CREATE TABLE [dbo].[KaVermittlungVorschlag](
	[KaVermittlungVorschlagID] [int] IDENTITY(1,1) NOT NULL,
	[KaEinsatzplatzID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[Vorschlag] [datetime] NULL,
	[DossierGesendet] [datetime] NULL,
	[Vorstellungsgespraech] [datetime] NULL,
	[SchnuppernVon] [datetime] NULL,
	[SchnuppernBis] [datetime] NULL,
	[VorschlagResultatDatum] [datetime] NULL,
	[VorschlagResultat] [int] NULL,
	[VorschlagErfasst] [datetime] NULL,
	[VorschlagAblehnungsgrundBICode] [int] NULL,
	[VorschlagAblehnungsgrundBIPCode] [int] NULL,
	[VorschlagAblehnungsgrundSICode] [int] NULL,
	[VorschlagBemerkungen] [varchar](1000) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaVermittlungVorschlagTS] [timestamp] NOT NULL,
	[MigrationKA] [int] NULL,
 CONSTRAINT [PK_KaVermittlungVorschlag] PRIMARY KEY CLUSTERED 
(
	[KaVermittlungVorschlagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaVermittlungVorschlag_FaLeistungID] ON [dbo].[KaVermittlungVorschlag] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KaVermittlungVorschlag_KaEinsatzplatzID] ON [dbo].[KaVermittlungVorschlag] 
(
	[KaEinsatzplatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaVermittlungVorschlag Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungVorschlag', @level2type=N'COLUMN',@level2name=N'KaVermittlungVorschlagID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungVorschlag_KaEinsatzplatz) => KaEinsatzplatz.KaEinsatzplatzID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungVorschlag', @level2type=N'COLUMN',@level2name=N'KaEinsatzplatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungVorschlag_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungVorschlag', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungVorschlag_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag] CHECK CONSTRAINT [FK_KaVermittlungVorschlag_FaLeistung]
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungVorschlag_KaEinsatzplatz] FOREIGN KEY([KaEinsatzplatzID])
REFERENCES [dbo].[KaEinsatzplatz] ([KaEinsatzplatzID])
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag] CHECK CONSTRAINT [FK_KaVermittlungVorschlag_KaEinsatzplatz]
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag] ADD  CONSTRAINT [DF_KaVermittlungVorschlag_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaVermittlungVorschlag] ADD  CONSTRAINT [DF_KaVermittlungVorschlag_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO