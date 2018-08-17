CREATE TABLE [dbo].[BaPerson](
	[BaPersonID] [int] IDENTITY(1,1) NOT NULL,
	[StatusPersonCode] [int] NULL,
	[Titel] [varchar](50) NULL,
	[Name] [varchar](100) NOT NULL,
	[FruehererName] [varchar](100) NULL,
	[Vorname] [varchar](100) NULL,
	[Vorname2] [varchar](100) NULL,
	[Geburtsdatum] [datetime] NULL,
	[Sterbedatum] [datetime] NULL,
	[AHVNummer] [varchar](16) NULL,
	[Versichertennummer] [varchar](18) NULL,
	[HaushaltVersicherungsNummer] [varchar](18) NULL,
	[NNummer] [varchar](20) NULL,
	[BFFNummer] [varchar](20) NULL,
	[ZARNummer] [varchar](20) NULL,
	[ZIPNr] [int] NULL,
	[KantonaleReferenznummer] [varchar](50) NULL,
	[GeschlechtCode] [int] NULL,
	[ZivilstandCode] [int] NULL,
	[ZivilstandDatum] [datetime] NULL,
	[HeimatgemeindeCode] [int] NULL,
	[HeimatgemeindeCodes] [varchar](255) NULL,
	[NationalitaetCode] [int] NULL,
	[ReligionCode] [int] NULL,
	[AuslaenderStatusCode] [int] NULL,
	[AuslaenderStatusGueltigBis] [datetime] NULL,
	[Telefon_P] [varchar](100) NULL,
	[Telefon_G] [varchar](100) NULL,
	[MobilTel1] [varchar](100) NULL,
	[MobilTel2] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[SprachCode] [int] NULL,
	[Unterstuetzt] [bit] NULL,
	[Fiktiv] [bit] NOT NULL,
	[Bemerkung] [varchar](max) NULL,
	[EinwohnerregisterAktiv] [bit] NOT NULL,
	[EinwohnerregisterID] [varchar](50) NULL,
	[DeutschVerstehenCode] [int] NULL,
	[WichtigerHinweisCode] [int] NULL,
	[ZuzugKtPLZ] [varchar](10) NULL,
	[ZuzugKtOrtCode] [int] NULL,
	[ZuzugKtOrt] [varchar](50) NULL,
	[ZuzugKtKanton] [varchar](10) NULL,
	[ZuzugKtLandCode] [int] NULL,
	[ZuzugKtDatum] [datetime] NULL,
	[ZuzugKtSeitGeburt] [bit] NULL,
	[ZuzugGdePLZ] [varchar](10) NULL,
	[ZuzugGdeOrtCode] [int] NULL,
	[ZuzugGdeOrt] [varchar](50) NULL,
	[ZuzugGdeKanton] [varchar](10) NULL,
	[ZuzugGdeLandCode] [int] NULL,
	[ZuzugGdeDatum] [datetime] NULL,
	[ZuzugGdeSeitGeburt] [bit] NULL,
	[UntWohnsitzPLZ] [varchar](10) NULL,
	[UntWohnsitzOrt] [varchar](50) NULL,
	[UntWohnsitzKanton] [varchar](10) NULL,
	[UntWohnsitzLandCode] [int] NULL,
	[WegzugPLZ] [varchar](10) NULL,
	[WegzugOrtCode] [int] NULL,
	[WegzugOrt] [varchar](50) NULL,
	[WegzugKanton] [varchar](10) NULL,
	[WegzugLandCode] [int] NULL,
	[WegzugDatum] [datetime] NULL,
	[WohnsitzWieBaPersonID] [int] NULL,
	[AufenthaltWieBaInstitutionID] [int] NULL,
	[ErwerbssituationCode] [int] NULL,
	[GrundTeilzeitarbeit1Code] [int] NULL,
	[GrundTeilzeitarbeit2Code] [int] NULL,
	[BaGrundNichtErwerbstaetigCode] [int] NULL,
	[ErwerbsBrancheCode] [int] NULL,
	[ErlernterBerufCode] [int] NULL,
	[BerufCode] [int] NULL,
	[HoechsteAusbildungCode] [int] NULL,
	[AbgebrocheneAusbildungCode] [int] NULL,
	[ArbeitSpezFaehigkeiten] [varchar](max) NULL,
	[KbKostenstelleID] [int] NULL,
	[InCHSeit] [datetime] NULL,
	[InCHSeitGeburt] [bit] NOT NULL,
	[PUAnzahlVerlustscheine] [int] NULL,
	[PUKrankenkasse] [varchar](50) NULL,
	[PraemienuebernahmeVon] [datetime] NULL,
	[PraemienuebernahmeBis] [datetime] NULL,
	[PersonOhneLeistung] [bit] NOT NULL,
	[HCMCFluechtling] [bit] NOT NULL,
	[StellensuchendCode] [int] NULL,
	[ResoNr] [int] NULL,
	[NEAnmeldung] [datetime] NULL,
	[HeimatgemeindeBaGemeindeID] [int] NULL,
	[AktiveKopfQuote] [bit] NULL,
	[ALK] [bit] NOT NULL,
	[AndereSVLeistungen] [varchar](max) NULL,
	[Anrede] [varchar](100) NULL,
	[AusbildungCode] [int] NULL,
	[Behinderungsart2Code] [int] NULL,
	[BemerkungenAdresse] [varchar](max) NULL,
	[BemerkungenSV] [varchar](max) NULL,
	[BeruflicheMassnahmeIV] [bit] NOT NULL,
	[Briefanrede] [varchar](100) NULL,
	[BSVBehinderungsartCode] [int] NULL,
	[BVGRente] [bit] NOT NULL,
	[CAusweisDatum] [datetime] NULL,
	[KlientenkontoNr] [int] NULL,
	[DebitorNr] [int] NULL,
	[DebitorUpdate] [datetime] NULL,
	[EigenerMietvertrag] [bit] NOT NULL,
	[Einrichtpauschale] [money] NULL,
	[EinrichtungspauschaleCode] [int] NULL,
	[ErgaenzungsLeistungen] [bit] NOT NULL,
	[Assistenzbeitrag] [bit] NOT NULL,
	[DatumAssistenzbeitrag] [datetime] NULL,
	[IvVerfuegteAssistenzberatung] [int] NULL,
	[DatumIvVerfuegung] [datetime] NULL,
	[ErteilungVA] [datetime] NULL,
	[IstFamiliennachzug] [bit] NOT NULL,
	[Fax] [varchar](100) NULL,
	[HauptBehinderungsartCode] [int] NULL,
	[HELBKeinAntrag] [bit] NOT NULL,
	[HELBAb] [datetime] NULL,
	[HELBAnmeldung] [datetime] NULL,
	[HELBEntscheid] [datetime] NULL,
	[HELBEntscheidCode] [int] NULL,
	[HilfslosenEntschaedigungCode] [int] NULL,
	[ImKantonSeit] [datetime] NULL,
	[ImKantonSeitGeburt] [bit] NOT NULL,
	[InGemeindeSeit] [datetime] NULL,
	[IntensivPflegeZuschlagCode] [int] NULL,
	[IVBerechtigungAnfangsStatusCode] [int] NULL,
	[IVBerechtigungErsterEntscheidAb] [datetime] NULL,
	[IVBerechtigungErsterEntscheidCode] [int] NULL,
	[IVBerechtigungZweiterEntscheidAb] [datetime] NULL,
	[IVBerechtigungZweiterEntscheidCode] [int] NULL,
	[IVGrad] [int] NULL,
	[IVHilfsmittel] [bit] NOT NULL,
	[IVTaggeld] [bit] NOT NULL,
	[KeinSerienbrief] [bit] NOT NULL,
	[KonfessionCode] [int] NULL,
	[KontoFuehrung] [bit] NOT NULL,
	[BaPersonID_Dossiertraeger] [int] NULL,
	[Kopfquote_BaInstitutionID] [int] NULL,
	[KopfquoteAbDatum] [datetime] NULL,
	[KopfquoteBisDatum] [datetime] NULL,
	[KorrespondenzSpracheCode] [int] NULL,
	[KTG] [bit] NOT NULL,
	[LaufendeVollmachtErlaubnis] [bit] NOT NULL,
	[ManuelleAnrede] [bit] NOT NULL,
	[MedizinischeMassnahmeIV] [bit] NOT NULL,
	[Mehrfachbehinderung] [bit] NOT NULL,
	[MietdepotPI] [bit] NOT NULL,
	[MigrationKA] [int] NULL,
	[MobilTel] [varchar](100) NULL,
	[NavigatorZusatz] [varchar](30) NULL,
	[PassiveKopfQuote] [bit] NULL,
	[PauschaleAktualDatum] [datetime] NULL,
	[PersonSichtbarSDFlag] [bit] NOT NULL,
	[ProjNr] [int] NULL,
	[RentenstufeCode] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Sozialhilfe] [bit] NOT NULL,
	[Sprachpauschale] [money] NULL,
	[Testperson] [bit] NOT NULL,
	[UntWohnsitzOrtCode] [int] NULL,
	[UVGRente] [bit] NOT NULL,
	[UVGTaggeld] [bit] NOT NULL,
	[VerstaendigungSprachCode] [int] NULL,
	[visdat36Area] [varchar](255) NULL,
	[visdat36ID] [varchar](6) NULL,
	[VormundMassnahmenCode] [int] NULL,
	[VormundPI] [bit] NOT NULL,
	[WichtigerHinweis] [varchar](1000) NULL,
	[WittwenWittwerWaisenrente] [bit] NOT NULL,
	[WohnstatusCode] [int] NULL,
	[ZeigeDetails] [bit] NOT NULL,
	[ZeigeTelGeschaeft] [bit] NOT NULL,
	[ZeigeTelMobil] [bit] NOT NULL,
	[ZeigeTelPrivat] [bit] NOT NULL,
	[ZEMISNummer] [varchar](20) NULL,
	[IstBerechnungsperson] [bit] NOT NULL,
	[DatumAsylgesuch] [datetime] NULL,
	[DatumEinbezugFaz] [datetime] NULL,
	[VerID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPerson] PRIMARY KEY CLUSTERED 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaPerson_BaPersonID_Dossiertraeger]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_BaPersonID_Dossiertraeger] ON [dbo].[BaPerson] 
