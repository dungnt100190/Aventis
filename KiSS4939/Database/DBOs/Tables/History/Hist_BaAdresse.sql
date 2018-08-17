CREATE TABLE [dbo].[Hist_BaAdresse](
	[BaAdresseID] [int] NOT NULL,
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
	[VerID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BaAdresse] PRIMARY KEY CLUSTERED 
(
	[BaAdresseID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2],
 CONSTRAINT [UK_Hist_BaAdresse_BaAdresseID_VerID] UNIQUE NONCLUSTERED 
(
	[BaAdresseID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_Hist_BaAdresse_BaAdresseID]    Script Date: 02/27/2012 13:32:16 ******/
CREATE NONCLUSTERED INDEX [IX_Hist_BaAdresse_BaAdresseID] ON [dbo].[Hist_BaAdresse] 
(
	[BaAdresseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_Hist_BaAdresse_BaPersonID]    Script Date: 02/27/2012 13:32:16 ******/
CREATE NONCLUSTERED INDEX [IX_Hist_BaAdresse_BaPersonID] ON [dbo].[Hist_BaAdresse] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_Hist_BaAdresse_VerID]    Script Date: 02/27/2012 13:32:16 ******/
CREATE NONCLUSTERED INDEX [IX_Hist_BaAdresse_VerID] ON [dbo].[Hist_BaAdresse] 
(
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


