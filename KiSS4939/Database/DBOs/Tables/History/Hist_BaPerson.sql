CREATE TABLE [dbo].[Hist_BaPerson](
	[BaPersonID] [int] NOT NULL,
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
	[EinwohnerregisterAktiv] [bit] NULL,
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
	[VerID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BaPerson] PRIMARY KEY CLUSTERED 
(
	[BaPersonID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anrede der Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Anrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Briefanrede der Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Briefanrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checkbox FAZ für Familiennachzug (CAR/SRK spezifisch)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'IstFamiliennachzug'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtenstion', @value=N'IBE' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'IstFamiliennachzug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird von PI auf eine HELB Anmeldung verzichtet, so wird dieses Flag auf True gesetzt und die anderen HELB-Felder geleert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'HELBKeinAntrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, wann der Entscheid für oder gegen HELB getroffen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'HELBEntscheid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Person Serienbriefe erhalten soll oder nicht (0=Serienbrief, 1=kein Serienbrief)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'KeinSerienbrief'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonID des Dossierträgers. Fremdschlüssel (FK_BaPerson_BaPerson_Dossiertraeger) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID_Dossiertraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'CAR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID_Dossiertraeger'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code für die Erfassung der Korrespondenzsprache, betrifft LOV: BaKorrespondenzSprache' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'KorrespondenzSpracheCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Anrede manuell oder automatisch erzeugt wird. Bei der manuellen Anrede kommen die Felder Anrede und Briefanrede zur Geltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'ManuelleAnrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Neues Feld für medizinische Massnahmen IV. Nur für PI (siehe Ticket: #5022)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'MedizinischeMassnahmeIV'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aus der Migration von VIS nach KiSS: Spezifische VIS-Access-DB, welche als Quelle für den Datensatz diente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36Area'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aus der Migration von VIS nach KiSS: ID in der Area-spezifischen VIS-Access-DB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'visdat36ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wittwen-, Wittwer-, Waisenrente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'WittwenWittwerWaisenrente'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'PI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'WittwenWittwerWaisenrente'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VersionsID des Records für die Historisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'VerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Hist_BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