(
	[BaPersonID_Dossiertraeger] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_BaPersonID_Name_Vorname]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_BaPersonID_Name_Vorname] ON [dbo].[BaPerson] 
(
	[BaPersonID] ASC
)
INCLUDE ( [Name],
[Vorname]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_BaPersonID_Name_Vorname_Geburtsdatum]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_BaPersonID_Name_Vorname_Geburtsdatum] ON [dbo].[BaPerson] 
(
	[BaPersonID] ASC,
	[Name] ASC,
	[Vorname] ASC,
	[Geburtsdatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_Birthday]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Birthday] ON [dbo].[BaPerson] 
(
	[Geburtsdatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_Kopfquote_BaInstitutionID]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Kopfquote_BaInstitutionID] ON [dbo].[BaPerson] 
(
	[Kopfquote_BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_Name_Vorname]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Name_Vorname] ON [dbo].[BaPerson] 
(
	[Name] ASC,
	[Vorname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_NationalitaetCode]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_NationalitaetCode] ON [dbo].[BaPerson] 
(
	[NationalitaetCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_UntWohnsitzLandCode]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_UntWohnsitzLandCode] ON [dbo].[BaPerson] 
(
	[UntWohnsitzLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_Vorname]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_Vorname] ON [dbo].[BaPerson] 
(
	[Vorname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_WegzugLandCode]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_WegzugLandCode] ON [dbo].[BaPerson] 
(
	[WegzugLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_ZipNummer]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_ZipNummer] ON [dbo].[BaPerson] 
(
	[ZIPNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_ZuzugGdeLandCode]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_ZuzugGdeLandCode] ON [dbo].[BaPerson] 
