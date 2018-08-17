CREATE TABLE [dbo].[KaVermittlungProfil](
	[KaVermittlungProfilID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[AeussereErscheinungCode] [int] NULL,
	[AktuelleTaetigkeit] [varchar](1000) NULL,
	[ArbeitsgebietBemerkungen] [varchar](1000) NULL,
	[ArbeitszeitenCodes] [varchar](100) NULL,
	[AusbildungCode] [int] NULL,
	[AusbildungstypWunschCode] [int] NULL,
	[Bemerkungen] [varchar](1000) NULL,
	[BesondereFaehigkeiten] [varchar](1000) NULL,
	[BesondereWuensche] [varchar](1000) NULL,
	[BrancheCodes] [varchar](100) NULL,
	[DeutschMuendlichCode] [int] NULL,
	[DeutschSchriftlichCode] [int] NULL,
	[EinsatzbereichCodes] [varchar](100) NULL,
	[Einsatzpensum] [int] NULL,
	[EinsatzpensumBis] [int] NULL,
	[EinsatzpensumVon] [int] NULL,
	[FuehrerausweisCode] [int] NULL,
	[FuehrerausweisKategorieCode] [int] NULL,
	[GespraechDatum] [datetime] NULL,
	[GesundheitBemerkung] [varchar](1000) NULL,
	[GesundheitCode] [int] NULL,
	[GesundheitEinschraenkungen] [varchar](100) NULL,
	[GesundheitKoerperlichBewertung] [int] NULL,
	[GesundheitKoerperlichCode] [int] NULL,
	[GesundheitPsychischBewertung] [int] NULL,
	[GesundheitPsychischCode] [int] NULL,
	[InfoAnSDErfolgt] [bit] NOT NULL,
	[InizioErstgesprVerlaufDokID] [int] NULL,
	[Interview] [datetime] NULL,
	[IstAngemeldet] [bit] NOT NULL,
	[KaBetriebCodes] [varchar](100) NULL,
	[KaLaufendeBetreibungenCode] [int] NULL,
	[KaLohnabtretungSDCode] [int] NULL,
	[KaNachtarbeitCode] [int] NULL,	
	[KannSichAmTelVerstaendigen] [bit] NOT NULL,
	[KaSchweizerdeutschCode] [int] NULL,
	[KaVerfuegbarkeitCode] [int] NULL,
	[Kinderbetreuung] [int] NULL,
	[LehrberufCode] [int] NULL,
	[Lehrberuf2Code] [int] NULL,
	[Lehrberuf3Code] [int] NULL,
	[LehrberufWunschCode] [int] NULL,
	[MigrationKA] [bit] NOT NULL,
	[MotivationBIBIPSIBewertung] [int] NULL,
	[MotivationBIBIPSICode] [int] NULL,
	[MotivationInizioCode] [int] NULL,
	[PCKenntnisseCode] [int] NULL,
	[QJExtern] [bit] NOT NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[SIGespraech] [datetime] NULL,
	[SIGespraechfuehrerinID] [int] NULL,
	[Sprachstandermittlung] [int] NULL,
	[SuchtartCode] [int] NULL,
	[SuchtCode] [int] NULL,
	[TherpieCode] [int] NULL,
	[UnterstuetzungInizioCodes] [varchar](100) NULL,
	[EinschraenkungMO] [varchar](1000) NULL,
	[EinschraenkungDI] [varchar](1000) NULL,
	[EinschraenkungMI] [varchar](1000) NULL,
	[EinschraenkungDO] [varchar](1000) NULL,
	[EinschraenkungFR] [varchar](1000) NULL,
	[EinschraenkungSA] [varchar](1000) NULL,
	[EinschraenkungSO] [varchar](1000) NULL,
	[VermittelbarkeitBemerkung] [varchar](100) NULL,
	[VermittelbarkeitBIBIPCode] [int] NULL,
	[VermittelbarkeitSICode] [int] NULL,
	[VermittlungsgespraechDokID] [int] NULL,
	[ZuverlaessigkeitBewertung] [int] NULL,
	[ZuverlaessigkeitCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaVermittlungProfilTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaVermittlungProfil] PRIMARY KEY CLUSTERED 
(
	[KaVermittlungProfilID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KaVermittlungProfil_FaLeistungID]    Script Date: 06/27/2016 09:34:25 ******/
CREATE NONCLUSTERED INDEX [IX_KaVermittlungProfil_FaLeistungID] ON [dbo].[KaVermittlungProfil] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaVermittlungProfil Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaVermittlungProfilID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaVermittlungProfil_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewertungswert zwichen 1 und 10 für die Spalte GesundheitKoerperlichCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'GesundheitKoerperlichBewertung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewertungswert zwichen 1 und 10 für die Spalte GesundheitPsychischCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'GesundheitPsychischBewertung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewertungswert zwichen 1 und 10 für die Spalte ZuverlaessigkeitCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'ZuverlaessigkeitBewertung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewertungswert zwichen 1 und 10 für die Spalte MotivationBIBIPSICode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'MotivationBIBIPSIBewertung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zum wissen ob den Klient für andere berufliche, gesundheitliche oder soziale Integrationsmassnahmen- und/oder Abklärungen angemeldet ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'IstAngemeldet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaSchweizerdeutschCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaSchweizerdeutschCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaLaufendeBetreibungenCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaLaufendeBetreibungenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaLohnabtretungSDCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaLohnabtretungSDCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaVermittlungProfilTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AktuelleTaetigkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'AktuelleTaetigkeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KaVerfuegbarkeitCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'KaVerfuegbarkeitCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungMO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungMO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungDI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungDI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungMI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungMI'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungDO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungDO'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungFR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungFR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungSA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungSA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'EinschraenkungSO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaVermittlungProfil', @level2type=N'COLUMN',@level2name=N'EinschraenkungSO'
GO


ALTER TABLE [dbo].[KaVermittlungProfil]  WITH CHECK ADD  CONSTRAINT [FK_KaVermittlungProfil_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaVermittlungProfil] CHECK CONSTRAINT [FK_KaVermittlungProfil_FaLeistung]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_QJExtern]  DEFAULT ((0)) FOR [QJExtern]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_KannSichAmTelVerstaendigen]  DEFAULT ((0)) FOR [KannSichAmTelVerstaendigen]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_InfoAnSDErfolgt]  DEFAULT ((0)) FOR [InfoAnSDErfolgt]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_IstAngemeldet]  DEFAULT ((0)) FOR [IstAngemeldet]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaVermittlungProfil] ADD  CONSTRAINT [DF_KaVermittlungProfil_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


