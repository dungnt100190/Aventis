CREATE TABLE [dbo].[BaAdresse](
	[BaAdresseID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[UserID] [int] NULL,
	[PlatzierungInstID] [int] NULL,
	[VmMandantID] [int] NULL,
	[VmPriMaID] [int] NULL,
	[KaBetriebID] [int] NULL,
	[KaBetriebKontaktID] [int] NULL,
	[BaLandID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[AusEinwohnerregister] [bit] NOT NULL,
	[Gesperrt] [bit] NOT NULL,
	[AdresseCode] [int] NULL,
	[CareOf] [varchar](200) NULL,
	[Zusatz] [varchar](200) NULL,
	[ZuhandenVon] [varchar](200) NULL,
	[Strasse] [varchar](100) NULL,
	[StrasseCode] [int] NULL,
	[HausNr] [varchar](10) NULL,
	[Postfach] [varchar](100) NULL,
	[PostfachOhneNr] [bit] NOT NULL,
	[PLZ] [varchar](10) NULL,
	[Ort] [varchar](50) NULL,
	[OrtschaftCode] [int] NULL,
	[Kanton] [varchar](10) NULL,
	[Bezirk] [varchar](100) NULL,
	[Bemerkung] [varchar](max) NULL,
	[InstitutionName] [varchar](100) NULL,
	[PlatzierungsartCode] [int] NULL,
	[WohnStatusCode] [int] NULL,
	[WohnungsgroesseCode] [int] NULL,
	[QuartierCode] [int] NULL,
	[MigrationKA] [int] NULL,
	[VerID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaAdresseTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaAdresse] PRIMARY KEY CLUSTERED 
(
	[BaAdresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaAdresse_AdresseCode_BaAdresseID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_AdresseCode_BaAdresseID] ON [dbo].[BaAdresse] 
(
	[AdresseCode] ASC,
	[BaAdresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaAdresseID_Zusatz_Strasse_HausNr_Postfach_PostfachOhneNr_PLZ_Ort_BaLandID_OrtschaftCode_Kanton_Bezirk__AddCols]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaAdresseID_Zusatz_Strasse_HausNr_Postfach_PostfachOhneNr_PLZ_Ort_BaLandID_OrtschaftCode_Kanton_Bezirk__AddCols] ON [dbo].[BaAdresse] 
(
	[BaAdresseID] ASC,
	[Zusatz] ASC,
	[Strasse] ASC,
	[HausNr] ASC,
	[Postfach] ASC,
	[PostfachOhneNr] ASC,
	[PLZ] ASC,
	[Ort] ASC,
	[BaLandID] ASC,
	[OrtschaftCode] ASC,
	[Kanton] ASC,
	[Bezirk] ASC
)
INCLUDE ( [BaInstitutionID],
[CareOf],
[Bemerkung],
[WohnStatusCode],
[WohnungsgroesseCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaInstitutionID_BaPersonID_BaAdresseID_DatumVon_DatumBis_AdresseCode__AddCols]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaInstitutionID_BaPersonID_BaAdresseID_DatumVon_DatumBis_AdresseCode__AddCols] ON [dbo].[BaAdresse] 
(
	[BaInstitutionID] ASC,
	[BaPersonID] ASC,
	[BaAdresseID] ASC,
	[DatumVon] ASC,
	[DatumBis] ASC,
	[AdresseCode] ASC
)
INCLUDE ( [BaLandID],
[Zusatz],
[Strasse],
[HausNr],
[Postfach],
[PostfachOhneNr],
[PLZ],
[Ort],
[Kanton],
[OrtschaftCode],
[Bezirk]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaInstitutionID_DatumBis]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaInstitutionID_DatumBis] ON [dbo].[BaAdresse] 
(
	[BaInstitutionID] ASC,
	[DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaInstitutionID_DatumVon_DatumBis_BaAdresseID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaInstitutionID_DatumVon_DatumBis_BaAdresseID] ON [dbo].[BaAdresse] 
(
	[BaInstitutionID] ASC,
	[DatumVon] ASC,
	[DatumBis] ASC,
	[BaAdresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaLandID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaLandID] ON [dbo].[BaAdresse] 
(
	[BaLandID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaPerson_DatumBis]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaPerson_DatumBis] ON [dbo].[BaAdresse] 
(
	[BaPersonID] ASC,
	[DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaPersonID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaPersonID] ON [dbo].[BaAdresse] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaPersonID_BaAdresseID_DatumVonBis_AdresseCode_Zusatz_StrNrPostfachPLZOrt]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaPersonID_BaAdresseID_DatumVonBis_AdresseCode_Zusatz_StrNrPostfachPLZOrt] ON [dbo].[BaAdresse] 
(
	[BaPersonID] ASC,
	[BaAdresseID] ASC,
	[DatumVon] ASC,
	[DatumBis] ASC,
	[AdresseCode] ASC,
	[Zusatz] ASC,
	[Strasse] ASC,
	[HausNr] ASC,
	[Postfach] ASC,
	[PLZ] ASC,
	[Ort] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_BaPersonID_BaInstitutionID_BaAdresseID_DatumVon_DatumBis__AddCols]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_BaPersonID_BaInstitutionID_BaAdresseID_DatumVon_DatumBis__AddCols] ON [dbo].[BaAdresse] 
(
	[BaPersonID] ASC,
	[BaInstitutionID] ASC,
	[BaAdresseID] ASC,
	[DatumBis] ASC,
	[DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_KaBetriebID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_KaBetriebID] ON [dbo].[BaAdresse] 
(
	[KaBetriebID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_KaBetriebID_BaAdresseID_DatumVon_DatumBis]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_KaBetriebID_BaAdresseID_DatumVon_DatumBis] ON [dbo].[BaAdresse] 
(
	[KaBetriebID] ASC,
	[BaAdresseID] ASC,
	[DatumVon] ASC,
	[DatumBis] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_UserID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_UserID] ON [dbo].[BaAdresse] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_VmMandantID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_VmMandantID] ON [dbo].[BaAdresse] 
(
	[VmMandantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BaAdresse_VmPriMaID]    Script Date: 06/06/2014 14:23:47 ******/
CREATE NONCLUSTERED INDEX [IX_BaAdresse_VmPriMaID] ON [dbo].[BaAdresse] 
(
	[VmPriMaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für Adress Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'BaAdresseID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutige Identifikation der zugehörigen Person. Foreign Key der Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutige Identifikation der zugehörigen Institution. Foreign Key der Institution.   Entweder ist BaPersonID oder BaInstitutionID gefüllt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XUser, Privatadresse des Benutzers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ck: TODO Leo weisst du wozu die ist?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'PlatzierungInstID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO Leo?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'VmMandantID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO Leo?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'VmPriMaID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO Leo?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'KaBetriebID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Land-Angabe des Adressrecords; Wert aus Werteliste BaLand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'BaLandID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angedachte Historisierung der Adressenrecords. In Berner Standard nicht verwendet! TODO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angedachte Historisierung der Adressenrecords. In Berner Standard nicht verwendet! TODO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Adresse gesperrt ist oder nicht (TODO: wird das benötigt?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Gesperrt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Spezifiziert den Typ der Adresse anhand der Werteliste BaAdressTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'AdresseCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zur Institution (=Name der Institution) oder Person (=Name und Vorname der Person), welche für die Anschrift als c/o verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'CareOf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein Vermerk über Besonderheiten der Wohngegebenheiten  z. B. "Zur Untermiete bei Herrn/Frau X".' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Zusatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optionale Zuhanden-Von Angaben, welche für die Anschrift verwendet werden sollen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'ZuhandenVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Strassen-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Strasse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaStrasseID auf BaHaus oder in Alpha-Import gesetzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'StrasseCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'StrasseCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hausnr-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'HausNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postfach-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Postfach'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob das Postfach eine Nummer hat oder lediglich mit Postfach angeschrieben werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'PostfachOhneNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postleitzahl-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort-Angabe des Adressrecords TODO: Ort vs. OrtschaftCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Ort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO OrtschaftCode vs. Ort' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'OrtschaftCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kanton-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Kanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezirk-Angabe des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Bezirk'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld für weitere Angaben des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'InstitutionName'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'InstitutionName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO? Leo?' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'PlatzierungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quartier Code von Alpha' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'QuartierCode'
GO

EXEC sys.sp_addextendedproperty @name=N'NamespaceExtension', @value=N'ZH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'QuartierCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Migrationsfeld; TODO Feld löschen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'MigrationKA'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VersionsID des Adressrecords für die Historisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'VerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse', @level2type=N'COLUMN',@level2name=N'BaAdresseTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adressinformation für Personen und Institutionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaAdresse'
GO

/****** Object:  Trigger [dbo].[trHist_BaAdresse]    Script Date: 06/04/2014 14:06:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trHist_BaAdresse]
  ON [dbo].[BaAdresse]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [BaAdresse] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [BaAdresseID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [BaAdresseID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[BaAdresseID], DEL.[BaAdresseID]), TBL.VerID,
      CASE WHEN (INS.[BaAdresseID] IS NULL) THEN 3 WHEN (DEL.[BaAdresseID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[BaAdresseID] = INS.[BaAdresseID]
      LEFT       JOIN [Hist_BaAdresse]  TBL ON TBL.[BaAdresseID] = DEL.[BaAdresseID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[BaAdresseID] IS NULL) OR (DEL.[BaAdresseID] IS NULL)
      OR CHECKSUM(INS.[BaAdresseID], INS.[BaPersonID], INS.[BaInstitutionID], INS.[UserID], INS.[PlatzierungInstID], INS.[VmMandantID], INS.[VmPriMaID], INS.[KaBetriebID], INS.[KaBetriebKontaktID], INS.[BaLandID], INS.[DatumVon], INS.[DatumBis], INS.[Gesperrt], INS.[AdresseCode], INS.[CareOf], INS.[Zusatz], INS.[ZuhandenVon], INS.[Strasse], INS.[HausNr], INS.[Postfach], INS.[PostfachOhneNr], INS.[PLZ], INS.[Ort], INS.[OrtschaftCode], INS.[Kanton], INS.[Bezirk], INS.[Bemerkung], INS.[PlatzierungsartCode], INS.[WohnStatusCode], INS.[WohnungsgroesseCode], INS.[MigrationKA], INS.[AusEinwohnerregister], INS.[InstitutionName], INS.[StrasseCode], INS.[QuartierCode], INS.[Creator], INS.[Created], INS.[Modifier], INS.[Modified])
      <> CHECKSUM(TBL.[BaAdresseID], TBL.[BaPersonID], TBL.[BaInstitutionID], TBL.[UserID], TBL.[PlatzierungInstID], TBL.[VmMandantID], TBL.[VmPriMaID], TBL.[KaBetriebID], TBL.[KaBetriebKontaktID], TBL.[BaLandID], TBL.[DatumVon], TBL.[DatumBis], TBL.[Gesperrt], TBL.[AdresseCode], TBL.[CareOf], TBL.[Zusatz], TBL.[ZuhandenVon], TBL.[Strasse], TBL.[HausNr], TBL.[Postfach], TBL.[PostfachOhneNr], TBL.[PLZ], TBL.[Ort], TBL.[OrtschaftCode], TBL.[Kanton], TBL.[Bezirk], TBL.[Bemerkung], TBL.[PlatzierungsartCode], TBL.[WohnStatusCode], TBL.[WohnungsgroesseCode], TBL.[MigrationKA], TBL.[AusEinwohnerregister], TBL.[InstitutionName], TBL.[StrasseCode], TBL.[QuartierCode], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified])
     
     

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_BaAdresse]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[BaAdresseID] = TBL.[BaAdresseID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_BaAdresse]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[BaAdresseID] = TBL.[BaAdresseID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_BaAdresse ([BaAdresseID], [BaPersonID], [BaInstitutionID], [UserID], [PlatzierungInstID], [VmMandantID], [VmPriMaID], [KaBetriebID], [KaBetriebKontaktID], [BaLandID], [DatumVon], [DatumBis], [Gesperrt], [AdresseCode], [CareOf], [Zusatz], [ZuhandenVon], [Strasse], [HausNr], [Postfach], [PostfachOhneNr], [PLZ], [Ort], [OrtschaftCode], [Kanton], [Bezirk], [Bemerkung], [PlatzierungsartCode], [WohnStatusCode], [WohnungsgroesseCode], [MigrationKA], [AusEinwohnerregister], [InstitutionName], [StrasseCode], [QuartierCode], [Creator], [Created], [Modifier], [Modified], VerID)
      SELECT TBL.[BaAdresseID], TBL.[BaPersonID], TBL.[BaInstitutionID], TBL.[UserID], TBL.[PlatzierungInstID], TBL.[VmMandantID], TBL.[VmPriMaID], TBL.[KaBetriebID], TBL.[KaBetriebKontaktID], TBL.[BaLandID], TBL.[DatumVon], TBL.[DatumBis], TBL.[Gesperrt], TBL.[AdresseCode], TBL.[CareOf], TBL.[Zusatz], TBL.[ZuhandenVon], TBL.[Strasse], TBL.[HausNr], TBL.[Postfach], TBL.[PostfachOhneNr], TBL.[PLZ], TBL.[Ort], TBL.[OrtschaftCode], TBL.[Kanton], TBL.[Bezirk], TBL.[Bemerkung], TBL.[PlatzierungsartCode], TBL.[WohnStatusCode], TBL.[WohnungsgroesseCode], TBL.[MigrationKA], TBL.[AusEinwohnerregister], TBL.[InstitutionName], TBL.[StrasseCode], TBL.[QuartierCode], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified], @VerID
      FROM [BaAdresse]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaAdresseID] = TBL.[BaAdresseID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [BaAdresse]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[BaAdresseID] = TBL.[BaAdresseID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END

GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_BaInstitution]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_BaInstitution_PlatzierungInstID] FOREIGN KEY([PlatzierungInstID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_BaInstitution_PlatzierungInstID]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_BaLand] FOREIGN KEY([BaLandID])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_BaLand]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_BaPerson]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_KaBetrieb] FOREIGN KEY([KaBetriebID])
REFERENCES [dbo].[KaBetrieb] ([KaBetriebID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_KaBetrieb]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_KaBetriebKontakt] FOREIGN KEY([KaBetriebKontaktID])
REFERENCES [dbo].[KaBetriebKontakt] ([KaBetriebKontaktID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_KaBetriebKontakt]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_VmMandant] FOREIGN KEY([VmMandantID])
REFERENCES [dbo].[VmMandant] ([VmMandantID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_VmMandant]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_VmPriMa] FOREIGN KEY([VmPriMaID])
REFERENCES [dbo].[VmPriMa] ([VmPriMaID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_VmPriMa]
GO

ALTER TABLE [dbo].[BaAdresse]  WITH CHECK ADD  CONSTRAINT [FK_BaAdresse_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaAdresse] CHECK CONSTRAINT [FK_BaAdresse_XUser]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_AusEinwohnerregister]  DEFAULT ((0)) FOR [AusEinwohnerregister]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_Gesperrt]  DEFAULT ((0)) FOR [Gesperrt]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_PostfachOhneNr]  DEFAULT ((0)) FOR [PostfachOhneNr]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_MigrationKA]  DEFAULT ((0)) FOR [MigrationKA]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaAdresse] ADD  CONSTRAINT [DF_BaAdresse_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