(
	[ZuzugGdeLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaPerson_ZuzugKtLandCode]    Script Date: 02/17/2015 07:39:09 ******/
CREATE NONCLUSTERED INDEX [IX_BaPerson_ZuzugKtLandCode] ON [dbo].[BaPerson] 
(
	[ZuzugKtLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX IX_BaPerson_KontoFuehrung ON [dbo].[BaPerson] 
(
    [KontoFuehrung]
)
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'StatusPersonCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Policen-Nummer der Haushaltsversicherung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HaushaltVersicherungsNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HaushaltVersicherungsNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZIPNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KantonaleReferenznummer'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HeimatgemeindeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HeimatgemeindeCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ReligionCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MobilTel1'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MobilTel2'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'EinwohnerregisterAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'EinwohnerregisterID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DeutschVerstehenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WichtigerHinweisCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WohnsitzWieBaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'AufenthaltWieBaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'GrundTeilzeitarbeit1Code'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'GrundTeilzeitarbeit2Code'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BaGrundNichtErwerbstaetigCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ErwerbsBrancheCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ErlernterBerufCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BerufCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HoechsteAusbildungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'AbgebrocheneAusbildungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ArbeitSpezFaehigkeiten'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KbKostenstelleID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PUAnzahlVerlustscheine'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PUKrankenkasse'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PraemienuebernahmeVon'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PraemienuebernahmeBis'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PersonOhneLeistung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HCMCFluechtling'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'StellensuchendCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ResoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'NEAnmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HeimatgemeindeBaGemeindeID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'AktiveKopfQuote'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ALK'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'AndereSVLeistungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anrede der Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Anrede'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Anrede'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'AusbildungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Behinderungsart2Code'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BemerkungenAdresse'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BemerkungenSV'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BeruflicheMassnahmeIV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Briefanrede der Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Briefanrede'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Briefanrede'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BSVBehinderungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BVGRente'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'CAusweisDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KlientenkontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DebitorNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DebitorUpdate'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'EigenerMietvertrag'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Einrichtpauschale'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'EinrichtungspauschaleCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ErgaenzungsLeistungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum wissen ob die Person Assistenzbeitrag hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Assistenzbeitrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Beitrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DatumAssistenzbeitrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anzahl Stunden für die IV verfügte Assistenzberatung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IvVerfuegteAssistenzberatung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Verfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DatumIvVerfuegung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ErteilungVA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checkbox FAZ für Familiennachzug (CAR/SRK spezifisch)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IstFamiliennachzug'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'IBE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IstFamiliennachzug'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HauptBehinderungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird von PI auf eine HELB Anmeldung verzichtet, so wird dieses Flag auf True gesetzt und die anderen HELB-Felder geleert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBKeinAntrag'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBAb'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBAnmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, wann der Entscheid für oder gegen HELB getroffen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBEntscheid'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBEntscheid'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HELBEntscheidCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'HilfslosenEntschaedigungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ImKantonSeit'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ImKantonSeitGeburt'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'InGemeindeSeit'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IntensivPflegeZuschlagCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVBerechtigungAnfangsStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVBerechtigungErsterEntscheidAb'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVBerechtigungErsterEntscheidCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVBerechtigungZweiterEntscheidAb'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVBerechtigungZweiterEntscheidCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVGrad'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVHilfsmittel'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IVTaggeld'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Person Serienbriefe erhalten soll oder nicht (0=Serienbrief, 1=kein Serienbrief)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KeinSerienbrief'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KeinSerienbrief'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KonfessionCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KontoFuehrung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID des Dossierträgers. Fremdschlüssel (FK_BaPerson_BaPerson_Dossiertraeger) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID_Dossiertraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'CAR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID_Dossiertraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Kopfquote_BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KopfquoteAbDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KopfquoteBisDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code für die Erfassung der Korrespondenzsprache, betrifft LOV: BaKorrespondenzSprache' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KorrespondenzSpracheCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KorrespondenzSpracheCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'KTG'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'LaufendeVollmachtErlaubnis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Anrede manuell oder automatisch erzeugt wird. Bei der manuellen Anrede kommen die Felder Anrede und Briefanrede zur Geltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ManuelleAnrede'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ManuelleAnrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Neues Feld für medizinische Massnahmen IV. Nur für PI (siehe Ticket: #5022)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MedizinischeMassnahmeIV'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MedizinischeMassnahmeIV'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Mehrfachbehinderung'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MietdepotPI'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MigrationKA'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'MobilTel'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'NavigatorZusatz'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PassiveKopfQuote'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PauschaleAktualDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'PersonSichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ProjNr'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'RentenstufeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'SichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Sozialhilfe'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Sprachpauschale'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Testperson'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'UntWohnsitzOrtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'UVGRente'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'UVGTaggeld'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'VerstaendigungSprachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aus der Migration von VIS nach KiSS: Spezifische VIS-Access-DB, welche als Quelle für den Datensatz diente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36Area'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36Area'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aus der Migration von VIS nach KiSS: ID in der Area-spezifischen VIS-Access-DB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36ID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36ID'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'VormundMassnahmenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'VormundPI'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WichtigerHinweis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wittwen-, Wittwer-, Waisenrente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WittwenWittwerWaisenrente'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WittwenWittwerWaisenrente'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'WohnstatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZeigeDetails'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZeigeTelGeschaeft'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZeigeTelMobil'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZeigeTelPrivat'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'Standard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'ZEMISNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob die Person eine Berechnungsperson ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'IstBerechnungsperson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Asylgesuch-Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DatumAsylgesuch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Einbezug FAZ / Geburt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'DatumEinbezugFaz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VersionsID des Records für die Historisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'VerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonTS'
GO

/****** Object:  Trigger [dbo].[trHist_BaPerson]    Script Date: 02/17/2015 07:39:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE TRIGGER [dbo].[trHist_BaPerson]
	ON [dbo].[BaPerson]
	FOR INSERT, UPDATE, DELETE
AS BEGIN
	SET NOCOUNT ON
	DECLARE @VerID     INT

	SELECT TOP 1 @VerID = VerID FROM HistoryVersion
	WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
	ORDER BY VerID DESC

	IF @VerID IS NULL BEGIN
		RAISERROR ('Table [BaPerson] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
		ROLLBACK TRANSACTION
	END

	DECLARE @Changes TABLE (
		[BaPersonID] int NOT NULL,
		VerID         int NULL,
		ActionCode    int NOT NULL
		PRIMARY KEY (ActionCode, [BaPersonID])
	)

	INSERT INTO @Changes
		SELECT IsNull(INS.[BaPersonID], DEL.[BaPersonID]), TBL.VerID,
			CASE WHEN (INS.[BaPersonID] IS NULL) THEN 3 WHEN (DEL.[BaPersonID] IS NULL) THEN 1 ELSE 2 END
		FROM INSERTED                                INS
			FULL OUTER JOIN DELETED                    DEL ON DEL.[BaPersonID] = INS.[BaPersonID]
			LEFT       JOIN [Hist_BaPerson]  TBL ON TBL.[BaPersonID] = DEL.[BaPersonID] AND TBL.VerID_DELETED IS NULL
		WHERE (INS.[BaPersonID] IS NULL) OR (DEL.[BaPersonID] IS NULL)
			OR CHECKSUM(
				INS.[BaPersonID], INS.[StatusPersonCode], INS.[Titel], INS.[Name], INS.[FruehererName], INS.[Vorname], INS.[Vorname2], INS.[Geburtsdatum],
				INS.[Sterbedatum], INS.[AHVNummer], INS.[Versichertennummer], INS.[HaushaltVersicherungsNummer], INS.[NNummer], INS.[BFFNummer], INS.[ZARNummer], INS.[ZIPNr], INS.[KantonaleReferenznummer],
				INS.[GeschlechtCode], INS.[ZivilstandCode], INS.[ZivilstandDatum], INS.[HeimatgemeindeCode], INS.[HeimatgemeindeCodes], INS.[NationalitaetCode],
				INS.[ReligionCode], INS.[AuslaenderStatusCode], INS.[AuslaenderStatusGueltigBis], INS.[Telefon_P], INS.[Telefon_G], INS.[MobilTel1], 
				INS.[MobilTel2], INS.[EMail], INS.[SprachCode], INS.[Unterstuetzt], INS.[Fiktiv], INS.[Bemerkung], INS.[EinwohnerregisterAktiv], INS.[EinwohnerregisterID], INS.[DeutschVerstehenCode],
				INS.[WichtigerHinweisCode], INS.[ZuzugKtPLZ], INS.[ZuzugKtOrtCode], INS.[ZuzugKtOrt], INS.[ZuzugKtKanton], INS.[ZuzugKtLandCode], 
				INS.[ZuzugKtDatum], INS.[ZuzugKtSeitGeburt], INS.[ZuzugGdePLZ], INS.[ZuzugGdeOrtCode], INS.[ZuzugGdeOrt], INS.[ZuzugGdeKanton], 
				INS.[ZuzugGdeLandCode], INS.[ZuzugGdeDatum], INS.[ZuzugGdeSeitGeburt], INS.[UntWohnsitzPLZ], INS.[UntWohnsitzOrt], INS.[UntWohnsitzKanton],
				INS.[UntWohnsitzLandCode], INS.[WegzugPLZ], INS.[WegzugOrtCode], INS.[WegzugOrt], INS.[WegzugKanton], INS.[WegzugLandCode], INS.[WegzugDatum],
				INS.[WohnsitzWieBaPersonID], INS.[AufenthaltWieBaInstitutionID], INS.[ErwerbssituationCode], INS.[GrundTeilzeitarbeit1Code], 
				INS.[GrundTeilzeitarbeit2Code], INS.[BaGrundNichtErwerbstaetigCode], INS.[ErwerbsBrancheCode], INS.[ErlernterBerufCode], INS.[BerufCode], INS.[HoechsteAusbildungCode], 
				INS.[AbgebrocheneAusbildungCode], INS.[ArbeitSpezFaehigkeiten], INS.[KbKostenstelleID], INS.[InCHSeit], INS.[InCHSeitGeburt], 
				INS.[PUAnzahlVerlustscheine], INS.[PUKrankenkasse], INS.[PraemienuebernahmeVon], INS.[PraemienuebernahmeBis], INS.[PersonOhneLeistung],
				INS.[HCMCFluechtling], INS.[StellensuchendCode], INS.[ResoNr], INS.[NEAnmeldung], INS.[HeimatgemeindeBaGemeindeID], INS.[AktiveKopfQuote],
				INS.[ALK], INS.[AndereSVLeistungen], INS.[Anrede], INS.[AusbildungCode], INS.[Behinderungsart2Code], INS.[BemerkungenAdresse], 
				INS.[BemerkungenSV], INS.[BeruflicheMassnahmeIV], INS.[Briefanrede], INS.[BSVBehinderungsartCode], INS.[BVGRente], INS.[CAusweisDatum],INS.[KlientenkontoNr],
				INS.[DebitorNr], INS.[DebitorUpdate], INS.[EigenerMietvertrag], INS.[Einrichtpauschale], INS.[EinrichtungspauschaleCode], 
				INS.[ErgaenzungsLeistungen], INS.[Assistenzbeitrag], INS.[DatumAssistenzbeitrag], INS.[IvVerfuegteAssistenzberatung], INS.[DatumIvVerfuegung], INS.[ErteilungVA], 
				INS.[IstFamiliennachzug], INS.[Fax], INS.[HauptBehinderungsartCode], INS.[HELBKeinAntrag], INS.[HELBAb], 
				INS.[HELBAnmeldung], INS.[HELBEntscheid], INS.[HELBEntscheidCode], INS.[HilfslosenEntschaedigungCode], INS.[ImKantonSeit], 
				INS.[ImKantonSeitGeburt], INS.[InGemeindeSeit], INS.[IntensivPflegeZuschlagCode], INS.[IVBerechtigungAnfangsStatusCode], 
				INS.[IVBerechtigungErsterEntscheidAb], INS.[IVBerechtigungErsterEntscheidCode], INS.[IVBerechtigungZweiterEntscheidAb], 
				INS.[IVBerechtigungZweiterEntscheidCode], INS.[IVGrad], INS.[IVHilfsmittel], INS.[IVTaggeld], INS.[KeinSerienbrief], INS.[KonfessionCode],
				INS.[KontoFuehrung], INS.[BaPersonID_Dossiertraeger], INS.[Kopfquote_BaInstitutionID], INS.[KopfquoteAbDatum], INS.[KopfquoteBisDatum], INS.[KorrespondenzSpracheCode],
				INS.[KTG], INS.[LaufendeVollmachtErlaubnis], INS.[ManuelleAnrede], INS.[MedizinischeMassnahmeIV], INS.[Mehrfachbehinderung], 
				INS.[MietdepotPI], INS.[MigrationKA], INS.[MobilTel], INS.[NavigatorZusatz], INS.[PassiveKopfQuote], INS.[PauschaleAktualDatum], 
				INS.[PersonSichtbarSDFlag], INS.[ProjNr], INS.[RentenstufeCode], INS.[SichtbarSDFlag], INS.[Sozialhilfe], INS.[Sprachpauschale], 
				INS.[Testperson], INS.[UntWohnsitzOrtCode], INS.[UVGRente], INS.[UVGTaggeld], INS.[VerstaendigungSprachCode], INS.[visdat36Area],
				INS.[visdat36ID], INS.[VormundMassnahmenCode], INS.[VormundPI], INS.[WichtigerHinweis], INS.[WittwenWittwerWaisenrente], INS.[WohnstatusCode], INS.[ZeigeDetails], 
				INS.[ZeigeTelGeschaeft], INS.[ZeigeTelMobil], INS.[ZeigeTelPrivat], INS.[ZEMISNummer], INS.[IstBerechnungsperson], INS.[DatumAsylgesuch], INS.[DatumEinbezugFaz], /*INS.[VerID], */INS.[Creator], INS.[Created], 
				INS.[Modifier], INS.[Modified])
			<> CHECKSUM(TBL.[BaPersonID], TBL.[StatusPersonCode], TBL.[Titel], TBL.[Name], TBL.[FruehererName], TBL.[Vorname],  TBL.[Vorname2], TBL.[Geburtsdatum],
				TBL.[Sterbedatum], TBL.[AHVNummer], TBL.[Versichertennummer], TBL.[HaushaltVersicherungsNummer], TBL.[NNummer], TBL.[BFFNummer], TBL.[ZARNummer], TBL.[ZIPNr], TBL.[KantonaleReferenznummer],
				TBL.[GeschlechtCode], TBL.[ZivilstandCode], TBL.[ZivilstandDatum], TBL.[HeimatgemeindeCode], TBL.[HeimatgemeindeCodes], TBL.[NationalitaetCode],
				TBL.[ReligionCode], TBL.[AuslaenderStatusCode], TBL.[AuslaenderStatusGueltigBis], TBL.[Telefon_P], TBL.[Telefon_G], TBL.[MobilTel1], 
				TBL.[MobilTel2], TBL.[EMail], TBL.[SprachCode], TBL.[Unterstuetzt], TBL.[Fiktiv], TBL.[Bemerkung], TBL.[EinwohnerregisterAktiv], TBL.[EinwohnerregisterID], TBL.[DeutschVerstehenCode],
				TBL.[WichtigerHinweisCode], TBL.[ZuzugKtPLZ], TBL.[ZuzugKtOrtCode], TBL.[ZuzugKtOrt], TBL.[ZuzugKtKanton], TBL.[ZuzugKtLandCode],
				TBL.[ZuzugKtDatum], TBL.[ZuzugKtSeitGeburt], TBL.[ZuzugGdePLZ], TBL.[ZuzugGdeOrtCode], TBL.[ZuzugGdeOrt], TBL.[ZuzugGdeKanton], 
				TBL.[ZuzugGdeLandCode], TBL.[ZuzugGdeDatum], TBL.[ZuzugGdeSeitGeburt], TBL.[UntWohnsitzPLZ], TBL.[UntWohnsitzOrt], TBL.[UntWohnsitzKanton],
				TBL.[UntWohnsitzLandCode], TBL.[WegzugPLZ], TBL.[WegzugOrtCode], TBL.[WegzugOrt], TBL.[WegzugKanton], TBL.[WegzugLandCode], TBL.[WegzugDatum],
				TBL.[WohnsitzWieBaPersonID], TBL.[AufenthaltWieBaInstitutionID], TBL.[ErwerbssituationCode], TBL.[GrundTeilzeitarbeit1Code], 
				TBL.[GrundTeilzeitarbeit2Code], TBL.[BaGrundNichtErwerbstaetigCode], TBL.[ErwerbsBrancheCode], TBL.[ErlernterBerufCode], TBL.[BerufCode], TBL.[HoechsteAusbildungCode],
				TBL.[AbgebrocheneAusbildungCode], TBL.[ArbeitSpezFaehigkeiten], TBL.[KbKostenstelleID], TBL.[InCHSeit], TBL.[InCHSeitGeburt], 
				TBL.[PUAnzahlVerlustscheine], TBL.[PUKrankenkasse], TBL.[PraemienuebernahmeVon], TBL.[PraemienuebernahmeBis], TBL.[PersonOhneLeistung],
				TBL.[HCMCFluechtling], TBL.[StellensuchendCode], TBL.[ResoNr], TBL.[NEAnmeldung], TBL.[HeimatgemeindeBaGemeindeID], TBL.[AktiveKopfQuote],
				TBL.[ALK], TBL.[AndereSVLeistungen], TBL.[Anrede], TBL.[AusbildungCode], TBL.[Behinderungsart2Code], TBL.[BemerkungenAdresse], 
				TBL.[BemerkungenSV], TBL.[BeruflicheMassnahmeIV], TBL.[Briefanrede], TBL.[BSVBehinderungsartCode], TBL.[BVGRente], TBL.[CAusweisDatum], TBL.[KlientenkontoNr],
				TBL.[DebitorNr], TBL.[DebitorUpdate], TBL.[EigenerMietvertrag], TBL.[Einrichtpauschale], TBL.[EinrichtungspauschaleCode], 
				TBL.[ErgaenzungsLeistungen], TBL.[Assistenzbeitrag], TBL.[DatumAssistenzbeitrag], TBL.[IvVerfuegteAssistenzberatung], TBL.[DatumIvVerfuegung], TBL.[ErteilungVA], TBL.[IstFamiliennachzug], TBL.[Fax], TBL.[HauptBehinderungsartCode], TBL.[HELBKeinAntrag], TBL.[HELBAb], 
				TBL.[HELBAnmeldung], TBL.[HELBEntscheid], TBL.[HELBEntscheidCode], TBL.[HilfslosenEntschaedigungCode], TBL.[ImKantonSeit], 
				TBL.[ImKantonSeitGeburt], TBL.[InGemeindeSeit], TBL.[IntensivPflegeZuschlagCode], TBL.[IVBerechtigungAnfangsStatusCode], 
				TBL.[IVBerechtigungErsterEntscheidAb], TBL.[IVBerechtigungErsterEntscheidCode], TBL.[IVBerechtigungZweiterEntscheidAb], 
				TBL.[IVBerechtigungZweiterEntscheidCode], TBL.[IVGrad], TBL.[IVHilfsmittel], TBL.[IVTaggeld], TBL.[KeinSerienbrief], TBL.[KonfessionCode],
				TBL.[KontoFuehrung], TBL.[BaPersonID_Dossiertraeger], TBL.[Kopfquote_BaInstitutionID], TBL.[KopfquoteAbDatum], TBL.[KopfquoteBisDatum], TBL.[KorrespondenzSpracheCode],
				TBL.[KTG], TBL.[LaufendeVollmachtErlaubnis], TBL.[ManuelleAnrede], TBL.[MedizinischeMassnahmeIV], TBL.[Mehrfachbehinderung], 
				TBL.[MietdepotPI], TBL.[MigrationKA], TBL.[MobilTel], TBL.[NavigatorZusatz], TBL.[PassiveKopfQuote], TBL.[PauschaleAktualDatum], 
				TBL.[PersonSichtbarSDFlag], TBL.[ProjNr], TBL.[RentenstufeCode], TBL.[SichtbarSDFlag], TBL.[Sozialhilfe], TBL.[Sprachpauschale], 
				TBL.[Testperson], TBL.[UntWohnsitzOrtCode], TBL.[UVGRente], TBL.[UVGTaggeld], TBL.[VerstaendigungSprachCode], TBL.[visdat36Area],
				TBL.[visdat36ID], TBL.[VormundMassnahmenCode], TBL.[VormundPI], TBL.[WichtigerHinweis], TBL.[WittwenWittwerWaisenrente], TBL.[WohnstatusCode], TBL.[ZeigeDetails],
				TBL.[ZeigeTelGeschaeft], TBL.[ZeigeTelMobil], TBL.[ZeigeTelPrivat], TBL.[ZEMISNummer], TBL.[IstBerechnungsperson], TBL.[DatumAsylgesuch], TBL.[DatumEinbezugFaz], /*TBL.[VerID], */TBL.[Creator], TBL.[Created],
				TBL.[Modifier], TBL.[Modified])

	IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
		DELETE TBL
		FROM [Hist_BaPerson]  TBL
			INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BaPersonID] = TBL.[BaPersonID]
		WHERE TBL.VerID = @VerID

	IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
		UPDATE TBL
			SET VerID_DELETED = @VerID
		FROM [Hist_BaPerson]  TBL
			INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BaPersonID] = TBL.[BaPersonID] AND UPD.VerID = TBL.VerID

	IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
		INSERT INTO Hist_BaPerson ([BaPersonID], [StatusPersonCode], [Titel], [Name], [FruehererName], [Vorname], [Vorname2], [Geburtsdatum], [Sterbedatum], [AHVNummer], [Versichertennummer], [HaushaltVersicherungsNummer], [NNummer], [BFFNummer], [ZARNummer], [ZIPNr], [KantonaleReferenznummer], [GeschlechtCode], [ZivilstandCode], [ZivilstandDatum], [HeimatgemeindeCode], [HeimatgemeindeCodes], [NationalitaetCode], [ReligionCode], [AuslaenderStatusCode], [AuslaenderStatusGueltigBis], [Telefon_P], [Telefon_G], [MobilTel1], [MobilTel2], [EMail], [SprachCode], [Unterstuetzt], [Fiktiv], [Bemerkung], [EinwohnerregisterAktiv], [EinwohnerregisterID], [DeutschVerstehenCode], [WichtigerHinweisCode], [ZuzugKtPLZ], [ZuzugKtOrtCode], [ZuzugKtOrt], [ZuzugKtKanton], [ZuzugKtLandCode], [ZuzugKtDatum], [ZuzugKtSeitGeburt], [ZuzugGdePLZ], [ZuzugGdeOrtCode], [ZuzugGdeOrt], [ZuzugGdeKanton], [ZuzugGdeLandCode], [ZuzugGdeDatum], [ZuzugGdeSeitGeburt], [UntWohnsitzPLZ], [UntWohnsitzOrt], [UntWohnsitzKanton], [UntWohnsitzLandCode], [WegzugPLZ], [WegzugOrtCode], [WegzugOrt], [WegzugKanton], [WegzugLandCode], [WegzugDatum], [WohnsitzWieBaPersonID], [AufenthaltWieBaInstitutionID], [ErwerbssituationCode], [GrundTeilzeitarbeit1Code], [GrundTeilzeitarbeit2Code], [BaGrundNichtErwerbstaetigCode], [ErwerbsBrancheCode], [ErlernterBerufCode], [BerufCode], [HoechsteAusbildungCode], [AbgebrocheneAusbildungCode], [ArbeitSpezFaehigkeiten], [KbKostenstelleID], [InCHSeit], [InCHSeitGeburt], [PUAnzahlVerlustscheine], [PUKrankenkasse], [PraemienuebernahmeVon], [PraemienuebernahmeBis], [PersonOhneLeistung], [HCMCFluechtling], [StellensuchendCode], [ResoNr], [NEAnmeldung], [HeimatgemeindeBaGemeindeID], [AktiveKopfQuote], [ALK], [AndereSVLeistungen], [Anrede], [AusbildungCode], [Behinderungsart2Code], [BemerkungenAdresse], [BemerkungenSV], [BeruflicheMassnahmeIV], [Briefanrede], [BSVBehinderungsartCode], [BVGRente], [CAusweisDatum],[KlientenkontoNr], [DebitorNr], [DebitorUpdate], [EigenerMietvertrag], [Einrichtpauschale], [EinrichtungspauschaleCode], [ErgaenzungsLeistungen], [Assistenzbeitrag], [DatumAssistenzbeitrag], [IvVerfuegteAssistenzberatung], [DatumIvVerfuegung], [ErteilungVA], [IstFamiliennachzug], [Fax], [HauptBehinderungsartCode], [HELBKeinAntrag], [HELBAb], [HELBAnmeldung], [HELBEntscheid], [HELBEntscheidCode], [HilfslosenEntschaedigungCode], [ImKantonSeit], [ImKantonSeitGeburt], [InGemeindeSeit], [IntensivPflegeZuschlagCode], [IVBerechtigungAnfangsStatusCode], [IVBerechtigungErsterEntscheidAb], [IVBerechtigungErsterEntscheidCode], [IVBerechtigungZweiterEntscheidAb], [IVBerechtigungZweiterEntscheidCode], [IVGrad], [IVHilfsmittel], [IVTaggeld], [KeinSerienbrief], [KonfessionCode], [KontoFuehrung], [BaPersonID_Dossiertraeger], [Kopfquote_BaInstitutionID], [KopfquoteAbDatum], [KopfquoteBisDatum], [KorrespondenzSpracheCode], [KTG], [LaufendeVollmachtErlaubnis], [ManuelleAnrede], [MedizinischeMassnahmeIV], [Mehrfachbehinderung], [MietdepotPI], [MigrationKA], [MobilTel], [NavigatorZusatz], [PassiveKopfQuote], [PauschaleAktualDatum], [PersonSichtbarSDFlag], [ProjNr], [RentenstufeCode], [SichtbarSDFlag], [Sozialhilfe], [Sprachpauschale], [Testperson], [UntWohnsitzOrtCode], [UVGRente], [UVGTaggeld], [VerstaendigungSprachCode], [visdat36Area], [visdat36ID], [VormundMassnahmenCode], [VormundPI], [WichtigerHinweis], [WittwenWittwerWaisenrente], [WohnstatusCode], [ZeigeDetails], [ZeigeTelGeschaeft], [ZeigeTelMobil], [ZeigeTelPrivat], [ZEMISNummer], [IstBerechnungsperson], [DatumAsylgesuch], [DatumEinbezugFaz], [Creator], [Created], [Modifier], [Modified], VerID)
			SELECT TBL.[BaPersonID], TBL.[StatusPersonCode], TBL.[Titel], TBL.[Name], TBL.[FruehererName], TBL.[Vorname], TBL.[Vorname2], TBL.[Geburtsdatum], TBL.[Sterbedatum], TBL.[AHVNummer], TBL.[Versichertennummer], TBL.[HaushaltVersicherungsNummer], TBL.[NNummer], TBL.[BFFNummer], TBL.[ZARNummer], TBL.[ZIPNr], TBL.[KantonaleReferenznummer], TBL.[GeschlechtCode], TBL.[ZivilstandCode], TBL.[ZivilstandDatum], TBL.[HeimatgemeindeCode], TBL.[HeimatgemeindeCodes], TBL.[NationalitaetCode], TBL.[ReligionCode], TBL.[AuslaenderStatusCode], TBL.[AuslaenderStatusGueltigBis], TBL.[Telefon_P], TBL.[Telefon_G], TBL.[MobilTel1], TBL.[MobilTel2], TBL.[EMail], TBL.[SprachCode], TBL.[Unterstuetzt], TBL.[Fiktiv], TBL.[Bemerkung], TBL.[EinwohnerregisterAktiv], TBL.[EinwohnerregisterID], TBL.[DeutschVerstehenCode], TBL.[WichtigerHinweisCode], TBL.[ZuzugKtPLZ], TBL.[ZuzugKtOrtCode], TBL.[ZuzugKtOrt], TBL.[ZuzugKtKanton], TBL.[ZuzugKtLandCode], TBL.[ZuzugKtDatum], TBL.[ZuzugKtSeitGeburt], TBL.[ZuzugGdePLZ], TBL.[ZuzugGdeOrtCode], TBL.[ZuzugGdeOrt], TBL.[ZuzugGdeKanton], TBL.[ZuzugGdeLandCode], TBL.[ZuzugGdeDatum], TBL.[ZuzugGdeSeitGeburt], TBL.[UntWohnsitzPLZ], TBL.[UntWohnsitzOrt], TBL.[UntWohnsitzKanton], TBL.[UntWohnsitzLandCode], TBL.[WegzugPLZ], TBL.[WegzugOrtCode], TBL.[WegzugOrt], TBL.[WegzugKanton], TBL.[WegzugLandCode], TBL.[WegzugDatum], TBL.[WohnsitzWieBaPersonID], TBL.[AufenthaltWieBaInstitutionID], TBL.[ErwerbssituationCode], TBL.[GrundTeilzeitarbeit1Code], TBL.[GrundTeilzeitarbeit2Code], TBL.[BaGrundNichtErwerbstaetigCode], TBL.[ErwerbsBrancheCode], TBL.[ErlernterBerufCode], TBL.[BerufCode], TBL.[HoechsteAusbildungCode], TBL.[AbgebrocheneAusbildungCode], TBL.[ArbeitSpezFaehigkeiten], TBL.[KbKostenstelleID], TBL.[InCHSeit], TBL.[InCHSeitGeburt], TBL.[PUAnzahlVerlustscheine], TBL.[PUKrankenkasse], TBL.[PraemienuebernahmeVon], TBL.[PraemienuebernahmeBis], TBL.[PersonOhneLeistung], TBL.[HCMCFluechtling], TBL.[StellensuchendCode], TBL.[ResoNr], TBL.[NEAnmeldung], TBL.[HeimatgemeindeBaGemeindeID], TBL.[AktiveKopfQuote], TBL.[ALK], TBL.[AndereSVLeistungen], TBL.[Anrede], TBL.[AusbildungCode], TBL.[Behinderungsart2Code], TBL.[BemerkungenAdresse], TBL.[BemerkungenSV], TBL.[BeruflicheMassnahmeIV], TBL.[Briefanrede], TBL.[BSVBehinderungsartCode], TBL.[BVGRente], TBL.[CAusweisDatum], TBL.[KlientenkontoNr], TBL.[DebitorNr], TBL.[DebitorUpdate], TBL.[EigenerMietvertrag], TBL.[Einrichtpauschale], TBL.[EinrichtungspauschaleCode], TBL.[ErgaenzungsLeistungen], TBL.[Assistenzbeitrag], TBL.[DatumAssistenzbeitrag], TBL.[IvVerfuegteAssistenzberatung], TBL.[DatumIvVerfuegung], TBL.[ErteilungVA], TBL.[IstFamiliennachzug], TBL.[Fax], TBL.[HauptBehinderungsartCode], TBL.[HELBKeinAntrag], TBL.[HELBAb], TBL.[HELBAnmeldung], TBL.[HELBEntscheid], TBL.[HELBEntscheidCode], TBL.[HilfslosenEntschaedigungCode], TBL.[ImKantonSeit], TBL.[ImKantonSeitGeburt], TBL.[InGemeindeSeit], TBL.[IntensivPflegeZuschlagCode], TBL.[IVBerechtigungAnfangsStatusCode], TBL.[IVBerechtigungErsterEntscheidAb], TBL.[IVBerechtigungErsterEntscheidCode], TBL.[IVBerechtigungZweiterEntscheidAb], TBL.[IVBerechtigungZweiterEntscheidCode], TBL.[IVGrad], TBL.[IVHilfsmittel], TBL.[IVTaggeld], TBL.[KeinSerienbrief], TBL.[KonfessionCode], TBL.[KontoFuehrung], TBL.[BaPersonID_Dossiertraeger], TBL.[Kopfquote_BaInstitutionID], TBL.[KopfquoteAbDatum], TBL.[KopfquoteBisDatum], TBL.[KorrespondenzSpracheCode], TBL.[KTG], TBL.[LaufendeVollmachtErlaubnis], TBL.[ManuelleAnrede], TBL.[MedizinischeMassnahmeIV], TBL.[Mehrfachbehinderung], TBL.[MietdepotPI], TBL.[MigrationKA], TBL.[MobilTel], TBL.[NavigatorZusatz], TBL.[PassiveKopfQuote], TBL.[PauschaleAktualDatum], TBL.[PersonSichtbarSDFlag], TBL.[ProjNr], TBL.[RentenstufeCode], TBL.[SichtbarSDFlag], TBL.[Sozialhilfe], TBL.[Sprachpauschale], TBL.[Testperson], TBL.[UntWohnsitzOrtCode], TBL.[UVGRente], TBL.[UVGTaggeld], TBL.[VerstaendigungSprachCode], TBL.[visdat36Area], TBL.[visdat36ID], TBL.[VormundMassnahmenCode], TBL.[VormundPI], TBL.[WichtigerHinweis], TBL.[WittwenWittwerWaisenrente], TBL.[WohnstatusCode], TBL.[ZeigeDetails], TBL.[ZeigeTelGeschaeft], TBL.[ZeigeTelMobil], TBL.[ZeigeTelPrivat], TBL.[ZEMISNummer], TBL.[IstBerechnungsperson], TBL.[DatumAsylgesuch], TBL.[DatumEinbezugFaz], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified], @VerID
			FROM [BaPerson]  TBL
				INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaPersonID] = TBL.[BaPersonID]

		UPDATE TBL
			SET VerID = @VerID
		FROM [BaPerson]  TBL
			INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaPersonID] = TBL.[BaPersonID]
		WHERE IsNull(TBL.VerID, -1) != @VerID
	END
	SET NOCOUNT OFF
END



GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaGemeinde] FOREIGN KEY([HeimatgemeindeBaGemeindeID])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaGemeinde]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreignkey for Heimatgemeinde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaPerson', @level2type=N'CONSTRAINT',@level2name=N'FK_BaPerson_BaGemeinde'
GO

ALTER TABLE [dbo].[BaPerson]  WITH NOCHECK ADD  CONSTRAINT [FK_BaPerson_BaGemeinde_HeimatgemeindeCode] FOREIGN KEY([HeimatgemeindeCode])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaGemeinde_HeimatgemeindeCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaGemeinde_WegzugOrtCode] FOREIGN KEY([WegzugOrtCode])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaGemeinde_WegzugOrtCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaGemeinde_ZuzugGdeOrtCode] FOREIGN KEY([ZuzugGdeOrtCode])
REFERENCES [dbo].[BaGemeinde] ([BaGemeindeID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaGemeinde_ZuzugGdeOrtCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaInstitution] FOREIGN KEY([Kopfquote_BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaInstitution]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaLand_NationalitaetCode] FOREIGN KEY([NationalitaetCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaLand_NationalitaetCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaLand_UntWohnsitzLandCode] FOREIGN KEY([UntWohnsitzLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaLand_UntWohnsitzLandCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaLand_WegzugLandCode] FOREIGN KEY([WegzugLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaLand_WegzugLandCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaLand_ZuzugGdeLandCode] FOREIGN KEY([ZuzugGdeLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaLand_ZuzugGdeLandCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaLand_ZuzugKtLandCode] FOREIGN KEY([ZuzugKtLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaLand_ZuzugKtLandCode]
GO

ALTER TABLE [dbo].[BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_BaPerson_BaPerson_Dossiertraeger] FOREIGN KEY([BaPersonID_Dossiertraeger])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaPerson] CHECK CONSTRAINT [FK_BaPerson_BaPerson_Dossiertraeger]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Fiktiv]  DEFAULT ((0)) FOR [Fiktiv]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_EinwohnerregisterAktiv]  DEFAULT ((0)) FOR [EinwohnerregisterAktiv]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_IstInCHSeitGeburt]  DEFAULT ((0)) FOR [InCHSeitGeburt]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_PersonOhneLeistung]  DEFAULT ((0)) FOR [PersonOhneLeistung]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_HCMCFluechtling]  DEFAULT ((0)) FOR [HCMCFluechtling]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ALK]  DEFAULT ((0)) FOR [ALK]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_BeruflicheMassnahmeIV]  DEFAULT ((0)) FOR [BeruflicheMassnahmeIV]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_BVGRente]  DEFAULT ((0)) FOR [BVGRente]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_EigenerMietvertrag]  DEFAULT ((0)) FOR [EigenerMietvertrag]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ErgaenzungsLeistungen]  DEFAULT ((0)) FOR [ErgaenzungsLeistungen]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Assistenzbeitrag]  DEFAULT ((0)) FOR [Assistenzbeitrag]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_IstFamiliennachzug]  DEFAULT ((0)) FOR [IstFamiliennachzug]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_HELBKeinAntrag]  DEFAULT ((0)) FOR [HELBKeinAntrag]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ImKantonSeitGeburt]  DEFAULT ((0)) FOR [ImKantonSeitGeburt]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_IVHilfsmittel]  DEFAULT ((0)) FOR [IVHilfsmittel]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_IVTaggeld]  DEFAULT ((0)) FOR [IVTaggeld]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_KeinSerienbrief]  DEFAULT ((0)) FOR [KeinSerienbrief]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_KontoFuehrung]  DEFAULT ((0)) FOR [KontoFuehrung]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_KTG]  DEFAULT ((0)) FOR [KTG]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_LaufendeVollmachtErlaubnis]  DEFAULT ((0)) FOR [LaufendeVollmachtErlaubnis]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ManuelleAnrede]  DEFAULT ((0)) FOR [ManuelleAnrede]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_MedizinischeMassnahmeIV]  DEFAULT ((0)) FOR [MedizinischeMassnahmeIV]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Mehrfachbehinderung]  DEFAULT ((0)) FOR [Mehrfachbehinderung]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_MietdepotPI]  DEFAULT ((0)) FOR [MietdepotPI]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_PersonSichtbarSDFlag]  DEFAULT ((1)) FOR [PersonSichtbarSDFlag]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Sozialhilfe]  DEFAULT ((0)) FOR [Sozialhilfe]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Testperson]  DEFAULT ((0)) FOR [Testperson]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_UVGRente]  DEFAULT ((0)) FOR [UVGRente]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_UVGTaggeld]  DEFAULT ((0)) FOR [UVGTaggeld]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_VormundPI]  DEFAULT ((0)) FOR [VormundPI]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_WittwenWittwerWaisenrente]  DEFAULT ((0)) FOR [WittwenWittwerWaisenrente]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ZeigeDetails]  DEFAULT ((1)) FOR [ZeigeDetails]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ZeigeTelGeschaeft]  DEFAULT ((0)) FOR [ZeigeTelGeschaeft]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ZeigeTelMobil]  DEFAULT ((0)) FOR [ZeigeTelMobil]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_ZeigeTelPrivat]  DEFAULT ((1)) FOR [ZeigeTelPrivat]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_IstBerechnungsperson]  DEFAULT ((0)) FOR [IstBerechnungsperson]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaPerson] ADD  CONSTRAINT [DF_BaPerson_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


